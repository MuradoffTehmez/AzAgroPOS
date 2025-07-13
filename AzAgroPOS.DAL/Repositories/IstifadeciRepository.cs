using AzAgroPOS.Entities.Domain;
using System.Linq; // LINQ üçün bunu əlavə edirik

namespace AzAgroPOS.DAL.Repositories
{
    public class IstifadeciRepository
    {
        // Artıq connection string lazım deyil!

        public Istifadeci GetByEmail(string email)
        {
            // 'using' bloku DbContext-in düzgün şəkildə idarə olunmasını təmin edir.
            using (var context = new AzAgroDbContext())
            {
                // Mürəkkəb SQL sorğusu əvəzinə, sadə və oxunaqlı bir LINQ sorğusu!
                return context.Istifadeciler.FirstOrDefault(i => i.Email == email);
            }
        }
    }
}