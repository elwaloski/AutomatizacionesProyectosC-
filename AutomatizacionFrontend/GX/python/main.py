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

class TestGX(unittest.TestCase):
    Ruta = Funciones.CrearRutaEvidencia('TestAutomatizado')

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


#ConsultaParametros
    def test_B1_ConsultaConceptosCS(self):
        NombrePrueba = 'BuscarConceptoCS'
        if Funciones.ConsultaConceptos.upper() =="SI":  
            try:
                Funciones.test_ConsultaConceptos(self,NombrePrueba,"Seguro","cl-cs-2017-11-30","activo")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")    
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")

    def test_B2_ConsultaConceptosHB(self):
        NombrePrueba = 'BuscarConceptoHB'
        if Funciones.ConsultaConceptos.upper() =="SI": 
            try:
                Funciones.test_ConsultaConceptos(self,NombrePrueba,"Holding Bancario","cl-hb-2024-01-02","Patrimonio")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")  
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")

    def test_B3_ConsultaConceptosHS(self):
        NombrePrueba = 'BuscarConceptoHS'
        if Funciones.ConsultaConceptos.upper() =="SI": 
            try:
                Funciones.test_ConsultaConceptos(self,NombrePrueba,"Holding Seguro","cl-hs-2024-01-02","Patrimonio")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")  
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")

    def test_B4_ConsultaConceptosCC(self):
        NombrePrueba = 'BuscarConceptoCC'
        if Funciones.ConsultaConceptos.upper() =="SI": 
            try:
                Funciones.test_ConsultaConceptos(self,NombrePrueba,"Cajas Compensación","svs-cl-cc-2024-01-02","Patrimonio")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")  
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
            
    def test_B5_ConsultaConceptosEI(self):
        NombrePrueba = 'BuscarConceptoEI'
        if Funciones.ConsultaConceptos.upper() =="SI": 
            try:
                Funciones.test_ConsultaConceptos(self,NombrePrueba,"Entidades informantes","svs-cl-ei-2024-01-02","Aplicacion")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")

    def test_B6_ConsultaConceptosBS(self):
        NombrePrueba = 'BuscarConceptoBS'
        if Funciones.ConsultaConceptos.upper() =="SI": 
            try:
                Funciones.test_ConsultaConceptos(self,NombrePrueba,"Bancos y Seguros","svs-cl-bs-2024-01-02","Negocios")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")

    def test_B7_ConsultaConceptosTX(self):
        NombrePrueba = 'BuscarConceptoTX'
        if Funciones.ConsultaConceptos.upper() =="SI": 
            try:
                Funciones.test_ConsultaConceptos(self,NombrePrueba,"Taxo Fondos","cl-iv_20110430","Aumento")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")

    def test_B8_ConsultaConceptosCircular(self):
        NombrePrueba = 'BuscarConceptoCircular'
        if Funciones.ConsultaConceptos.upper() =="SI": 
            try:
                Funciones.test_ConsultaConceptos(self,NombrePrueba,"Circ2275","cs-im-2020-03-15","Cuentas")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
                
    def test_B9_ConsultaConceptosCI(self):
        NombrePrueba = 'BuscarConceptoCI'
        if Funciones.ConsultaConceptos.upper() =="SI": 
            try:
                Funciones.test_ConsultaConceptos(self,NombrePrueba,"Comercio Industria","svs-cl-ci-2024-01-02","Total")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
#Fin ConsultaParametros

#CrearParametro
    def test_C1_CrearParaGene(self):
        NombrePrueba = 'CrearParaGene'
        if Funciones.CrearParametros =="SI": 
            try:
                Funciones.test_CrearParaGene(self,NombrePrueba)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
    
    def test_C2_CrearParamEmpr(self):
        NombrePrueba = 'CrearParamEmpr'
        if Funciones.CrearParametros.upper() =="SI": 
            try:
                Funciones.test_CrearParamEmpr(self,NombrePrueba)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
#Fin CrearParametro

#CambioEmpresa
    def test_D1_CambioEmpr(self):
        NombrePrueba = 'Cambio de Empresa'
        if Funciones.CambioEmpresa.upper() =="SI": 
            try:
                Funciones.test_CambioEmpr(self,NombrePrueba)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
#Fin CambioEmpresa	

#Necesito Ayuda   
    def test_E1_BotonNecesitoAyuda(self):
        NombrePrueba = 'Necesito Ayuda'
        if Funciones.NecesitoAyuda.upper() =="SI": 
            try:
                Funciones.test_NecesitoAyuda(self,NombrePrueba)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
            
