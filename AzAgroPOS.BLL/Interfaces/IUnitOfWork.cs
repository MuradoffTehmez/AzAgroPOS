using AzAgroPOS.DAL.Repositories;
using System;

namespace AzAgroPOS.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Bütün repozitoriləri bura əlavə edirik
        IstifadeciRepository Istifadeciler { get; }
        SatisRepository Satislar { get; }
        SatisDetaliRepository SatisDetallari { get; }
        SatisOdemesiRepository SatisOdemeleri { get; }
        AnbarQalikRepository AnbarQaliqlari { get; }
        MehsulRepository Mehsullar { get; }
        MusteriBorcRepository MusteriBorclari { get; }
        MusteriRepository Musteriler { get; }
        TedarukcuRepository Tedarukciler { get; }
        AnbarRepository Anbarlar { get; }
        GiderRepository Giderler { get; }
        TamirIsiRepository TamirIsleri { get; }
        IsciRepository Isciler { get; }
        RolRepository Roller { get; }
        MehsulKateqoriyasiRepository MehsulKateqoriyalari { get; }
        VahidRepository Vahidler { get; }
        VahidRepository AltVahidler { get; }
        MehsulKateqoriyasiRepository UstMehsulKateqoriyalari { get; }
        BorcOdenisRepository BorcOdenisleri { get; }

        // Digər bütün repozitorilərinizi bura əlavə edin

        /// <summary>
        /// Bütün dəyişiklikləri vahid bir tranzaksiya ilə verilənlər bazasına yazır.
        /// </summary>
        /// <returns>Təsirlənən sətirlərin sayı</returns>
        int Complete();

        /// <summary>
        /// Asynchronous olaraq bütün dəyişiklikləri vahid bir tranzaksiya ilə verilənlər bazasına yazır.
        /// </summary>
        /// <returns>Təsirlənən sətirlərin sayı</returns>
        System.Threading.Tasks.Task<int> CompleteAsync();
    }
}