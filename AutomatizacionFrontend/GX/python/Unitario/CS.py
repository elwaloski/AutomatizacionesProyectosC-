from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.common.by import By
from selenium.webdriver.common.action_chains import ActionChains
from webdriver_manager.chrome import ChromeDriverManager
import Funciones
import unittest
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.support.ui import WebDriverWait
from pywinauto import application

class TestExample(unittest.TestCase):
    Ruta = Funciones.CrearRutaEvidencia('CS')

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

    def test_A2_CrearInstanciaCS(self):
            NombrePrueba = 'Crear instancia CS'
            corr=Funciones.RescataCorr(self)
            try:
                Funciones.test_CrearInstancia(self,NombrePrueba,"Seguro","Docs Financieros",corr)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")

    def test_A3_SubirArchivoCS(self):
        NombrePrueba = 'SubirArchivoCS'
        try:
            Funciones.test_SubirArchivo(self,NombrePrueba,"CS") 
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
