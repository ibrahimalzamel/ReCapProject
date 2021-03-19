using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class ErrorMessages
    {
        private static string productNameInvalid = "Ürün ismi geçersiz";
        private static string maintenanceTime = "Sistem bakımda";

        public static string ProductNameInvalid { get => productNameInvalid; set => productNameInvalid = value; }
        public static string MaintenanceTime { get => maintenanceTime; set => maintenanceTime = value; }
    }
}
