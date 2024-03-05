import os
import torch
import torch.nn as nn
import torch.optim as optim
from torch.utils.data import DataLoader
from torchvision import transforms
from torchvision.datasets import ImageFolder
import cv2
from PIL import Image
import sys

# Recupera gli argomenti della riga di comando
if len(sys.argv) > 1:
    image_path = sys.argv[1]
else:
    print("Nessun percorso dell'immagine fornito.")

class CNNModel(nn.Module):
    def __init__(self, num_classes):
        super(CNNModel, self).__init__()

        # Definiamo i livelli convoluzionali e di max pooling
        self.conv1 = nn.Conv2d(3, 32, kernel_size=3, stride=1, padding=1)
        self.relu1 = nn.ReLU()
        self.pool1 = nn.MaxPool2d(kernel_size=2, stride=2)

        self.conv2 = nn.Conv2d(32, 64, kernel_size=3, stride=1, padding=1)
        self.relu2 = nn.ReLU()
        self.pool2 = nn.MaxPool2d(kernel_size=2, stride=2)

        self.conv3 = nn.Conv2d(64, 128, kernel_size=3, stride=1, padding=1)
        self.relu3 = nn.ReLU()
        self.pool3 = nn.MaxPool2d(kernel_size=2, stride=2)

        # Mappo le etichette
        self.class_mapping = {0: 'maglietta', 1: 'camicia', 2: 'felpa', 3: 'abito', 4: 'pantaloni', 5: 'gonna', 6: 'shorts'}

        # Appiattiamo i dati prima di passarli attraverso i livelli densi
        self.flatten = nn.Flatten()

        # Definiamo i livelli densi
        self.fc1 = nn.Linear(128 * (img_height // 8) * (img_width // 8), 128)
        self.relu4 = nn.ReLU()

        self.fc2 = nn.Linear(128, num_classes)

    def forward(self, x):
        # Definiamo il flusso in avanti attraverso i vari livelli
        x = self.pool1(self.relu1(self.conv1(x)))
        x = self.pool2(self.relu2(self.conv2(x)))
        x = self.pool3(self.relu3(self.conv3(x)))
        x = self.flatten(x)
        x = self.relu4(self.fc1(x))
        x = self.fc2(x)
        return x
    
# Impostiamo parametri
img_height, img_width = 328, 223
num_classes = 7

# Creiamo un'istanza del modello
model = CNNModel(num_classes)

# Definiamo la loss e l'ottimizzatore
criterion = nn.CrossEntropyLoss()
optimizer = optim.Adam(model.parameters(), lr=0.001)

# Configuriamo la trasformazione delle immagini
transform = transforms.Compose([
    transforms.Resize((img_height, img_width)),
    transforms.ToTensor(),
])

# Carica l'immagine con OpenCV
image_opencv = cv2.imread(image_path)

# Applica le trasformazioni a ciascuna regione
transform = transforms.Compose([
    transforms.Resize((328, 223)),
    transforms.ToTensor(),
])

# Processa la regione del torso
region_torso = image_opencv[:800, :]
image_torso = Image.fromarray(region_torso)
image_torso = transform(image_torso)
image_torso = image_torso.unsqueeze(0)

# Processa la regione delle gambe
region_gambe = image_opencv[600:, :]
image_gambe = Image.fromarray(region_gambe)
image_gambe = transform(image_gambe)
image_gambe = image_gambe.unsqueeze(0)

# Carica il modello per il riconoscimento del torso
model_torso = CNNModel(7)
model_torso.load_state_dict(torch.load("C:\\Users\\1\\Desktop\\macchina\\test\\pesi_modello.pth"))
model_torso.eval()

# Carica il modello per il riconoscimento delle gambe
model_gambe = CNNModel(7)
model_gambe.load_state_dict(torch.load("C:\\Users\\1\\Desktop\\macchina\\test\\pesi_modello.pth"))
model_gambe.eval()

# Passa le immagini attraverso i modelli
with torch.no_grad():
    outputs_torso = model_torso(image_torso)
    outputs_gambe = model_gambe(image_gambe)

# Ottieni gli indici delle classi predette per torso e gambe
_, predicted_index_torso = torch.max(outputs_torso, 1)
_, predicted_index_gambe = torch.max(outputs_gambe, 1)

# Mappa gli indici alle classi
class_mapping_torso = {0: 'maglietta', 1: 'camicia', 2: 'felpa', 3: 'abito', 4: 'pantaloni', 5: 'felpa', 6: 'shorts'}
class_mapping_gambe = {0: 'maglietta', 1: 'camicia', 2: 'felpa', 3: 'abito', 4: 'pantaloni', 5: 'pantaloni', 6: 'shorts'}

predicted_class_torso = class_mapping_torso[predicted_index_torso.item()]
predicted_class_gambe = class_mapping_gambe[predicted_index_gambe.item()]

# Stampa le classi predette
print(f"{predicted_class_torso},")
print(f"{predicted_class_gambe}")
