from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.common.by import By
from selenium.webdriver.common.action_chains import ActionChains
from webdriver_manager.chrome import ChromeDriverManager
import Funciones
import unittest
import time
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.support.ui import WebDriverWait


class TestExample(unittest.TestCase):
    Ruta = Funciones.CrearRutaEvidencia("EditarInstancias")

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

    def test_A2_MantenedorTextos(self):
        NombrePrueba = 'MantenedorTextos'
        corr=Funciones.RescataCorr(self)
        try:
            #Revisar si ya esta Editada 
            Funciones.BuscarInstanciaCheck(self,'Holding Bancario 157','ManTextos')
            Funciones.RevisarTextosAntesdeCrear(self,NombrePrueba,'Holding Bancario 157',3)

            Funciones.BuscarInstanciaCheck(self,'Holding Seguro 157','ManTextos')
            Funciones.RevisarTextosAntesdeCrear(self,NombrePrueba,'Holding Seguro 157',3)


            Funciones.test_CrearInstancia(self,NombrePrueba,"Holding Bancario","Docs Financieros",corr)
            Funciones.BuscarInstanciaCheck(self,f'Holding Bancario {corr}','ManTextos')
            Funciones.AgregarTextos(self,NombrePrueba,3)
            Funciones.test_CrearInstancia(self,NombrePrueba,"Holding Seguro","Docs Financieros",corr)
            Funciones.test_CopiaConfiguracionTextos(self,NombrePrueba,f'Holding Bancario {corr}',f'Holding Seguro {corr}')
            Funciones.BuscarInstanciaCheck(self,f'Holding Seguro {corr}','ManTextos')
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

if __name__ == "__main__":
    suite = unittest.TestLoader().loadTestsFromTestCase(TestExample)
    corredor = unittest.TextTestRunner()
    resultados = corredor.run(suite)
    print(resultados)
