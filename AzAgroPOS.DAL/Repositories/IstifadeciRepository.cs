using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class IstifadeciRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public IstifadeciRepository(AzAgroDbContext context = null)
        {
            _context = context ?? new AzAgroDbContext();
        }

        public Istifadeci GetByEmail(string email)
        {
            return _context.Istifadeciler
                .Include(i => i.Rol)
                .Include(i => i.Tema)
                .FirstOrDefault(i => i.Email == email);
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

        public Istifadeci GetById(int id)
        {
            return _context.Istifadeciler
                .Include(i => i.Rol)
                .Include(i => i.Tema)
                .FirstOrDefault(i => i.Id == id);
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

        public IEnumerable<Istifadeci> GetAll()
        {
            using (var context = new AzAgroDbContext())
            {
                return context.Istifadeciler
                    .Include(i => i.Rol)
                    .ToList();
            }
        }

        public IEnumerable<Istifadeci> GetAllActive()
        {
            using (var context = new AzAgroDbContext())
            {
                return context.Istifadeciler
                    .Include(i => i.Rol)
                    .Where(i => i.Status == "Aktiv")
                    .OrderBy(i => i.Ad)
                    .ToList();
            }
        }

        //public async Task<Istifadeci> GetByRememberMeTokenAsync(string token, bool includeDetails = true)
        //{
        //    using (var context = new AzAgroDbContext())
        //    {
        //        var query = context.Istifadeciler.AsQueryable();
        //        if (includeDetails)
        //        {
        //            query = query.Include(i => i.Rol).Include(i => i.Tema);
        //        }
        //        return await query.FirstOrDefaultAsync(i => i.RememberMeToken == token);
        //    }
        //}

        public async Task<Istifadeci> GetByRememberMeTokenAsync(string token)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Istifadeciler
                    .Include(i => i.Rol)
                    .Include(i => i.Tema)
                    .FirstOrDefaultAsync(i => i.RememberMeToken == token);
            }
        }

        public async Task<List<Istifadeci>> GetFilteredUsersAsync(string searchTerm, string status, int? rolId, int pageSize = 100, int pageNumber = 1)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.Istifadeciler
                    .Include(i => i.Rol)
                    .Include(i => i.Tema)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(i => 
                        i.Ad.Contains(searchTerm) || 
                        i.Soyad.Contains(searchTerm) || 
                        i.Email.Contains(searchTerm));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    query = query.Where(i => i.Status == status);
                }

                if (rolId.HasValue)
                {
                    query = query.Where(i => i.RolId == rolId.Value);
                }

                return await query
                    .OrderBy(i => i.Ad)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
        }

        public async Task<int> GetFilteredUsersCountAsync(string searchTerm, string status, int? rolId)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.Istifadeciler.AsQueryable();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(i => 
                        i.Ad.Contains(searchTerm) || 
                        i.Soyad.Contains(searchTerm) || 
                        i.Email.Contains(searchTerm));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    query = query.Where(i => i.Status == status);
                }

                if (rolId.HasValue)
                {
                    query = query.Where(i => i.RolId == rolId.Value);
                }

                return await query.CountAsync();
            }
        }

        //public void Dispose()
        //{
        //    _context?.Dispose();
        //}
    }
}