using ozdilekteyim.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ozdilekteyim.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ozdilekteyim
{
    public class Brands
    {
        public void brand_added()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.ozdilekteyim.com/shop/OHBrandLandingView?catalogId=10092&langId=-13&storeId=10153");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            IReadOnlyCollection<IWebElement> Brandis = driver.FindElements(By.XPath("//*[@id='contentWrapper']/div[2]/div/div/div[2]/div"));

            List<Brand> brand = new List<Brand>();

            foreach (IWebElement Brandi in Brandis)
            {

          
                IReadOnlyCollection<IWebElement> Brandi2 = Brandi.FindElements(By.XPath("div[2]/nav/ul/li/ul/li"));

                
                foreach (IWebElement Brandii in Brandi2)
                {

                    IWebElement Brandi2i = Brandii.FindElement(By.XPath("ul/li/a"));
                    

                    string brandURL = Brandi2i.GetAttribute("href");


                    string ka = Brandi2i.GetAttribute("innerHTML");
                   
                    Regex r = new Regex(@".*Q&manufacturer=(?<katCode>.*?)&sType");

                    string brandCode = null;
                    if (r.Match(brandURL).Success)
                    {
                        brandCode = r.Match(brandURL).Groups["katCode"].Value;
                    }


                    Brand branda = new Brand();
                    branda.Name = ka;
                    branda.State = true;
                    branda.Address = brandURL;
                    branda.Source = 2;//özdilekteyim
                    branda.Description = brandCode;
                    Console.WriteLine(ka);
                    Console.WriteLine(brandURL);
                    Console.WriteLine(brandCode);
                    using (var context = new ProductContext())
                    {
                        context.Brands.AddRange(branda);

                        context.SaveChanges();
                    }

                }





            }

        }

    }
}
