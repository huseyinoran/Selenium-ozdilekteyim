using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ozdilekteyim.Models;
using ozdilekteyim.Context;
using System.Net;

namespace ozdilekteyim
{
    public class DriverChrome
    {
        public void translateUrl(string TranslateURl)
        {
            //var options = new ChromeOptions();
            //options.AddArguments("headless");
            //IWebDriver driver = new ChromeDriver(options);

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(TranslateURl);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(5000);

            TranslateCategory translateCategory = new TranslateCategory();



            using (var contex = new ProductContext())
            {
                List<Category> GetAll = contex.Categories.Where(s => s.State == true).ToList();
                foreach (var item in GetAll)
                {
                    try
                    {
                        while (!CheckForInternetConnection())
                        {
                            Thread.Sleep(3000);
                        }
                        translateCategory.Translator(driver, item);
                        item.State = false;
                        contex.SaveChanges();
                    }
                    catch (Exception ex)
                    {

                        ExceptionLogging.SendErrorToText(ex);
                    }
                }
            }

        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
