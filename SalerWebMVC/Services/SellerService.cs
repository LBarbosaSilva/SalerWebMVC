using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalerWebMVC.Data;
using SalerWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using SalerWebMVC.Services.Exceptions;

namespace SalerWebMVC.Services
{
    public class SellerService
    {
        private readonly SalerWebMVCContext _context;

        public SellerService(SalerWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Saller>> FindAllAsync()
        {
            return await _context.Saller.ToListAsync();
        }

        public async Task InsertAsync(Saller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Saller> FindByIdAsync(int id)
        {
            return await _context.Saller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Saller.FindAsync(id);
                _context.Saller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        internal object FindById(object value)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Saller obj)
        {
            bool hasAny = await _context.Saller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {

                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
