import cv2 as cv
import numpy as np
import sys

def rileva_oggetti(img, classificatori):
    capi_vestiario = []

    for classificatore, nome_vestito in classificatori:
        spazio = classificatore.detectMultiScale(img, scaleFactor=1.1, minNeighbors=200)
        elementi = len(spazio)

        if elementi > 0:
            print(f"{nome_vestito}: {elementi} elementi rilevati")
            capi_vestiario.append(nome_vestito)

            for (x, y, w, h) in spazio:
                cv.rectangle(img, (x, y), (x+w, y+h), (0, 0, 255), thickness=4)

    return capi_vestiario

classificatori = [
    (cv.CascadeClassifier("File xml cascade\MEN-Denim.xml"), "Denim"),
    (cv.CascadeClassifier("File xml cascade\MEN-Jacket_Vests.xml"), "Camicia"),
    (cv.CascadeClassifier("File xml cascade\MEN-Pants.xml"), "Pantaloni"),
    (cv.CascadeClassifier("File xml cascade\MEN-Shirts_Polos.xml"), "Polo"),
    (cv.CascadeClassifier("File xml cascade\MEN-Shorts.xml"), "Shorts"),
    (cv.CascadeClassifier("File xml cascade\MEN-Sweaters.xml"), "Maglione"),
    (cv.CascadeClassifier("File xml cascade\MEN-Sweatshirt_hoodies.xml"), "Felpa con cappuccio"),
    (cv.CascadeClassifier("File xml cascade\MEN-Tees_Tanks.xml"), "Canottiere"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Blouses_Shirts.xml"), "Camicia"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Cardigans.xml"), "Cardigan"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Denim.xml"), "Denim"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Dresses.xml"), "Abito"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Graphic_Tees.xml"), "Motivo"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Jackets_Coats.xml"), "Cappotti"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Leggins.xml"), "Leggins"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Pants.xml"), "Pantaloni"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Rompers_Jumpsuits.xml"), "Tute eleganti"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Shorts.xml"), "Shorts"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Skirt.xml"), "Gonna"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Sweaters.xml"), "Maglione"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Sweatshirts_hoodies.xml"), "Felpa con cappuccio"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Tee_Tanks1.xml"), "Canotte"),
    (cv.CascadeClassifier("File xml cascade\WOMEN-Tee_Tanks2.xml"), "Canotte"),
]

image_path = sys.argv[1]

img = cv.imread(image_path)

lista_capi_vestiario = rileva_oggetti(img, classificatori)

img = cv.resize(img, (int(img.shape[1] * 0.50), int(img.shape[0] * 0.50)), interpolation=cv.INTER_AREA)

cv.imshow("Risultato", img)
cv.waitKey(0)

print("Capi di vestiario rilevati:", lista_capi_vestiario)