using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Runtime.InteropServices;

namespace netcore6_GX
{
    public class FuncionesWebs
    {
        public static int IniciarSesion(IWebDriver driver)
        {
            int Corrinst = 0;
            try
            {
                string Usuario = LeerJson.Usuario;
                string Pass = LeerJson.LoginPass;
                Thread.Sleep(2000);

                IWebElement usuarioInput = driver.FindElement(By.Name("usuario"));
                usuarioInput.SendKeys(Usuario);

                IWebElement passwordInput = driver.FindElement(By.Name("password"));
                passwordInput.SendKeys(Pass);

                Thread.Sleep(1000);
                //String foto = UtilReporte.screenshotretorno(driver, "Ingresar Datos");
                //ReporteTC.Pass("Ingresar Datos ", foto);
                IWebElement loginButton = driver.FindElement(By.CssSelector(".k-button-solid-primary > .k-button-text"));
                loginButton.Click();
                Thread.Sleep(8000);
                Empresa_de_Pruebas(driver);
                Corrinst = ObtenerEnteroElemento(driver, "/html/body/div/div/div[2]/div/div/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[1]/td[1]", 10);
                Thread.Sleep(1000);
                //Console.WriteLine(h);

                //String foto1 = UtilReporte.screenshotretorno(driver, "inicio sesion");
                //ReporteTC.Pass("Ingreso Correcto", foto1);
                return Corrinst + 1;
            }
            catch (NoSuchElementException ex)
            {
                // Puedes registrar el error aquí si lo deseas
                Assert.Fail($"Error en el inicio de sesión: {ex.Message}");
                return Corrinst;
            }
            catch (Exception ex)
            {
                // Puedes registrar el error aquí si lo deseas
                Assert.Fail($"Error desconocido en el inicio de sesión: {ex.Message}");
                return Corrinst;
            }
        }
        public static void CerrarSesion(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//div[3]/div/div/button/span")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//li[2]/span/span")).Click();
                //String foto = UtilReporte.screenshotretorno(driver, "CerrarSesion");
                //ReporteTC.Pass("Cerrar Sesion", foto);
                Thread.Sleep(3000);

            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail($"Error en Cerrar sesión: {ex.Message}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error desconocido en Cerrar sesión: {ex.Message}");
            }
        }
        public static void Micuenta(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//div[3]/div/div/button/span")).Click();
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//li[1]/span/span")).Click();

            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail($"Error en Cerrar sesión: {ex.Message}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error desconocido en Cerrar sesión: {ex.Message}");
            }
        }
        public static string ExisteComponente(IWebDriver driver, string selector, int tiempoEsperaEnSegundos, string tipo, bool realizarClick = false)
        {
            try
            {
                // Crear una instancia de WebDriverWait
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tiempoEsperaEnSegundos));

                // Localizar el elemento basado en el tipo de selector
                By bySelector = tipo.ToUpper() switch
                {
                    "XPATH" => By.XPath(selector),
                    "CSS" => By.CssSelector(selector),
                    "ID" => By.Id(selector),
                _ => throw new ArgumentException($"Tipo de selector '{tipo}' no soportado."),
                };

                // Esperar hasta que el elemento esté presente y visible
                IWebElement elemento = wait.Until(drv =>
                {
                    try
                    {
                        IWebElement elem = drv.FindElement(bySelector);
                        return (elem != null && elem.Displayed) ? elem : null;
                    }
                    catch (StaleElementReferenceException)
                    {
                        // Manejar elementos obsoletos
                        Console.WriteLine("Elemento obsoleto, reintentando...");
                        return null;
                    }
                    catch (NoSuchElementException)
                    {
                        // Manejar caso donde el elemento no esté presente aún
                        Console.WriteLine("Elemento no encontrado, reintentando...");
                        return null;
                    }
                });

                // Si se encuentra el elemento
                if (elemento != null)
                {
                    string texto = elemento.Text;
                    Console.WriteLine($"Elemento encontrado: {texto}");

                    // Realizar clic si es necesario
                    if (realizarClick)
                    {
                        elemento.Click();
                        Console.WriteLine("Se realizó clic en el elemento.");
                    }

                    return texto;
                }

                Console.WriteLine("Elemento no visible o no encontrado.");
                return "Elemento no visible o no encontrado.";
            }
            catch (WebDriverTimeoutException)
            {
                // Manejo de excepción por tiempo agotado
                Console.WriteLine("Tiempo de espera agotado.");
                return "Tiempo de espera agotado.";
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otra excepción
                Console.WriteLine($"Error: {ex.Message}");
                return $"Error: {ex.Message}";
            }
        }







        public static string Bajar(IWebDriver driver, int veces)
        {
            int x = 0;
            while (x <= veces)
            {
                // Encuentra el elemento body y envía la tecla ARROW_DOWN
                driver.FindElement(By.TagName("body")).SendKeys(Keys.ArrowDown);

                x++;  // Incrementa x en 1 en cada iteración
            }

            // Espera 2 segundos

            Thread.Sleep(2000);
            return "Bajo";
        }

        public static int ObtenerEnteroElemento(IWebDriver driver, string xpath, int tiempoEsperaEnSegundos)
        {
            int Entero = 1;
            try
            {
                // Crear la instancia de WebDriverWait
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(tiempoEsperaEnSegundos));

                // Usar WebDriverWait con una función que devuelve el elemento cuando está presente
                IWebElement elementoTd = wait.Until(drv =>
                {
                    IWebElement element = drv.FindElement(By.XPath(xpath));
                    return element.Displayed ? element : null;
                });

                // Obtener el texto del elemento
                Entero = int.Parse(elementoTd.Text);
                return Entero;
            }
            catch (NoSuchElementException)
            {
                // Manejo de la excepción si el elemento no se encuentra
                Console.WriteLine("Elemento no encontrado.");
                return Entero;
            }
            catch (WebDriverTimeoutException)
            {
                // Manejo de la excepción si se agota el tiempo de espera
                Console.WriteLine("Tiempo de espera agotado.");
                return Entero;
            }
            catch (Exception ex)
            {
                // Manejo de otras excepciones
                Console.WriteLine($"Error: {ex.Message}");
                return Entero;
            }
        }

        public static string CrearInstancia(IWebDriver driver, string nombrePrueba, string nombreTaxo, string pantalla, int corrInst)
        {
            //Categoria  nombreTaxo-->(Comercio Industria,Seguro,Holding Bancario,Holding Seguro,Cajas Compensación,Entidades informantes,Bancos y Seguros)
            //Taxonomia Circular 2275  nombreTaxo -->(cs-im-2024-08-27,cs-im-2020-03-15)
            //Taxonomia fondos nombreTaxo -->(cl-iv_20110430 , cl-fm_20110430 , cl-fi_20110430 , cl-fc_20110606 , cl-cp_20110822)
            //pantalla --> Docs Fondos , Circular 2275  ,Docs Financieros
            corrInst = corrInst+1;
            try
            {
                ExisteComponente(driver, "//span[contains(text(),'Crear instancia')]", 1, "XPATH", true);
                Thread.Sleep(2000);
                ExisteComponente(driver, $"//label[contains(text(),'{pantalla}')]", 1, "XPATH", true);
                Thread.Sleep(2000);
                if (pantalla == "Docs Fondos")
                {
                    ExisteComponente(driver, "Año", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'2024')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "Periodo", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'1er Trimestre')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "Categoría", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'Taxo Fondos')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "taxonomia", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'{nombreTaxo}')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "Moneda", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'$$')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                }
                if (pantalla == "Circular 2275")
                {
                    ExisteComponente(driver, "Año", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'2024')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "Periodo", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'Enero')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "Categoría", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'cs-im-2024-08-27')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "taxonomia", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'{nombreTaxo}')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "Moneda", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'Pesos chilenos')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                }
                else if (pantalla == "Docs Financieros")
                {
                    ExisteComponente(driver, "Año", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'2024')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "Periodo", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'1er Trimestre')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "categoria", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'{nombreTaxo}')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "Taxonomía", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'svs-cl-ci-2024-01-02')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "Moneda", 1, "ID", true);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, $"//span[contains(text(),'Pesos chilenos')]", 1, "XPATH", true);
                    Thread.Sleep(2000);
                }

                // Ingresar la descripción
                driver.FindElement(By.Id("descripcion")).SendKeys($"{nombreTaxo} {corrInst}");

                // Hacer clic en las etiquetas
                ExisteComponente(driver, "//label[contains(text(),'Clasificado')]", 1, "XPATH", true);
                ExisteComponente(driver, "//label[contains(text(),'Directo')]", 1, "XPATH", true);
                ExisteComponente(driver, "//label[contains(text(),'Consolidado')]", 1, "XPATH", true);
                ExisteComponente(driver, "//label[contains(text(),'Por Función')]", 1, "XPATH", true);
                ExisteComponente(driver, "//label[contains(text(),'Neto de Impuesto')]", 1, "XPATH", true);
                Thread.Sleep(2000);
                // Simular la acción de bajar
                Bajar(driver, 20);
                Thread.Sleep(2000);
                //String foto = UtilReporte.screenshotretorno(driver, "AntesDeCrearInst");
                //ReporteTC.Pass("AntesDeCrearInst OK", foto);

                // Hacer clic en "Crear Instancia"
                ExisteComponente(driver, "button.k-button-solid-primary.k-rounded-md", 1, "CSS", true);
                Thread.Sleep(2000);
                //String foto1 = UtilReporte.screenshotretorno(driver, "DespuesDeCrearInst");
                //ReporteTC.Pass("Despues De Crear Inst", foto1);

                return "IsntanciaCreada";
            }
            catch (Exception e)
            {
                Assert.Fail($"Error {nombrePrueba}: {e.Message}");
                return "IsntanciaNoCreada";
            }
        }
        public static string GenerarXBRL(IWebDriver driver, string nombrePrueba, string nombreDirTaxo)
        {
            try
            {
                Thread.Sleep(4000);
                string CargaExitosa = ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr/td[2]/span", 1, "XPATH");//Revisar si la caraga esta disponible
                int N = 0;
                while (CargaExitosa != "Carga exitosa")
                {
                    if (CargaExitosa != "Carga exitosa")
                    {
                        CargaExitosa = ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr/td[2]/span", 1, "XPATH");//Revisar si la caraga esta disponible
                    }
                    if (CargaExitosa == "Carga exitosa")
                    {
                        N = 0;
                    }
                    if (CargaExitosa != "Carga exitosa")
                    {
                        CargaExitosa = ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[1]/td[2]/span", 1, "XPATH");//Revisar si la caraga esta disponible
                        if (CargaExitosa == "Carga exitosa")
                        {
                            N = 1;
                        }
                    }
                }
                if (N == 0)
                {
                    ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr/td[3]/div/div[1]/button", 10, "XPATH", true);//Boton Detalle carga
                    Thread.Sleep(2000);
                    //string foto1 = UtilReporte.screenshotretorno(driver, "DetalleCarga");
                    //ReporteTC.Pass("DetalleCarga", foto1);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "/html/body/div[2]/div[2]/div[3]/button", 10, "XPATH", true);//cerrar ver detalle Carga
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr/td[3]/div/div[2]/button", 10, "XPATH", true);//Boton Generar XBRL
                    Thread.Sleep(2000);
                    //string foto2 = UtilReporte.screenshotretorno(driver, "Generando XBRL");
                    //ReporteTC.Pass("Generando XBRL", foto2);
                    string GeneXBRLExitosa = ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr/td[4]/span", 10, "XPATH");//Esperar Ver detalle XBRL
                    while (GeneXBRLExitosa != "Generación exitosa")
                    {

                        if (CargaExitosa != "Generación exitosa")
                        {
                            GeneXBRLExitosa = ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr/td[4]/span", 10, "XPATH", true);
                        }
                    }
                    ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr/td[5]/div[1]/button", 10, "XPATH", true);
                    Thread.Sleep(2000);
                    //string foto4 = UtilReporte.screenshotretorno(driver, "Ver detalle XBRL");
                    //ReporteTC.Pass("Ver detalle XBRL", foto4);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "/html/body/div[2]/div[2]/div[3]/button", 10, "XPATH", true);//cerrar ver detalle XBRL
                    Thread.Sleep(60000);
                    ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr/td[5]/div[2]/button", 10, "XPATH", true);//Ver HTML Se debe esperar ya que este boton esta disponible pero aun se esta generando el HTML
                    Thread.Sleep(10000);
                    //string foto5 = UtilReporte.screenshotretorno(driver, "Ver HTML");
                    //ReporteTC.Pass("Ver HTML", foto5);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "/html/body/div[2]/div[2]/div[2]/button", 10, "XPATH", true);//cerrar ver HTML
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr/td[5]/div[3]/button", 10, "XPATH", true);//Boton Descarga XBRL
                    Thread.Sleep(2000);
                    //string foto6 = UtilReporte.screenshotretorno(driver, "DetallesDescargaXBRL");
                    //ReporteTC.Pass("Detalles Descarga XBRL", foto6);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "/html/body/div[2]/div[2]/div[3]/button[2]/span", 10, "XPATH", true);//Boton que si descarga el XBRL
                    Thread.Sleep(10000);
                    //GuardarArchivo(nombreDirTaxo);
                    Thread.Sleep(10000);
                    ExisteComponente(driver, "/html/body/div[2]/div[2]/div[3]/button[1]/span", 10, "XPATH", true);//Cerrar descarga  XBRL
                }
                else
                {
                    ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[1]/td[3]/div/div[1]/button", 10, "XPATH", true);//Boton Detalle carga
                    Thread.Sleep(2000);
                    //string foto1 = UtilReporte.screenshotretorno(driver, "DetalleCarga");
                    //ReporteTC.Pass("DetalleCarga", foto1);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "/html/body/div[2]/div[2]/div[3]/button", 10, "XPATH", true);//cerrar ver detalle Carga
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[1]/td[3]/div/div[2]/button", 10, "XPATH", true);//Boton Generar XBRL
                    Thread.Sleep(2000);
                    //string foto2 = UtilReporte.screenshotretorno(driver, "Generando XBRL");
                    //ReporteTC.Pass("Generando XBRL", foto2);
                    string GeneXBRLExitosa = ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr/td[4]/span", 10, "XPATH");//Esperar Ver detalle XBRL

                    while (GeneXBRLExitosa != "Generación exitosa")
                    {
                        if (GeneXBRLExitosa != "Generación exitosa")
                        {
                            GeneXBRLExitosa = ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[1]/td[4]/span", 10, "XPATH", true);
                        }
                    }
                    ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[1]/td[5]/div[1]/button", 10, "XPATH", true);
                    Thread.Sleep(2000);
                    //string foto4 = UtilReporte.screenshotretorno(driver, "Ver detalle XBRL");
                    //ReporteTC.Pass("Ver detalle XBRL", foto4);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "/html/body/div[2]/div[2]/div[3]/button", 10, "XPATH", true);//cerrar ver detalle XBRL
                    Thread.Sleep(60000);

                    ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[1]/td[5]/div[2]/button", 10, "XPATH", true);//Ver HTML Se debe esperar ya que este boton esta disponible pero aun se esta generando el HTML
                    Thread.Sleep(10000);
                    //string foto5 = UtilReporte.screenshotretorno(driver, "Ver HTML");
                    //ReporteTC.Pass("Ver HTML", foto5);
                    Thread.Sleep(2000);
                    //ExisteComponente(driver, "/html/body/div[2]/div[2]/div[2]/button", 10, "XPATH", "Click");//cerrar ver HTML
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[1]/td[5]/div[3]/button", 10, "XPATH", true);//Boton Descarga XBRL
                    Thread.Sleep(2000);
                    //string foto6 = UtilReporte.screenshotretorno(driver, "DetallesDescargaXBRL");
                    //ReporteTC.Pass("Detalles Descarga XBRL", foto6);
                    Thread.Sleep(2000);
                    ExisteComponente(driver, "/html/body/div[2]/div[2]/div[3]/button[2]/span", 10, "XPATH", true);//Boton que si descarga el XBRL
                    Thread.Sleep(10000);
                    //GuardarArchivo(nombreDirTaxo);
                    Thread.Sleep(10000);
                    ExisteComponente(driver, "/html/body/div[2]/div[2]/div[3]/button[1]/span", 10, "XPATH", true);//Cerrar descarga  XBRL

                }
                return "CargarTaxonomia";
            }
            catch (Exception e)
            {
                Assert.Fail($"Error {nombrePrueba}: {e.Message}");
                return "CargarTaxonomia";
            }
        }


        // P/Invoke para interactuar con ventanas
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        // Constantes para mensajes de ventana
        private const uint WM_SETTEXT = 0x000C; // Establecer texto
        private const uint BM_CLICK = 0x00F5;  // Simular clic en un botón
        public static IntPtr FindWindowByTitle(string windowTitle)
        {
            // Busca la ventana principal con el título especificado
            IntPtr hWnd = FindWindow(null, windowTitle);
            if (hWnd == IntPtr.Zero)
            {
                Console.WriteLine("No se encontró la ventana con el título especificado.");
            }
            return hWnd;
        }

        public static IntPtr FindChildWindow(IntPtr parentHandle, string childTitle)
        {
            // Busca una ventana hija dentro de la ventana principal
            IntPtr childHandle = FindWindowEx(parentHandle, IntPtr.Zero, null, childTitle);
            if (childHandle == IntPtr.Zero)
            {
                Console.WriteLine("No se encontró la ventana hija con el título especificado.");
            }
            return childHandle;
        }

        public static string GuardarArchivo(string taxo)
        {
            string Ruta = LeerJson.RutaRaiz;
            try
            {
                // Crear directorio si no existe
                string taxoDir = Path.Combine(Ruta, "Descargas", taxo);
                if (!Directory.Exists(taxoDir))
                {
                    Directory.CreateDirectory(taxoDir);
                    Console.WriteLine($"Carpeta creada: {taxoDir}");
                }
                else
                {
                    Console.WriteLine($"La carpeta ya existe: {taxoDir}");
                }

                // Encuentra la ventana "Guardar como"
                IntPtr saveDialog = FindWindowByTitle("Guardar como");
                if (saveDialog == IntPtr.Zero)
                {
                    throw new Exception("No se pudo encontrar la ventana 'Guardar como'.");
                }

                // Encuentra el cuadro de texto "Nombre de archivo"
                IntPtr fileNameEdit = FindWindowEx(saveDialog, IntPtr.Zero, "Edit", null);
                if (fileNameEdit == IntPtr.Zero)
                {
                    throw new Exception("No se pudo encontrar el cuadro de texto 'Nombre de archivo'.");
                }

                // Especifica el nombre del archivo y la ruta
                string savePath = Path.Combine(taxoDir, "archivo_guardado.txt");
                SendMessage(fileNameEdit, WM_SETTEXT, IntPtr.Zero, savePath);
                Console.WriteLine($"Ruta establecida en el cuadro de texto: {savePath}");

                // Encuentra el botón "Guardar" y haz clic
                IntPtr saveButton = FindWindowEx(saveDialog, IntPtr.Zero, "Button", "Guardar");
                if (saveButton == IntPtr.Zero)
                {
                    throw new Exception("No se pudo encontrar el botón 'Guardar'.");
                }
                PostMessage(saveButton, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
                Console.WriteLine("Se hizo clic en el botón 'Guardar'.");

                // Espera un momento para asegurar que el archivo se guarde
                System.Threading.Thread.Sleep(2000);
                return "Archivo guardado con éxito";
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al guardar el archivo: {e.Message}");
                return "Error al guardar el archivo";
            }
        }

        public static string CargarTaxonomia(IWebDriver driver, string nombrePrueba, string nombreDirTaxo)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                ExisteComponente(driver, "//tr[1]/td[6]/div[2]/button/span/span", 10, "XPATH", true);
                Thread.Sleep(2000);
                // Subir archivo
                IWebElement inputArchivo = driver.FindElement(By.XPath("//input[@type='file']"));
                string directorioActual = AppDomain.CurrentDomain.BaseDirectory;
                string rutaArchivoRelativa = Path.Combine(directorioActual, "taxos", nombreDirTaxo, "xls.zip");
                Thread.Sleep(2000);
                inputArchivo.SendKeys(rutaArchivoRelativa);
                Thread.Sleep(2000);

                // Seleccionar todos los archivos si corresponde
                if (new[] { "BS", "CC", "CI", "HB", "HS" }.Contains(nombreDirTaxo))
                {
                    driver.FindElement(By.XPath("//label[contains(text(),'Seleccionar todos')]")).Click();
                }
                // Llamar al método Bajar
                Bajar(driver, 20);
                Thread.Sleep(3000);
                //String foto = UtilReporte.screenshotretorno(driver, "AntesdeSubirArchivo");
                //ReporteTC.Pass("Antes de Subir Archivo", foto);
                // Hacer clic en el botón "Subir Documento"
                if (nombreDirTaxo == "CS")
                {
                    driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div[2]/div/form/div/div[7]/div/button/span")).Click();
                }
                else
                {
                    driver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div/div[2]/div/form/div/div[8]/div/button/span")).Click();
                }

                //String foto1 = UtilReporte.screenshotretorno(driver, "SubirArchivo");
                //ReporteTC.Pass("SubirArchivo", foto1);
                Thread.Sleep(2000);
                return "SubirArchivo";
            }
            catch (Exception e)
            {
                Assert.Fail($"Error {nombrePrueba}: {e.Message}");
                return "SubirArchivo";
            }
        }


        public static string VerDescargasL(IWebDriver driver, string nombrePrueba, string nombreDirTaxo)
        {
            try
            {
                Thread.Sleep(4000);
                driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[1]/td[7]/button")).Click();

                Thread.Sleep(4000);
                ExisteComponente(driver, "/html/body/div/div/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[1]/td[5]/div[3]/button", 10, "XPATH", true);//Boton Descarga XBRL
                Thread.Sleep(2000);
                Thread.Sleep(2000);
                ExisteComponente(driver, "/html/body/div[2]/div[2]/div[3]/button[2]/span", 10, "XPATH", true);//Boton que si descarga el XBRL
                Thread.Sleep(10000);
                //GuardarArchivo(nombreDirTaxo);
                Thread.Sleep(10000);
                ExisteComponente(driver, "/html/body/div[2]/div[2]/div[3]/button[1]/span", 10, "XPATH", true);//Cerrar descarga  XBRL
                return "CargarTaxonomia";
            }

            catch (Exception e)
            {
                Assert.Fail($"Error {nombrePrueba}: {e.Message}");
                return "CargarTaxonomia";
            }
        }
        public static void NecesitoAyuda(IWebDriver driver, string nombrePrueba)
        {
            try
            {
                // Esperar 2 segundos
                Thread.Sleep(2000);

                // Hacer clic en el botón
                IWebElement button = driver.FindElement(By.XPath("/html/body/div/div/div[1]/div/div[3]/button/span/span"));
                button.Click();

                // Esperar 5 segundos
                Thread.Sleep(5000);

                // Tomar captura de pantalla
                //string foto1 = UtilReporte.screenshotretorno(driver, "NecesitoAyuda");
                //ReporteTC.Pass("NecesitoAyuda", foto1);
                Thread.Sleep(3000);
                // Volver a la página anterior
                CloseNewWindow(driver);

                // Esperar 5 segundos
                Thread.Sleep(8000);
                driver.Navigate().Refresh();
                Thread.Sleep(2000);
                //string foto2 = UtilReporte.screenshotretorno(driver, "VolverInstancias");
                //ReporteTC.Pass("VolverInstancias", foto2);
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                // Fallar el test (en NUnit, usar Assert.Fail)
                throw new Exception($"Error {nombrePrueba}: {e.Message}");
            }
        }
        public static void CloseNewWindow(IWebDriver driver)
        {
            // Guarda el manejo de la ventana original
            string originalWindow = driver.CurrentWindowHandle;

            // Espera a que se abra una nueva ventana
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.WindowHandles.Count > 1);

            // Encuentra la nueva ventana
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != originalWindow)
                {
                    // Cambia al nuevo manejo de ventana
                    driver.SwitchTo().Window(windowHandle);
                    Console.WriteLine("Cambiado a la nueva ventana.");

                    // Cierra la ventana
                    driver.Close();
                    Console.WriteLine("Nueva ventana cerrada.");

                    // Regresa a la ventana original
                    driver.SwitchTo().Window(originalWindow);
                    Console.WriteLine("Regresado a la ventana original.");
                    break;
                }
            }
        }

        public static void CambioEmpresa(IWebDriver driver, string nombrePrueba)
        {
            try
            {
                // Esperar 2 segundos
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//div[3]/span/span")).Click();
                // Hacer clic en el botón
                Thread.Sleep(2000);
                BorrarContenido(driver, 50, "//input");
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input")).SendKeys("ADMINISTRADORA GRAL DE FONDOS SURA S.A");
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input")).SendKeys(Keys.Enter);
                Thread.Sleep(2000);
                //string foto1 = UtilReporte.screenshotretorno(driver, "OtraEmpresa");
                //ReporteTC.Pass("OtraEmpresa", foto1);
                // Esperar 5 segundos
                Thread.Sleep(5000);
                driver.FindElement(By.XPath("//div[3]/span/span")).Click();
                Thread.Sleep(2000);
                BorrarContenido(driver, 50, "//input");
                Thread.Sleep(2000); // Esperar 2 segundos
                driver.FindElement(By.XPath("//input")).SendKeys("Empresa de Prueba");
                // Ingresar el texto en el campo de entrada
                driver.FindElement(By.XPath("//input")).SendKeys(Keys.Enter);
                Thread.Sleep(6000); // Esperar 5 segundos
                                    // Tomar una captura de pantalla
                                    //string foto2 = UtilReporte.screenshotretorno(driver, "VolverEmpresa");
                                    //ReporteTC.Pass("VolverEmpresa", foto2);
                //Thread.Sleep(5000); // Esperar 10 segundos
            }
            catch (Exception e)
            {
                // Fallar el test (en NUnit, usar Assert.Fail)
                throw new Exception($"Error {nombrePrueba}: {e.Message}");
            }
        }
        private static void BorrarContenido(IWebDriver driver, int Veces, string XPath)
        {
            // Alternativa 1: Usar un bucle para enviar la tecla BACKSPACE repetidamente
            for (int i = 0; i < Veces; i++)
            {
                driver.FindElement(By.XPath(XPath)).SendKeys(Keys.Backspace);
            }
        }
        public static void Empresa_de_Pruebas(IWebDriver driver)
        {
            try
            {
                // Esperar 2 segundos
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//div[3]/span/span")).Click();
                // Hacer clic en el botón
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input")).SendKeys("Empresa de Prueba");
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//input")).SendKeys(Keys.Enter);
                Thread.Sleep(2000);
            }
            catch (Exception e)
            {
                // Fallar el test (en NUnit, usar Assert.Fail)
                throw new Exception($"Error en Cambio Empresa de pruebas: {e.Message}");
            }
        }

        public static void ParametrosEmpresa(IWebDriver driver, string nombrePrueba)
        {
            try
            {
                Mantenedores(driver, "Parámetros de empresa");
                if (PresionarBotonEditar(driver, "ParametroQAEmpr") == true)
                {
                    EliminarParametro(driver);
                }
                driver.Navigate().Refresh();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//span[contains(.,\'Crear Parámetro\')]")).Click();

                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input[@id=\'CodiPaem\']")).SendKeys("ParametroQAEmpr");

                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input[@id=\'DescPaem\']")).SendKeys("22222");

                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input[@id=\'ValoPaem\']")).SendKeys("33333");

                Thread.Sleep(2000);
                //string foto1 = UtilReporte.screenshotretorno(driver, "CrearParametro");
                //ReporteTC.Pass("Crear Parametro", foto1);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/form/div[4]/button[2]/span")).Click();

                Thread.Sleep(9000);
                driver.Navigate().Refresh();
                Thread.Sleep(2000);
                PresionarBotonEditar(driver, "ParametroQAEmpr");
                Thread.Sleep(2000);

                BorrarContenido(driver, 10, "//input[@id=\'DescPaem\']");
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input[@id=\'DescPaem\']")).SendKeys("4444");
                Thread.Sleep(2000);
                BorrarContenido(driver, 10, "//input[@id=\'ValoPaem\']");
                driver.FindElement(By.XPath("//input[@id=\'ValoPaem\']")).SendKeys("55555");
                Thread.Sleep(2000);
                //string foto2 = UtilReporte.screenshotretorno(driver, "EditarParametro");
                //ReporteTC.Pass("Editar Parametro", foto2);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/form/div[5]/button[2]")).Click();
                Thread.Sleep(2000);
                driver.Navigate().Refresh();
                Thread.Sleep(2000);
                if (PresionarBotonEditar(driver, "ParametroQAEmpr") == true)
                {
                    EliminarParametro(driver);
                }
;
                //string foto4 = UtilReporte.screenshotretorno(driver, "PruebaParametros");
                //ReporteTC.Pass("Prueba Parametros", foto4);*/

            }
            catch (Exception e)
            {
                // Fallar el test (en NUnit, usar Assert.Fail)
                throw new Exception($"Error {nombrePrueba}: {e.Message}");
            }
        }
      

        public static void Mantenedores(IWebDriver driver, string Mantenedor)
        {
            try
            {
                driver.FindElement(By.XPath("//span[contains(.,\'Mantenedores\')]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath($"//*[text()='{Mantenedor}']")).Click();
                //driver.FindElement(By.XPath("//li[1]/span/div")).Click();
                Thread.Sleep(2000);
                // Posible valores  (Parámetros generales, Parámetros de empresa, Mantenedor usuarios,Mantenedor empresas)
            }
            catch (NoSuchElementException)
            {
                // Manejar el caso cuando se agotan las filas o no se encuentra el elemento
                Console.WriteLine("No se encontraron más filas en la tabla.");

            }
            catch (Exception e)
            {
                // Manejar otros tipos de errores
                Console.WriteLine($"Error al buscar el parámetro: {e.Message}");

            }
        }

        public static void Herramientas(IWebDriver driver, string Herramientas)
        {
            try
            {
                driver.FindElement(By.XPath("//span[contains(.,\'Herramientas\')]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath($"//*[text()='{Herramientas}']")).Click();
                //driver.FindElement(By.XPath("//li[1]/span/div")).Click();
                Thread.Sleep(2000);
                // Posible valores  (Copia configuración de textos, Consulta conceptos)
            }
            catch (NoSuchElementException)
            {
                // Manejar el caso cuando se agotan las filas o no se encuentra el elemento
                Console.WriteLine("No se encontraron más filas en la tabla.");

            }
            catch (Exception e)
            {
                // Manejar otros tipos de errores
                Console.WriteLine($"Error al buscar el parámetro: {e.Message}");

            }
        }

        public static void MantenedorUsuarios(IWebDriver driver, string nombrePrueba)
        {
            try
            {
                Mantenedores(driver, "Mantenedor usuarios");
                /*
                if (PresionarBotonEditar(driver, "ParametroQAGene") == true)
                {
                    EliminarParametro(driver);
                }
                driver.Navigate().Refresh();

                if (PresionarBotonEditar(driver, "ParametroQAGene") == true)
                {
                    EliminarParametro(driver);
                }

                //string foto4 = UtilReporte.screenshotretorno(driver, "PruebaParametros");
                //ReporteTC.Pass("Prueba Parametros", foto4);*/

            }
            catch (Exception e)
            {
                // Fallar el test (en NUnit, usar Assert.Fail)
                throw new Exception($"Error {nombrePrueba}: {e.Message}");
            }
        }
        public static void MantenedorEmpresas(IWebDriver driver, string nombrePrueba)
        {
            try
            {
                Mantenedores(driver, "Mantenedor empresas");
                /*
                if (PresionarBotonEditar(driver, "ParametroQAGene") == true)
                {
                    EliminarParametro(driver);
                }
                driver.Navigate().Refresh();
               
                if (PresionarBotonEditar(driver, "ParametroQAGene") == true)
                {
                    EliminarParametro(driver);
                }

                //string foto4 = UtilReporte.screenshotretorno(driver, "PruebaParametros");
                //ReporteTC.Pass("Prueba Parametros", foto4);*/

            }
            catch (Exception e)
            {
                // Fallar el test (en NUnit, usar Assert.Fail)
                throw new Exception($"Error {nombrePrueba}: {e.Message}");
            }
        }
    

        public static void ParametrosGenerales(IWebDriver driver, string nombrePrueba)
        {
            try
            {
                Mantenedores(driver, "Parámetros generales");
                if (PresionarBotonEditar(driver, "ParametroQAGene")==true)
                {
                    EliminarParametro(driver);
                }
                driver.Navigate().Refresh();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//span[contains(.,\'Crear Parámetro\')]")).Click();

                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input[@id=\'ParamName\']")).SendKeys("ParametroQAGene");

                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input[@id=\'ParamDesc\']")).SendKeys("22222");

                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input[@id=\'ParamValue\']")).SendKeys("33333");

                Thread.Sleep(2000);
                //string foto1 = UtilReporte.screenshotretorno(driver, "Crear Parametro General");
                //ReporteTC.Pass("Crear Parametro General", foto1);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/form/div[4]/button[2]/span")).Click();

                Thread.Sleep(5000);
                driver.Navigate().Refresh();

                Thread.Sleep(2000);
                
                Bajar(driver,20);
                PresionarBotonEditar(driver, "ParametroQAGene");
                Thread.Sleep(2000);
                BorrarContenido(driver, 10, "//input[@id=\'ParamDesc\']");
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//input[@id=\'ParamDesc\']")).SendKeys("44444");
                Thread.Sleep(2000);
                BorrarContenido(driver, 10, "//input[@id=\'ParamValue\']");
                driver.FindElement(By.XPath("//input[@id=\'ParamValue\']")).SendKeys("55555");
                Thread.Sleep(2000);
                //string foto2 = UtilReporte.screenshotretorno(driver, "EditarParametro");
                //ReporteTC.Pass("Editar Parametro", foto2);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/form/div[5]/button[2]")).Click();
                Thread.Sleep(2000);
                driver.Navigate().Refresh();
                Thread.Sleep(2000);
                Bajar(driver, 20);
                if (PresionarBotonEditar(driver, "ParametroQAGene") == true)
                {
                    EliminarParametro(driver);
                }

                //string foto4 = UtilReporte.screenshotretorno(driver, "PruebaParametros");
                //ReporteTC.Pass("Prueba Parametros", foto4);

            }
            catch (Exception e)
            {
                // Fallar el test (en NUnit, usar Assert.Fail)
                throw new Exception($"Error {nombrePrueba}: {e.Message}");
            }
        }
        public static bool PresionarBotonEditar(IWebDriver driver, string variableObjetivo)
        {
            while (true) // Continuar mientras haya páginas
            {
                try
                {
                    // Localizar todas las filas de la tabla
                    var filas = driver.FindElements(By.CssSelector("table tbody tr"));

                    // Iterar sobre cada fila
                    for (int i = 1; i <= filas.Count; i++)
                    {
                        // Construir el selector para obtener el texto de la celda de la columna "Parámetro"
                        string selectorParametro = $"table tbody tr:nth-child({i}) td:nth-child(2)";

                        // Obtener el texto de la celda
                        string textoCelda = driver.FindElement(By.CssSelector(selectorParametro)).Text;

                        // Verificar si coincide con la variable objetivo
                        if (textoCelda == variableObjetivo)
                        {
                            // Localizar el botón "Editar" en esa fila y hacer clic
                            string selectorBotonEditar = $"table tbody tr:nth-child({i}) td:nth-child(5) button";
                            driver.FindElement(By.CssSelector(selectorBotonEditar)).Click();

                            return true; // Devolver true si se encontró y se hizo clic
                        }
                    }                  

                    string Presionado = PáginaSiguiente(driver);
                    if (Presionado != "Presionado")
                    {
                        return false;
                    }
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }


        public static string PáginaSiguiente(IWebDriver driver)
        {
            try
            {
                // Intentar encontrar y hacer clic en el botón "Siguiente"
                IWebElement botonSiguiente = driver.FindElement(By.CssSelector("button[title='Ir a la página siguiente']"));
                 

                    if (botonSiguiente.Enabled)
                    {
                        botonSiguiente.Click();
                        Console.WriteLine("Cambiando a la página siguiente...");
                        System.Threading.Thread.Sleep(2000); // Ajusta el tiempo según sea necesario
                    return "Presionado";
                }
                    else
                    {
                        Console.WriteLine("No se puede avanzar a la página siguiente. Finalizando búsqueda.");
                    return "NoPresionado";

                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No hay más páginas disponibles. Finalizando búsqueda.");
                return "NoPresionado";

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                return "NoPresionado";

            }
        }
        public static string EliminarParametro(IWebDriver driver)
        {
            try
            {
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div[2]/form/div[4]/button")).Click();

                    Thread.Sleep(2000);
                    //string foto3 = UtilReporte.screenshotretorno(driver, "EliminarParametro");
                    //ReporteTC.Pass("Eliminar Parametro", foto3);
                    driver.FindElement(By.XPath("//span[@class='k-button-text' and text()='Eliminar']"));
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//div[2]/button[2]/span")).Click();
                    Thread.Sleep(5000);
                    return "Eliminado";
            }
            catch (Exception e)
            {
                if (e.Message.Contains("no such element"))
                {
                    Console.WriteLine("No se encontraron más filas en la tabla.");
                    return null;
                }
                else
                {
                    Console.WriteLine($"Error al buscar el parámetro: {e.Message}");
                    return null;
                }
            }
        }

    
    public static string BuscarinstanciaAccion(IWebDriver driver, string NombreInst, string Accion)
        {
            int valor = 1;

            while (true)
            {
                try
                {
                    // Ver si existe alguna instancia preguntando por la primera que exista
                    string xpathTd = $"/html/body/div/div/div[2]/div/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[{valor}]/td[2]";
                    string xpath = ExisteComponente(driver, xpathTd, 3, "XPATH");

                    if (valor == 10)
                    {
                        Bajar(driver, 20);
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("/html/body/div/div/div[2]/div/div[2]/div[2]/div/button[3]")).Click();
                        valor = 0;
                    }

                    if (xpath == NombreInst)
                    {
                        string botonXpath = string.Empty;
                        switch (Accion)
                        {
                            case "Editar":
                                botonXpath = $"/html/body/div/div/div[2]/div/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[{valor}]/td[6]/div[1]/button";
                                break;
                            case "Cargar":
                                botonXpath = $"/html/body/div/div/div[2]/div/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[{valor}]/td[6]/div[2]/button";
                                break;
                            case "ManTextos":
                                botonXpath = $"/html/body/div/div/div[2]/div/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[{valor}]/td[6]/div[3]/button";
                                break;
                            case "VerInstancia":
                                botonXpath = $"/html/body/div/div/div[2]/div/div[2]/div[1]/div[2]/div/div[1]/table/tbody/tr[{valor}]/td[7]/button";
                                break;
                        }

                        if (!string.IsNullOrEmpty(botonXpath))
                        {
                            ExisteComponente(driver, botonXpath, 3, "XPATH", true);
                            Thread.Sleep(3000);  // Esperar 3 segundos
                            return xpath;
                        }
                    }

                    Thread.Sleep(1000);  // Esperar 3 segundos
                    valor++;
                }
                catch (Exception e)
                {
                    // Manejar el caso cuando se agotan las filas o ocurre un error
                    if (e.Message.Contains("no such element"))
                    {
                        // No se encontró más filas en la tabla
                        Console.WriteLine("No se encontraron más filas en la tabla.");
                        return null;
                    }
                    else
                    {
                        // Manejar otros tipos de errores
                        Console.WriteLine($"Error al buscar el parámetro: {e.Message}");
                        return null;
                    }
                }
            }
        }
        public static string ConsultaConceptos(IWebDriver driver)//, string nombrePrueba, string tipoTaxo, string taxo, string buscar)
        {
            try
            {
                Herramientas(driver,"Consulta de conceptos");
                /*
                driver.FindElement(By.XPath("//span[contains(.,'Instancias')]")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//span[contains(.,'Herramientas')]")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//li[2]/span/span")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//form/div/div/div/div/div/span/span/span")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.XPath($"//span[contains(.,'{tipoTaxo}')]")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//span[@id='taxonomy']/button")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.XPath($"//i[contains(.,'{taxo}')]")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//button[contains(.,'Buscar')]")).Click();
                Thread.Sleep(2000);

                //string foto = UtilReporte.screenshotretorno(driver, "ConsultaConceptosPredeterminado");
                //ReporteTC.Pass($"Consulta Conceptos Predeterminado {tipoTaxo}", foto);
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//input[@id='concept']")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//input[@id='concept']")).SendKeys(buscar);
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//button[contains(.,'Buscar')]")).Click();
                Thread.Sleep(5000);

                //string foto1 = UtilReporte.screenshotretorno(driver, "ConsultaConceptosIngresado");
                //ReporteTC.Pass($"Consulta Conceptos Ingresado{tipoTaxo}", foto1);*/
                return "OK";

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al : {e.Message}");
                return null;
            }
        }

        public static string Copiaconfiguracióndetextos(IWebDriver driver)//, string nombrePrueba, string tipoTaxo, string taxo, string buscar)
        {
            try
            {
                Herramientas(driver, "Copia configuración de textos");

                return "OK";

            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al : {e.Message}");
                return null;
            }
        }
        public static string EditarInstancia(IWebDriver driver, string palabraNueva, string nombrePrueba)
        {
            try
            {
                driver.FindElement(By.XPath("//div[3]/div/div/div/span/span/span")).Click();
                Thread.Sleep(1000);

                driver.FindElement(By.XPath("//span[contains(.,'4to Trimestre')]")).Click();
                Thread.Sleep(1000);

                driver.FindElement(By.XPath("//body/div/div/div[2]")).Click();
                Thread.Sleep(1000);

                IWebElement descripcionElement = driver.FindElement(By.Id("descripcion"));
                descripcionElement.Clear();  // Limpia el campo antes de escribir la nueva palabra
                Thread.Sleep(1000);

                descripcionElement.SendKeys(palabraNueva);
                Thread.Sleep(1000);

                //string foto = UtilReporte.screenshotretorno(driver, "IngresaNuevoDetalle");
                //ReporteTC.Pass("Ingresa Nuevo Detalle", foto);
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//span[contains(.,'Actualizar Instancia')]")).Click();
                Thread.Sleep(2000);

                //string foto1 = UtilReporte.screenshotretorno(driver, "EditarInstancia");
                //ReporteTC.Pass("Editar Instancia", foto1);
                Thread.Sleep(5000);
                return "OK";
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al {nombrePrueba}: {e.Message}");
                return null;
            }
        }
    }

}