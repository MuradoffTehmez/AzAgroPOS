using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzAgroPOS.Tests
{
    [TestClass] // Bu atribut, sinifin test metodları ehtiva etdiyini bildirir
    public class MehsulBLLTests
    {
        [TestMethod] // Bu atribut, metodun bir test ssenarisi olduğunu bildirir
        public void Add_Should_Fail_If_ProductName_Is_Empty()
        {
            // Testin strukturu: Arrange, Act, Assert

            // 1. Arrange (Hazırlıq): Test üçün lazım olan obyektləri yaradırıq
            var mehsulBll = new MehsulBLL();
            var mehsul = new Mehsul { Ad = "", SatisQiymeti = 20, AlisQiymeti = 10 };
            var emeliyyatiEden = new Istifadeci { Id = 1 }; // Test üçün saxta istifadəçi

            // 2. Act (Əməliyyat): Yoxlayacağımız metodu çağırırıq
            bool result = mehsulBll.Add(mehsul, emeliyyatiEden, out string message);

            // 3. Assert (Təsdiq): Nəticənin gözlədiyimiz kimi olub-olmadığını yoxlayırıq
            Assert.IsFalse(result, "Metod 'false' qaytarmalı idi, çünki məhsul adı boşdur.");
            Assert.AreEqual("Məhsul adı boş ola bilməz.", message, "Xəta mesajı gözlənildiyi kimi deyil.");
        }

        [TestMethod]
        public void Add_Should_Fail_If_SalePrice_Is_Less_Than_CostPrice()
        {
            // 1. Arrange (Hazırlıq)
            var mehsulBll = new MehsulBLL();
            var mehsul = new Mehsul
            {
                Ad = "Test Məhsulu",
                Barkod = "12345",
                AlisQiymeti = 20,
                SatisQiymeti = 15 // Satış qiyməti alışdan azdır
            };
            var emeliyyatiEden = new Istifadeci { Id = 1 };

            // 2. Act (Əməliyyat)
            bool result = mehsulBll.Add(mehsul, emeliyyatiEden, out string message);

            // 3. Assert (Təsdiq)
            Assert.IsFalse(result, "Metod 'false' qaytarmalı idi, çünki satış qiyməti alışdan azdır.");
            Assert.AreEqual("Satış qiyməti alış qiymətindən az ola bilməz.", message, "Xəta mesajı gözlənildiyi kimi deyil.");
        }
    }
}