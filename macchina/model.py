import os
import torch
import torch.nn as nn
import torch.optim as optim
from torch.utils.data import DataLoader
from torchvision import transforms
from torchvision.datasets import ImageFolder

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

dataset = ImageFolder(root="C:\\Users\\1\\Desktop\\nuovodataset", transform=transform)

#divido il dataset in train e test
train_size = int(0.8 * len(dataset))
test_size = len(dataset) - train_size
train_dataset, test_dataset = torch.utils.data.random_split(dataset, [train_size, test_size])


batch_size = 16
num_epochs = 10

# Creiamo i DataLoader per il set di addestramento e test
train_loader = DataLoader(train_dataset, batch_size=batch_size, shuffle=True)
test_loader = DataLoader(test_dataset, batch_size=batch_size, shuffle=False)

# Addestramento del modello
for epoch in range(num_epochs):
    model.train()  # Imposta il modello in modalità di addestramento

    for images, labels in train_loader:
        # Azzera i gradienti
        optimizer.zero_grad()

        # Passa i dati attraverso il modello
        outputs = model(images)

        # Calcola la loss
        loss = criterion(outputs, labels)

        # Esegui la retropropagazione e l'ottimizzazione
        loss.backward()
        optimizer.step()

    # Valutazione del modello sul set di test
    model.eval()  # Imposta il modello in modalità di valutazione
    correct = 0
    total = 0

    with torch.no_grad():
        for images, labels in test_loader:
            outputs = model(images)
            _, predicted = torch.max(outputs.data, 1)
            total += labels.size(0)
            correct += (predicted == labels).sum().item()

    accuracy = correct / total
    print(f'Epoch {epoch+1}/{num_epochs}, Loss: {loss.item():.4f}, Accuracy on test set: {accuracy:.2%}')

print("Addestramento completato.")

percorso_salvataggio = 'C:\\Users\\1\\Desktop\\macchina'

# Crea la directory se non esiste già
if not os.path.exists(percorso_salvataggio):
    os.makedirs(percorso_salvataggio)

# Salva i pesi del modello
torch.save(model.state_dict(), os.path.join(percorso_salvataggio, 'pesi_modello.pth'))