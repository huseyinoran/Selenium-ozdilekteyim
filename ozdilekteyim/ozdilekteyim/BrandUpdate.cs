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
    public class BrandUpdate
    {
        public void Brands_updated(ProductsInBrands b)
        {

            var context = new ProductContext();

            
                Product a = context.Products.FirstOrDefault(o => o.Barcode == b.ProductBarcode);
                if (a!=null)
                {
                    a.BrandID = b.BrandID;
                    b.State = false;
                    context.Products.Update(a);

                    context.SaveChanges();
                }
                
            }
            





    }
    }
