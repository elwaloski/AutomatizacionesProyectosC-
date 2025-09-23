using Metodos;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuiteElectronica62
{
    public class Login
    {
        const string TXT_USER = "p_Usuario";
        const string TXT_PASSWORD = "p_Clave";
        const string FORM_LOGIN = "frm_login";
        const string LI_DASHBOARD = "//li[normalize-space()='Dashboard']";

        public static bool RealizarLogin(IWebDriver driver, string usuario, string password)
        {
            try
            {
                driver.FindElement(By.Id(TXT_USER)).SendKeys(usuario);
                driver.FindElement(By.Id(TXT_PASSWORD)).SendKeys(password);

                driver.FindElement(By.Name(FORM_LOGIN)).Submit();
                Thread.Sleep(3000);

                driver.FindElement(By.XPath(LI_DASHBOARD)); //no es necesario el if, ya que si el webdriver no encuentra el elemento entra al catch
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
