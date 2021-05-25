using System;
using System.Collections.Generic;
using System.Text;

namespace ozdilekteyim
{
    class deneme
    {
        
        public void urun_added()
        {

            string metin = "https://img-ozdilek.mncdn.com/images/catalog/646x1000/8690637889479.jpg";
            string ara = "8690637889479";
            int sonuc;
            sonuc = metin.IndexOf(ara);
            if (sonuc > 0) Console.Write("Var");

            else Console.Write("Yok");

            Console.ReadKey();
        }
    }
}

