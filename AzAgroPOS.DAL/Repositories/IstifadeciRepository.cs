using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class IstifadeciRepository
    {
        public Istifadeci GetByEmail(string email)
        {
            using (var context = new AzAgroDbContext())
            {
                return context.Istifadeciler
                    .Include(i => i.Rol)
                    .Include(i => i.Tema)
                    .FirstOrDefault(i => i.Email == email);
            }
        }

        public async Task<Istifadeci> GetByEmailAsync(string email)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Istifadeciler
                    .Include(i => i.Rol)
                    .Include(i => i.Tema)
                    .FirstOrDefaultAsync(i => i.Email == email);
            }
        }

        public async Task<Istifadeci> GetByIdAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Istifadeciler
                    .Include(i => i.Rol)
                    .Include(i => i.Tema)
                    .FirstOrDefaultAsync(i => i.Id == id);
            }
        }

        public async Task<List<Istifadeci>> GetAllAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Istifadeciler
                    .Include(i => i.Rol)
                    .Include(i => i.Tema)
                    .ToListAsync();
            }
        }

        public async Task<Istifadeci> CreateAsync(Istifadeci istifadeci)
        {
            using (var context = new AzAgroDbContext())
            {
                context.Istifadeciler.Add(istifadeci);
                await context.SaveChangesAsync();
                return istifadeci;
            }
        }

        public async Task<Istifadeci> UpdateAsync(Istifadeci istifadeci)
        {
            using (var context = new AzAgroDbContext())
            {
                context.Istifadeciler.Update(istifadeci);
                await context.SaveChangesAsync();
                return istifadeci;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                var istifadeci = await context.Istifadeciler.FindAsync(id);
                if (istifadeci == null)
                    return false;

                context.Istifadeciler.Remove(istifadeci);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> EmailExistsAsync(string email, int? excludeId = null)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Istifadeciler
                    .AnyAsync(i => i.Email == email && (excludeId == null || i.Id != excludeId));
            }
        }

        public void Dispose()
        {
            // DbContext hər metodda 'using' ilə yaradıldığı üçün burada xüsusi bir əməliyyata ehtiyac yoxdur.
        }

        public void Update(Istifadeci istifadeci)
        {
            using (var context = new AzAgroDbContext())
            {
                context.Istifadeciler.Update(istifadeci);
                context.SaveChanges();
            }
        }
    }
}