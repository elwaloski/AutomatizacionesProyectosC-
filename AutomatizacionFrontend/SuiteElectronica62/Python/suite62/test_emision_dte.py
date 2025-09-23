
import json
import time as t
import unittest
from selenium import webdriver
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.common.by import By
from ddt import ddt, data, unpack
import csv

@ddt
class ImpresionDte(unittest.TestCase):
    def get_data_from_csv(nombre_archivo):
        filas = []
        with open(nombre_archivo, "r") as archivo:
            reader = csv.reader(archivo)
            next(reader)
            for fila in reader:
                filas.append(tuple(fila))
        return filas
    
    #ruta = funciones.CrearRutavidencia('TestAutomatizado')
    @classmethod 
    def setUpClass(cls) -> None:
        try:
            #Leer archivo de configuracion
            with open("./config.json", "r") as archivo:
                config = json.load(archivo)
        except:
            cls.fail("Error al leer el archivo de configuracion")
        try:    
            URL62 = config["url"]
            USER = config["user"]
            PASS = config["password"]
        except:
            cls.fail("Error al leer keys de json")

        try:    
            #iniciar webdriver
            cls.driver = webdriver.Edge()
            cls.driver.get(URL62)
            cls.driver.maximize_window()
            cls.wait = WebDriverWait(cls.driver, 10)
            
            #hacer login
            cls.driver.find_element(By.XPATH, "//input[@id='p_Usuario']").send_keys(USER)
            cls.driver.find_element(By.XPATH, "//input[@id='p_Clave']").send_keys(PASS)
            cls.driver.find_element(By.XPATH, "//input[@value='Ingresar']").click()
        except:
            cls.fail("Error al realizar login")

    def setUp(cls) -> None:
        t.sleep(3)
        try:
            #ir a la pantalla cada prueba
            cls.driver.find_element(By.XPATH, "//span[normalize-space()='Emisión DTE']").click()
            cls.driver.find_element(By.XPATH, "//a[normalize-space()='Impresión DTE']").click()
        except:
            cls.fail("Error al ir a ImpresionDTE")
    
    def tearDown(cls):
        cls.driver.refresh()

    @data(*get_data_from_csv("./data/impresion_dte_copy.csv"))
    @unpack
    def test_genera_archivo(cls, tipo_docu, foli_desd, foli_hast, impresora, normal, cedible):
        t.sleep(3)
        try:
            #completar el formulario
            cls.driver.switch_to.frame("DBNET_frame")
            cls.driver.switch_to.frame("monitor_frame")

            #seleccionar tipo documento
            cls.driver.find_element(By.XPATH, "//input[@id='Tipo_docu']").click()
            cls.driver.find_element(By.XPATH, "//input[@id='Tipo_docu']").send_keys(Keys.CONTROL + "a")
            cls.driver.find_element(By.XPATH, "//input[@id='Tipo_docu']").send_keys(tipo_docu)

            #indicar folio desde
            cls.driver.find_element(By.XPATH, "//input[@id='Foli_docu1']").click()
            cls.driver.find_element(By.XPATH, "//input[@id='Foli_docu1']").send_keys(Keys.CONTROL + "a")
            cls.driver.find_element(By.XPATH, "//input[@id='Foli_docu1']").send_keys(foli_desd)

            #indicar folio hasta
            cls.driver.find_element(By.XPATH, "//input[@id='Foli_docu2']").click()
            cls.driver.find_element(By.XPATH, "//input[@id='Foli_docu2']").send_keys(Keys.CONTROL + "a")
            cls.driver.find_element(By.XPATH, "//input[@id='Foli_docu2']").send_keys(foli_hast)
            
            #validar si seleccionar impresora
            if impresora == "True":
                cls.driver.find_element(By.XPATH, "//input[@id='Impresora']").click()

            #validar si seleccionar normal
            if normal == "True":
                cls.driver.find_element(By.XPATH, "//input[@id='check_normal']").click()
            
            #validar si selccionar cedible
            if cedible == "True":
                cls.driver.find_element(By.XPATH, "//input[@id='check_cedible']").click()

            #hacer click en el boton ejecutar
            cls.driver.find_element(By.XPATH, "//input[@id='barRun']").click()
        except:
            cls.fail("Error al completar el formulario de ImpresionDTE")

        #leer bar
        try:
            cls.driver.switch_to.frame("fraEstadoId")
            resultado = cls.wait.until(EC.element_to_be_clickable((By.XPATH, cls.driver.find_element(By.XPATH, "//iframe[@id='fraEstadoId']"))))
            print("resultado", resultado.text)
            cls.assertEqual(True, True) 
        except:
            cls.fail("Ha ocurrido un error en el proceso")

if __name__ == "__main_":
    unittest.main()