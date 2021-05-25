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
    public class PullCategory
    {
        public void category_added()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.ozdilekteyim.com/shop/tr/bursahipermarket");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            IReadOnlyCollection<IWebElement> Categoryis = driver.FindElements(By.XPath("//*[@id='wc_widget_RefreshArea_0']/ul/li"));


            foreach (IWebElement Categoryi in Categoryis)
            {
            //Name
                IWebElement Categoryi2 = Categoryi.FindElement(By.XPath("a/span"));
                string ka = Categoryi2.GetAttribute("innerHTML");
                string value1 = ka;
                string value2 = value1.Replace("&amp;", "&");
                ka = value2;

             //Address

                string CategoryNameUrl = Categoryi.FindElement(By.TagName("A")).GetAttribute("href");

             //Description

                Regex r = new Regex(@".*bursahipermarket\/(?<katCode>.*?$)");

                string CategoryCode = null;
                if (r.Match(CategoryNameUrl).Success)
                {
                    CategoryCode = r.Match(CategoryNameUrl).Groups["katCode"].Value;
                }

                Category categorya = new Category();
                categorya.Name = ka;
                categorya.State = true;
                categorya.Source = 2;
                categorya.Address = CategoryNameUrl;
                categorya.Description = CategoryCode;

                Console.WriteLine(ka);
                Console.WriteLine(CategoryNameUrl);
                Console.WriteLine(CategoryCode);

                using (var context = new ProductContext())
                {
                    context.Categories.AddRange(categorya);

                    context.SaveChanges();
                }


            }

        }
        }
    }

