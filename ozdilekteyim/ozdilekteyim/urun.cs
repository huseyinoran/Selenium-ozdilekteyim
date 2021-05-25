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
    public class urun
    {
        public void urun_added(string proURL)
        {
            var options = new ChromeOptions();
            options.AddArguments("headless");
            IWebDriver driver = new ChromeDriver(options);

            //IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(proURL);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);
            var contex = new ProductContext();

            List<Product> pro = new List<Product>();
            Product Producta = new Product();

            bool c = true;

            try
            {

                driver.FindElement(By.CssSelector("#WC_GenericError_5"));

            }
            catch (Exception)
            {
                c = false;
            }
            
            if (!c)
            {
               
                //Barcode
                IWebElement BarcodePath = driver.FindElement(By.ClassName("MagicZoom"));
                string BarcodePathi = BarcodePath.GetAttribute("href");

                Console.WriteLine(BarcodePathi);

                Regex r = new Regex(@".*\/(?<katCode>.*?)\.");

                string BarcodeeCode = null;
                if (r.Match(BarcodePathi).Success)
                {
                    BarcodeeCode = r.Match(BarcodePathi).Groups["katCode"].Value;
                }
                Producta.Barcode = BarcodeeCode;

                Product probul = contex.Products.FirstOrDefault(o => o.Barcode == BarcodeeCode);
                if (probul == null)
                {

                    //Code
                    Producta.Code = BarcodeeCode;


                    //SKU
                    IWebElement SKUPath = driver.FindElement(By.ClassName("sku"));
                    string SKUPathi = SKUPath.GetAttribute("innerHTML");

                    Regex r2 = new Regex(@".*\: (?<katCode>.*$)");

                    string SKUCode = null;
                    if (r2.Match(SKUPathi).Success)
                    {
                        SKUCode = r2.Match(SKUPathi).Groups["katCode"].Value;
                    }
                    Console.WriteLine(SKUCode);

                    Producta.SKU = SKUCode;

                    //Name

                    IWebElement NamePath = driver.FindElement(By.ClassName("main_header"));
                    string NamePathi = NamePath.GetAttribute("innerHTML");

                    Console.WriteLine(NamePathi);

                    Producta.Name = NamePathi;

                    //Description

                    bool d = true;

                    try
                    {

                        driver.FindElement(By.XPath("//*[@id='collapse2']/div/div[1]/p[1]"));

                    }
                    catch (Exception)
                    {
                        d = false;
                    }
                    if (d)
                    {
                        IWebElement DesciriptionPath = driver.FindElement(By.XPath("//*[@id='collapse2']/div/div[1]/p[1]"));
                        string DescriptionCode = DesciriptionPath.GetAttribute("innerHTML");

                        Producta.Description = DescriptionCode;

                    } 

                    


                    //State

                    Producta.State = true;

                    //Source 
                    Producta.Source = 2;//özdilekteyim

                    //Category

                    IWebElement CategoryPath = driver.FindElement(By.XPath("//*[@id='widget_breadcrumb']/ul/li[last()-1]"));

                    string katURLbul = CategoryPath.FindElement(By.TagName("A")).GetAttribute("href");

                    Regex r4 = new Regex(@".*\/(?<katCode>.*$)");

                    string CatgoryCode = null;
                    if (r4.Match(katURLbul).Success)
                    {
                        CatgoryCode = r4.Match(katURLbul).Groups["katCode"].Value;
                    }

                    Category bul = contex.Categories.FirstOrDefault(o => o.Description == CatgoryCode);
                    if (bul != null)
                    {
                        Producta.CategoryID = bul.ID;
                        Console.WriteLine(CatgoryCode);
                    }
                    else
                    {
                        Producta.CategoryID = 1970;

                    }
                    //Address 
                    Producta.Address = proURL;

                    //Price
                    IWebElement PricePath = driver.FindElement(By.XPath("//*[@id='taksitTablosuPrice']"));
                    string PricePathprice = PricePath.GetAttribute("value");

                    Producta.Price = Convert.ToDecimal(PricePathprice) / 100;

                    //Brand
                    Producta.BrandID = 810;
                    //Unit
                    Producta.UnitID = 1;

                    //File

                    string FilePath = BarcodePathi;

                    using (var context = new ProductContext())
                    {
                        context.Products.AddRange(Producta);
                        context.SaveChanges();
                        //*******************************Open
                    }

                    File file = new File();
                    file.Path = FilePath;
                    file.State = true;
                    file.RelativePath = BarcodeeCode + ".jpg";
                    file.ProductID = Producta.ID;

                    System.Net.WebClient wc = new System.Net.WebClient();
                    wc.DownloadFile(FilePath, String.Concat(@"C:\Users\Emre\source\repos\ozdilekteyim\ozdilekteyim\images\", BarcodeeCode, ".jpg"));


                    using (var context = new ProductContext())
                    {
                        context.Files.Add(file);
                        context.SaveChanges();
                    }

                }
            }
            driver.Close();
            
        }

    }



}