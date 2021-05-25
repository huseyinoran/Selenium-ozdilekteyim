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
    public class PullingProductAddressInCategory
    {
        public void katpro(string katurl, int i = 0)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(katurl);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            IReadOnlyCollection<IWebElement> LİstProduct = driver.FindElements(By.XPath("//*[@id='dijit__WidgetBase_1']/li"));

            foreach (IWebElement LİstProductone in LİstProduct)
            {
                IWebElement katname = LİstProductone.FindElement(By.ClassName("product-card-image"));

                string urunurl = katname.GetAttribute("href");

                ProductAddress productAddress = new ProductAddress();
                productAddress.State = true;
                productAddress.Path = urunurl;
                Console.WriteLine(urunurl);

                using (var context = new ProductContext())
                {
                    context.ProductAddresses.AddRange(productAddress);

                    context.SaveChanges();
                }
            }

                bool c = true;

                try
                {

                    driver.FindElement(By.ClassName("showMoreButton"));

                }
                catch (Exception)
                {
                    c = false;
                }
                if (c)
                {
                    i = i + 36;
                    string nextpage = katurl + "#facet:&productBeginIndex:" + i + "&orderBy:12&pageView:&minPrice:&maxPrice:&pageSize:&";
                    driver.Close();
                    this.katpro(nextpage, i);
                }
                else
                {
                    Console.WriteLine("Kategori" + i + "urun");
                }
            }


            

        }



            }
        
    
