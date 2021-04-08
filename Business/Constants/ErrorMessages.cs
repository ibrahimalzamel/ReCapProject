using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class ErrorMessages
    {
        private static string AuthorizationDenied = "Yetkiniz Yok.";

        private static string checkDailyPrice = "Günlük kira ücreti 0'dan fazla olmalı";
        private static string carNameInvalid = "Araç ismi minimum 2 karakter olmalıdır";

        private static string firstNameLastNameInvalid = "İsim veya Soyisim Girilmemiş";
        private static string userNotDeleted = "HATA. Kullanıcı Silinemedi";


        private static string customerNotAdded = "HATA. Müşteri Eklenemedi";
        private static string customerNotDeleted = "HATA. Müşteri Silinemedi";
        private static string BrandNameAlreadyExistsError = "BrandName is not Exists";

        private static string rentalAddedError = "Araç teslim edilmediği için tekrar kiraya verilemez";
        private static string rentalUpdateReturnDate = "Araç Teslim Alındı";

        private static string maintenanceTime = "Sistem Bakımda";
        private static string carImageLimitExceeded = "Fotoğraf yükleme limitine takıldınız. En fazla 5 fotoğraf eklenebilir.";
        private static string productNameInvalid = "Ürün ismi geçersiz";

        public static string CheckDailyPrice { get => checkDailyPrice; set => checkDailyPrice = value; }
        public static string CarNameInvalid { get => carNameInvalid; set => carNameInvalid = value; }
        public static string FirstNameLastNameInvalid { get => firstNameLastNameInvalid; set => firstNameLastNameInvalid = value; }
        public static string UserNotDeleted { get => userNotDeleted; set => userNotDeleted = value; }
        public static string CustomerNotAdded { get => customerNotAdded; set => customerNotAdded = value; }
        public static string CustomerNotDeleted { get => customerNotDeleted; set => customerNotDeleted = value; }
        public static string RentalAddedError { get => rentalAddedError; set => rentalAddedError = value; }
        public static string RentalUpdateReturnDate { get => rentalUpdateReturnDate; set => rentalUpdateReturnDate = value; }
        public static string MaintenanceTime { get => maintenanceTime; set => maintenanceTime = value; }
        public static string CarImageLimitExceeded { get => carImageLimitExceeded; set => carImageLimitExceeded = value; }
        public static string ProductNameInvalid { get => productNameInvalid; set => productNameInvalid = value; }
        public static string AuthorizationDenied1 { get => AuthorizationDenied; set => AuthorizationDenied = value; }
        public static string BrandNameAlreadyExistsError1 { get => BrandNameAlreadyExistsError; set => BrandNameAlreadyExistsError = value; }
    }
}
