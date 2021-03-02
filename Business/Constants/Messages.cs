using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAddes = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string ProductDeleted = "Ürün silindi.";
        public static string ProductControl = "Açıklama ve günlük fiyat girişini kontrol ediniz.";
        public static string ProductUpdates = "Ürün güncellendi.";
        public static string ProductListed = "Ürünler listelendi.";
        public static string CarRented = "Araba Kiralandı";
        public static string CarNotRented = "Araba kiralanamamıştır.";
        public static string CustomerAddes = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdates = "Müşteri güncellendi.";
        internal static string CarImageDeleted = "Araba resmi silindi.";
        internal static string MaxCarImage="Arabanın en fazla 5 resmi olabilir.";
        internal static string ImagesAdded="Resim eklendi";
        internal static string CarImagesListed="Resimler listelendi";
        internal static string AuthorizationDenied="Yetkiniz yok.";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola bulunamadı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