#Fin Necesito Ayuda  

#HB        
    def test_F1_CrearInstanciaHB(self):
        NombrePrueba = 'Crear instancia HB'
        if Funciones.HB =="SI":                
                corr=Funciones.RescataCorr(self)
                try:
                    Funciones.test_CrearInstancia(self,NombrePrueba,"Holding Bancario","Docs Financieros",corr)
                except Exception as e:
                    Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                    self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")

    def test_F2_CrearInstanciaHB(self):
        NombrePrueba = 'SubirArchivoHB'
        if Funciones.HB =="SI":            
            try:
                Funciones.test_SubirArchivo(self,NombrePrueba,"HB")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail("Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
#Fin HB 

#HS
    def test_G1_CrearInstanciaHS(self):
        NombrePrueba = 'Crear instancia HS'
        if Funciones.HS =="SI":  
            corr=Funciones.RescataCorr(self)
            try:
                Funciones.test_CrearInstancia(self,NombrePrueba,"Holding Seguro","Docs Financieros",corr)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")

    def test_G2_SubirArchivoHS(self):
        NombrePrueba = 'SubirArchivoHS'
        if Funciones.HS =="SI":  
            try:
                Funciones.test_SubirArchivo(self,NombrePrueba,"HS")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
#Fin HS

#BS
    def test_H1_CrearInstanciaBS(self):
        NombrePrueba = 'Crear instancia BS'
        if Funciones.BS =="SI":
            corr=Funciones.RescataCorr(self)
            try:
                Funciones.test_CrearInstancia(self,NombrePrueba,"Bancos y Seguros","Docs Financieros",corr)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")

    def test_H2_SubirArchivoBS(self):
        NombrePrueba = 'SubirArchivoBS'
        if Funciones.BS =="SI":
            try:
                Funciones.test_SubirArchivo(self,NombrePrueba,"BS")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")          
#Fin BS        

#CC
    def test_I1_CrearInstanciaCC(self):
        NombrePrueba = 'Crear instancia CC'
        if Funciones.CC =="SI":
            corr=Funciones.RescataCorr(self)
            try:
                Funciones.test_CrearInstancia(self,NombrePrueba,"Cajas Compensación","Docs Financieros",corr)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")

    def test_I2_SubirArchivoCC(self):
        NombrePrueba = 'SubirArchivoCC'
        if Funciones.CC =="SI":
            try:
                Funciones.test_SubirArchivo(self,NombrePrueba,"CC")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
#Fin CC

#CI
    def test_J1_CrearInstanciaCI(self):
        NombrePrueba = 'Crear instancia CI'
        if Funciones.CI =="SI":
            corr=Funciones.RescataCorr(self)
            try:
                Funciones.test_CrearInstancia(self,NombrePrueba,"Comercio Industria","Docs Financieros",corr)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json") 
            
    def test_J2_SubirArchivoCI(self):
        NombrePrueba = 'SubirArchivoCI'
        if Funciones.CI =="SI":
            try:
                Funciones.test_SubirArchivo(self,NombrePrueba,"CI")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json") 
#Fin CI			

#Circular
    def test_K1_CrearInstanciaCircular2275(self):
        NombrePrueba = 'Crear instancia Circular 2275'
        if Funciones.Circular =="SI":
            corr=Funciones.RescataCorr(self)
            try:
                Funciones.test_CrearInstancia(self,NombrePrueba,"Circular 2275","Circular 2275",corr)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
    
    def test_K2_SubirArchivoCircular2275(self):
        NombrePrueba = 'SubirArchivo Circular 2275'
        if Funciones.Circular =="SI":
            try:
                Funciones.test_SubirArchivo(self,NombrePrueba,"Circular2275")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")            
#Fin Circular

#CS
    def test_M1_CrearInstanciaCS(self):
        NombrePrueba = 'Crear instancia CS'
        if Funciones.CS=="SI":
            corr=Funciones.RescataCorr(self)
            try:
                Funciones.test_CrearInstancia(self,NombrePrueba,"Seguro","Docs Financieros",corr)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json") 

    def test_M2_SubirArchivoCS(self):
        NombrePrueba = 'SubirArchivoCS'
        if Funciones.CS=="SI":
            try:
                Funciones.test_SubirArchivo(self,NombrePrueba,"CS") 
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json","INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json") 
#Fin CS

#EI
    def test_N1_CrearInstanciaEI(self):
        NombrePrueba = 'Crear instancia EI'
        if Funciones.EI=="SI":
            corr=Funciones.RescataCorr(self)
            try:
                Funciones.test_CrearInstancia(self,NombrePrueba,"Entidades informantes","Docs Financieros",corr)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json","INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
    
    def test_N2_SubirArchivoEI(self):
        NombrePrueba = 'SubirArchivoEI'
        if Funciones.EI=="SI":
            try:
                Funciones.test_SubirArchivo(self,NombrePrueba,"EI")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json","INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json") 
#Fin EI

#Fondos FI
    def test_O1_CrearInstanciaFondosFI(self):
        NombrePrueba = 'Crear instancia Fondos FI'
        if Funciones.FondosFI=="SI":
            corr=Funciones.RescataCorr(self)
            try:
                Funciones.test_CrearInstancia(self,NombrePrueba,"cl-fi_20110430","Docs Fondos",corr)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
            
    def test_O2_SubirArchivoFondosFI(self):
        NombrePrueba = 'SubirArchivo taxo FI'
        if Funciones.FondosFI=="SI":
            try:
                Funciones.test_SubirArchivo(self,NombrePrueba,"FondosFi")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json","INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json") 
#Fin Fondos FI

#Fondos FM
    def test_P1_CrearInstanciaFondosFM(self):
        NombrePrueba = 'Crear instancia Fondos FM'
        if Funciones.FondosFM=="SI":
            corr=Funciones.RescataCorr(self)
            try:
                Funciones.test_CrearInstancia(self,NombrePrueba,"cl-fm_20110430","Docs Fondos",corr)
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json") 
    
    def test_P2_SubirArchivoFondosFM(self):
        NombrePrueba = 'SubirArchivo taxo FM'
        if Funciones.FondosFM=="SI":
            try:
                Funciones.test_SubirArchivo(self,NombrePrueba,"FondosFM")
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
#FinFondos FM

#Editar Instancia
    def test_Q1_EditarInstancias(self):
        NombrePrueba = 'EditarInstancias'
        if Funciones.EditarInstancias=="SI":
            corr=Funciones.RescataCorr(self)
            try:
                Funciones.test_CrearInstancia(self,NombrePrueba,"Holding Bancario","Docs Financieros",corr)
                Funciones.BuscarInstanciaCheck(self,f'Holding Bancario {corr}','Editar')            
                Funciones.EditarInstancia(self,f'{corr} Holding Bancario ')
            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json", "INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json") 

#Fin Editar Instancia

#CopiaTextos
    def test_A2_MantenedorTextos(self):
        NombrePrueba = 'MantenedorTextos'
        if Funciones.MantenedorTextos=="SI":
            corr=Funciones.RescataCorr(self)
            try:
                #Revisar si ya esta Editada 
                Funciones.BuscarInstanciaCheck(self,'Holding Bancario 157','ManTextos')
                Funciones.RevisarTextosAntesdeCrear(self,NombrePrueba,'Holding Bancario 157',3)
                Funciones.BuscarInstanciaCheck(self,'Holding Seguro 157','ManTextos')
                Funciones.RevisarTextosAntesdeCrear(self,NombrePrueba,'Holding Seguro 157',3)

                #Crea Instancia y GeneraTextos
                Funciones.test_CrearInstancia(self,NombrePrueba,"Holding Bancario","Docs Financieros",corr)
                Funciones.BuscarInstanciaCheck(self,f'Holding Bancario {corr}','ManTextos')
                Funciones.AgregarTextos(self,NombrePrueba,3)
                Funciones.test_CrearInstancia(self,NombrePrueba,"Holding Seguro","Docs Financieros",corr)
                #Copia Textos
                Funciones.test_CopiaConfiguracionTextos(self,NombrePrueba,f'Holding Bancario {corr}',f'Holding Seguro {corr}')
                Funciones.BuscarInstanciaCheck(self,f'Holding Seguro {corr}','ManTextos')

            except Exception as e:
                Funciones.logINFO(f"Error {NombrePrueba}: {str(e)}", "ERROR")
                self.fail(f"Error {NombrePrueba}: {str(e)}")
        else:
            Funciones.logINFO(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json","INFO")
            print(f"No se ejecutara prueba {NombrePrueba} Segun Configuracion Config.json")
#Fin CopiaTextos

    def test_Z1_CerrarSesion(self): 
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
    suite = unittest.TestLoader().loadTestsFromTestCase(TestGX)
    corredor = unittest.TextTestRunner()
    resultados = corredor.run(suite)
    print(resultados)
