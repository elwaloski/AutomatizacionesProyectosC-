import pytest
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from webdriver_manager.chrome import ChromeDriverManager
import funciones
from pytest_html_reporter import attach



@pytest.fixture(scope="class")
def setUpClass(request):
    # Configuración del navegador
    funciones.LeerArchivo()     
    chrome_options = webdriver.ChromeOptions()            
    chrome_options.add_argument("--incognito") 
    chrome_options.add_argument("--start-maximized")     
    # Usar webdriver-manager para manejar el driver de Chrome
    driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()), options=chrome_options)
    
    # Pasar el driver a las pruebas
    request.cls.driver = driver
    yield driver
    driver.quit()

@pytest.mark.usefixtures("setUpClass")
class TestExample:

    def test_A0_CargaWeb(self):
        try:
            funciones.CargaWeb(self)
        except Exception as e:
            funciones.logINFO(f"Error Carga Web: {str(e)}", "ERROR")
            pytest.fail(f"Error Carga Web: {str(e)}") 

    def test_A1_carga_de_web(self):
        NombrePrueba = 'Iniciar Sesion'
        try:
            funciones.test_carga_web(self)
        except Exception as e:
            funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
            pytest.fail(f"Error {NombrePrueba}: {str(e)}") 

    def test_A2_BotonNecesitoAyuda(self):
        NombrePrueba = 'Necesito Ayuda'
        try:
            funciones.test_NecesitoAyuda(self,NombrePrueba)
        except Exception as e:
            funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
            pytest.fail(f"Error {NombrePrueba}: {str(e)}")

    def test_B1_CerrarSesion(self): 
        NombrePrueba = 'Cerrar Sesion'
        try:
            funciones.test_CerrarSesion(self)
        except Exception as e:
            funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
            pytest.fail(f"Error {NombrePrueba}: {str(e)}")
