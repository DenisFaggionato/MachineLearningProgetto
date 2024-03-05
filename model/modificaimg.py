import cv2
import os

def riduci_dimensioni_immagini(cartella_principale, cartella_output, altezza_desiderata):
    # Assicurati che la cartella di output esista
    if not os.path.exists(cartella_output):
        os.makedirs(cartella_output)

    # Scorri tutte le sottocartelle nella cartella principale
    for categoria in os.listdir(cartella_principale):
        categoria_path = os.path.join(cartella_principale, categoria)

        if os.path.isdir(categoria_path):
            # Assicurati che esista una sottocartella nella cartella di output per questa categoria
            categoria_output_path = os.path.join(cartella_output, categoria)
            if not os.path.exists(categoria_output_path):
                os.makedirs(categoria_output_path)

            # Elabora ogni immagine nella sottocartella
            for filename in os.listdir(categoria_path):
                if filename.endswith(".jpg") or filename.endswith(".png"):
                    # Carica l'immagine
                    img_path = os.path.join(categoria_path, filename)
                    img = cv2.imread(img_path)

                    # Calcola la nuova larghezza mantenendo la proporzione
                    altezza_originale, larghezza_originale = img.shape[:2]
                    nuova_larghezza = int((altezza_desiderata / altezza_originale) * larghezza_originale)

                    # Ridimensiona l'immagine
                    nuova_img = cv2.resize(img, (nuova_larghezza, altezza_desiderata))

                    # Salva l'immagine nella sottocartella di output
                    output_path = os.path.join(categoria_output_path, filename)
                    cv2.imwrite(output_path, nuova_img)

# Esempio di utilizzo
cartella_principale = "C:\\Users\\1\\Desktop\\dataset"
cartella_output = "C:\\Users\\1\\Desktop\\nuovodataset"
altezza_desiderata = 328  # Puoi regolare questo valore in base all'altezza desiderata

riduci_dimensioni_immagini(cartella_principale, cartella_output, altezza_desiderata)