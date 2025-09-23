from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.common.by import By
from selenium.webdriver.common.action_chains import ActionChains
from webdriver_manager.chrome import ChromeDriverManager
import time
import Funciones
import unittest
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.support.ui import WebDriverWait
from pywinauto import application

class TestExample(unittest.TestCase):
    Ruta = Funciones.CrearRutaEvidencia('Circular2275')

    @classmethod 
    def setUpClass(cls):        
        Funciones.LeerArchivo()             
        chrome_options = webdriver.ChromeOptions()            
        chrome_options.add_argument("--incognito") 
        chrome_options.add_argument("--start-maximized")    
        # Usar webdriver-manager para manejar el driver de Chrome
        cls.driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()), options=chrome_options)
    def test_A1_carga_de_web(self):
        NombrePrueba = 'Iniciar Sesion'
        try:
            Funciones.test_carga_web(self)
        except Exception as e:
            Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
            self.fail(f"Error {NombrePrueba}: {str(e)}") 
    

    def test_A2_CrearInstanciaCircular2275(self):
        NombrePrueba = 'Crear instancia Circular 2275'
        corr=Funciones.RescataCorr(self)
        try:
            Funciones.test_CrearInstancia(self,NombrePrueba,"Circular 2275","Circular 2275",corr)
        except Exception as e:
            Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
            self.fail(f"Error {NombrePrueba}: {str(e)}")
    
    def test_A3_SubirArchivoCircular2275(self):
        NombrePrueba = 'SubirArchivo Circular 2275'
        try:
            Funciones.test_SubirArchivo(self,NombrePrueba,"Circular2275")
        except Exception as e:
            Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
            self.fail(f"Error {NombrePrueba}: {str(e)}")

    def test_B1_CerrarSesion(self): 
        NombrePrueba = 'Cerrar Sesion'
        try:
            Funciones.test_CerrarSesion(self)
        except Exception as e:
            Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
            self.fail(f"Error {NombrePrueba}: {str(e)}")     
    

    @classmethod   
    def tearDownClass(cls):    
        cls.driver.quit()

if __name__ == "__main__":
    suite = unittest.TestLoader().loadTestsFromTestCase(TestExample)
    corredor = unittest.TextTestRunner()
    resultados = corredor.run(suite)
    print(resultados)
