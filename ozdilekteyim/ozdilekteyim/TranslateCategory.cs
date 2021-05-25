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
    public class TranslateCategory
    {
        public void Translator(IWebDriver driver, Category category)
        {

            var contex = new ProductContext();

            RusCategory engCategory = new RusCategory();
            Thread.Sleep(2000);

            engCategory.Name = category.Name;
            engCategory.CategoryID = category.ID;
            engCategory.State = true;

            string CategoryA = category.Name.Trim().Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");

            string EngCategoryName = "";
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[1]/span/span/div/textarea")).SendKeys(CategoryA);
            IWebElement readcategoryA = driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[1]/span/span/div/div[1]"));

            string ReadCategoryB = "";
            DateTime endtimename = DateTime.Now.AddMinutes(1);
            Thread.Sleep(2000);

            do
            {
                ReadCategoryB = readcategoryA.GetAttribute("innerHTML").Trim().Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");
                if (DateTime.Now > endtimename)
                {
                    throw new Exception("Name ve ReadNameB farkli");
                }
            } while (CategoryA != ReadCategoryB);
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
                        EngCategoryName = EngCategoryName + EngNameA2;
                    }
                }
                catch (Exception)
                {

                    IWebElement EnglishTranslatorName2 = driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[2]/div[5]/div[1]/div[1]/span[1]"));
                    string EngNameA2 = EnglishTranslatorName2.GetAttribute("innerHTML");
                    EngCategoryName = EngCategoryName + EngNameA2;
                }

            } while (string.IsNullOrWhiteSpace(EngCategoryName));

            engCategory.Name = EngCategoryName.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&");

            Console.WriteLine(EngCategoryName);
            //finish

            driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[1]/span/span/div/textarea")).Clear();

            contex.RusCategories.Add(engCategory);
            contex.SaveChanges();



        }
    }
}
