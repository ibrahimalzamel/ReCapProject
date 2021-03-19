using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class SuccessMessages
    {
        private static string productAdded = "Ürün Eklendi";
        private static string product = "Ürün Eklendi";
        private static string productListed = "Ürünler Listelendi";

        public static string ProductAdded { get => productAdded; set => productAdded = value; }
        public static string Product { get => product; set => product = value; }
        public static string ProductListed { get => productListed; set => productListed = value; }
    }
}
