using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using ozdilekteyim.Models;
using ozdilekteyim.Context;
using System.Threading.Tasks;



namespace ozdilekteyim
{
    public class TranslatorProduct
    {
        public void Translator(IWebDriver driver, Product pro)
        {




            var contex = new ProductContext();




            EngProduct producta = new EngProduct();
            Thread.Sleep(2000);



            producta.Name = pro.Name;
            producta.Description = pro.Description;
            producta.ProductID = pro.ID;
            producta.LanguageCode = "en-us";
            producta.State = true;
            string NameA = pro.Name.Trim().Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");



            string EngName2 = "";
            Thread.Sleep(2000);



            driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[1]/span/span/div/textarea")).SendKeys(NameA);
            IWebElement readnameA = driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[1]/span/span/div/div[1]"));



            string ReadNameB = "";
            DateTime endtimename = DateTime.Now.AddMinutes(1);
            Thread.Sleep(2000);



            do
            {
                ReadNameB = readnameA.GetAttribute("innerHTML").Trim().Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
                if (DateTime.Now > endtimename)
                {
                    throw new Exception("Name ve ReadNameB farkli");
                }
            } while (NameA != ReadNameB);
            Thread.Sleep(2000);
            //name read



            do
            {


                try
                {
                    IReadOnlyCollection<IWebElement> EnglishTranslatorName = driver.FindElements(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[2]/div[5]/div/div[1]/span[1]/span"));
                    foreach (IWebElement items in EnglishTranslatorName)
                    {
                        IWebElement itemsName = items.FindElement(By.XPath("span"));



                        string EngNameA2 = itemsName.GetAttribute("innerHTML");
                        EngName2 = EngName2 + EngNameA2;
                    }
                }
                catch (Exception)
                {



                    IWebElement EnglishTranslatorName2 = driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[2]/div[5]/div[1]/div[1]/span[1]"));

                    string EngNameA2 = EnglishTranslatorName2.GetAttribute("innerHTML");
                    EngName2 = EngName2 + EngNameA2;
                }

            } while (string.IsNullOrWhiteSpace(EngName2));



            string value11 = EngName2;
            string value21 = value11.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
            EngName2 = value21;



            producta.Name = EngName2;



            Console.WriteLine(EngName2);
            //finish




            driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[1]/span/span/div/textarea")).Clear();





            string DescriptionA = (pro.Description ?? "").Trim();



            if (!string.IsNullOrWhiteSpace(DescriptionA))
            {



                string EngDescription = "";
                driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[1]/span/span/div/textarea")).SendKeys(DescriptionA);
                IWebElement readnameAD = driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[1]/span/span/div/div[1]"));



                string ReadNameD = "";
                DateTime endtime = DateTime.Now.AddMinutes(1);
                Thread.Sleep(2000);



                do
                {
                    ReadNameD = readnameAD.GetAttribute("innerHTML").Trim();
                    string value14 = ReadNameD;
                    string value24 = value14.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
                    ReadNameD = value24;



                    if (DateTime.Now > endtime)
                    {
                        throw new Exception("DescriptionA ve ReadNameD farkli");
                    }
                } while (DescriptionA != ReadNameD);


                do
                {


                    Thread.Sleep(2000);



                    IReadOnlyCollection<IWebElement> EnglishTranslatorDescription = driver.FindElements(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[2]/div[5]/div/div[1]/span[1]/span"));
                    foreach (IWebElement items in EnglishTranslatorDescription)
                    {
                        IWebElement itemsName = items.FindElement(By.XPath("span"));



                        string EngDescription2 = itemsName.GetAttribute("innerHTML");
                        EngDescription = EngDescription + EngDescription2;
                    }
                    if (EngDescription != EngName2)
                    {
                        string value13 = EngDescription;
                        string value23 = value13.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
                        EngDescription = value23;
                        producta.Description = EngDescription;
                        Console.WriteLine(EngDescription);



                    }

                } while (string.IsNullOrWhiteSpace(EngDescription));

            }
            driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[1]/span/span/div/textarea")).Clear();



            contex.EngProducts.Add(producta);
            contex.SaveChanges();



        }
    }
}