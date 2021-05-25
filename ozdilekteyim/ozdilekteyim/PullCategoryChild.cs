﻿using ozdilekteyim.Models;
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
    public class PullCategoryChild
    {
        public void category_added()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.ozdilekteyim.com/shop/tr/bursahipermarket");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            IReadOnlyCollection<IWebElement> ParentCategoryis = driver.FindElements(By.XPath("//*[@id='wc_widget_RefreshArea_0']/ul/li"));


            foreach (IWebElement Categoryi in ParentCategoryis)
            {
                //Name
                IWebElement Categoryi2 = Categoryi.FindElement(By.XPath("a/span"));
                string ka = Categoryi2.GetAttribute("innerHTML");
                string value1 = ka;
                string value2 = value1.Replace("&amp;", "&");
                ka = value2;

                string CategoryNameUrl = Categoryi.FindElement(By.TagName("A")).GetAttribute("href");

                Regex r = new Regex(@".*\/(?<katCode>.*?$)");

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
                using (var context = new ProductContext())
                {
                    context.Categories.AddRange(categorya);

                    context.SaveChanges();
                }
                Console.WriteLine(ka);
                Console.WriteLine(CategoryNameUrl);
                Console.WriteLine(CategoryCode);

                IReadOnlyCollection<IWebElement> ChildCategory = Categoryi.FindElements(By.XPath("ul/li/div[2]/div/div"));

                foreach (IWebElement ChildCategorychild in ChildCategory)
                {
                    //Name
                    IWebElement ChildCategorychild2 = ChildCategorychild.FindElement(By.XPath("div"));
                    string ChildCategorychildname = ChildCategorychild2.FindElement(By.TagName("A")).GetAttribute("aria-label");
                    string ChildCategorychildaddress = ChildCategorychild2.FindElement(By.TagName("A")).GetAttribute("href");
                    Console.WriteLine(ChildCategorychildname);
                    Console.WriteLine(ChildCategorychildaddress);
                    Regex r2 = new Regex(@".*\/(?<katCode>.*?$)");

                    string CategoryCode2 = null;
                    if (r2.Match(ChildCategorychildaddress).Success)
                    {
                        CategoryCode2 = r2.Match(ChildCategorychildaddress).Groups["katCode"].Value;
                    }

                    Category categorya2 = new Category();
                    categorya2.Name = ChildCategorychildname;
                    categorya2.State = true;
                    categorya2.Source = 2;
                    categorya2.Address = ChildCategorychildaddress;
                    categorya2.Description = CategoryCode2;
                    categorya2.ParentCategoryID = categorya.ID;
                    using (var context = new ProductContext())
                    {
                        context.Categories.AddRange(categorya2);

                        context.SaveChanges();
                    }
                    IReadOnlyCollection<IWebElement> ChildChildCategory = ChildCategorychild.FindElements(By.XPath("div/nav/div"));

                    foreach (IWebElement ChildCategorychildchild in ChildChildCategory)
                    {
                        //Name
                        IReadOnlyCollection<IWebElement> ChildCategorychildchildA = ChildCategorychildchild.FindElements(By.XPath("a"));
                        foreach (IWebElement ChildCategorychildchildA2 in ChildCategorychildchildA)
                        {
                            string ChildCategorychildchildname = ChildCategorychildchildA2.GetAttribute("innerHTML");
                            string ChildCategorychildchilddaddress = ChildCategorychildchildA2.GetAttribute("href");
                            Console.WriteLine(ChildCategorychildchildname);
                            Console.WriteLine(ChildCategorychildchilddaddress);
                            Regex r3 = new Regex(@".*\/(?<katCode>.*?$)");

                            string CategoryCode3 = null;
                            if (r2.Match(ChildCategorychildchilddaddress).Success)
                            {
                                CategoryCode3 = r2.Match(ChildCategorychildchilddaddress).Groups["katCode"].Value;
                            }
                            Category categorya3 = new Category();
                            categorya3.Name = ChildCategorychildchildname;
                            categorya3.State = false;
                            categorya3.Source = 2;
                            categorya3.Address = ChildCategorychildchilddaddress;
                            categorya3.Description = CategoryCode3;
                            categorya3.ParentCategoryID = categorya2.ID;
                            using (var context = new ProductContext())
                            {
                                context.Categories.AddRange(categorya3);

                                context.SaveChanges();
                            }

                        }




                    }

                }
            }
        }
    }
}

