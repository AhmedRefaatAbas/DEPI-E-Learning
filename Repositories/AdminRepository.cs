using DEPI_E_Learning.ApplicationDbContexts;
using DEPI_E_Learning.Models;
using DEPI_E_Learning.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEPI_E_Learning.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminModel?> GetByIdAsync(int adminId)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.AdminId == adminId);
        }

        public async Task<AdminModel?> GetByEmailAsync(string email)
        {
            return await _context.Admins.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<IEnumerable<AdminModel>> GetAllAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task AddAsync(AdminModel admin)
        {
            await _context.Admins.AddAsync(admin);
        }

        public async Task UpdateAsync(AdminModel admin)
        {
            _context.Admins.Update(admin);
        }

        public async Task DeleteAsync(int adminId)
        {
            var admin = await GetByIdAsync(adminId);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
            }
        }
    }
}
