using ozdilekteyim.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ozdilekteyim.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;

namespace ozdilekteyim
{
    public class BrandsInProducts
    {
        public void BrandsInProducts_added(string brandUrlPath, int i = 0)
        {
            var options = new ChromeOptions();
            options.AddArguments("headless");
            IWebDriver driver = new ChromeDriver(options);

            //IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(brandUrlPath);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);
            var contex = new ProductContext();

            IReadOnlyCollection<IWebElement> BrandsInProductsPath = driver.FindElements(By.XPath("//*[@id='dijit__WidgetBase_1']/li"));

            List<ProductsInBrands> productsInBrands = new List<ProductsInBrands>();

            foreach (IWebElement BrandsInProductsPathi in BrandsInProductsPath)
            {

                IWebElement forproducturl = BrandsInProductsPathi.FindElement(By.XPath("div[2]/div[1]/div/a"));

                string productURL = forproducturl.GetAttribute("href");
                string productbarcode = forproducturl.FindElement(By.TagName("img")).GetAttribute("SRC");

                Console.WriteLine(productURL);
                Console.WriteLine(productbarcode);

                Regex r = new Regex(@".*\/(?<katCode>.*?)\.");

                string proCode = null;
                if (r.Match(productbarcode).Success)
                {
                    proCode = r.Match(productbarcode).Groups["katCode"].Value;
                }

                Regex r2 = new Regex(@".*Q&manufacturer=(?<brandCode>.*?)&sType");

                string brandCode2 = null;
                if (r2.Match(brandUrlPath).Success)
                {
                    brandCode2 = r2.Match(brandUrlPath).Groups["brandCode"].Value;
                }
                Brand brandbul = contex.Brands.FirstOrDefault(o => o.Description == brandCode2);

                ProductsInBrands productsInBrands1 = new ProductsInBrands();
                productsInBrands1.ProductAddress = productURL;
                productsInBrands1.ProductBarcode = proCode;
                productsInBrands1.BrandID = brandbul.ID;
                productsInBrands1.State = true;
                productsInBrands1.Source = 2;


                using (var context = new ProductContext())
                {
                    context.ProductsInBrands.AddRange(productsInBrands1);

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
                driver.Close();
            }
            if (c)
            {
                i = i + 36;
                string nextpage = brandUrlPath + "#facet:&productBeginIndex:" + i + "&orderBy:12&pageView:&minPrice:&maxPrice:&pageSize:&";
                driver.Close();
                this.BrandsInProducts_added(nextpage, i);
            }
            else
            {
                Console.WriteLine("Kategori" + i + "urun");
            }
        }

    }
}


    