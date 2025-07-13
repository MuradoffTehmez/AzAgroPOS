using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class RolRepository
    {
        public List<Rol> GetAll()
        {
            using (var context = new AzAgroDbContext())
            {
                return context.Roller
                    .Include(r => r.Istifadeciler)
                    .Include(r => r.RolIcazeleri)
                    .ToList();
            }
        }

        public async Task<List<Rol>> GetAllAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Roller
                    .Include(r => r.Istifadeciler)
                    .Include(r => r.RolIcazeleri)
                    .ToListAsync();
            }
        }

        public Rol GetById(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                return context.Roller
                    .Include(r => r.Istifadeciler)
                    .Include(r => r.RolIcazeleri)
                    .FirstOrDefault(r => r.Id == id);
            }
        }

        public async Task<Rol> GetByIdAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Roller
                    .Include(r => r.Istifadeciler)
                    .Include(r => r.RolIcazeleri)
                    .FirstOrDefaultAsync(r => r.Id == id);
            }
        }

        public async Task<Rol> CreateAsync(Rol rol)
        {
            using (var context = new AzAgroDbContext())
            {
                rol.YaradilmaTarixi = DateTime.Now;
                context.Roller.Add(rol);
                await context.SaveChangesAsync();
                return rol;
            }
        }

        public async Task<Rol> UpdateAsync(Rol rol)
        {
            using (var context = new AzAgroDbContext())
            {
                context.Roller.Update(rol);
                await context.SaveChangesAsync();
                return rol;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                var rol = await context.Roller.FindAsync(id);
                if (rol == null)
                    return false;

                context.Roller.Remove(rol);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> RolNameExistsAsync(string ad, int? excludeId = null)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Roller
                    .AnyAsync(r => r.Ad == ad && (excludeId == null || r.Id != excludeId));
            }
        }
    }
}