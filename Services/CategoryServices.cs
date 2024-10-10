using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderTrack.Data;
using OrderTrack.Models;
using OrderTrack.Repositories;

namespace OrderTrack.Services
{
    public class CategoryServices : ICategory
    {
        private readonly MyDbContext _context;

        public CategoryServices(MyDbContext context)
        {
            _context = context;
        }


        public async Task Add(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(Category), "La Categoria no puede ser nulo");
            }

            try
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al agregar La Categoria a la base de datos", dbExi);
            }
            catch (Exception exi)
            {
                throw new Exception("ocurrio un error a la hora de agregar La Categoria", exi);
            }
        }

        public async Task Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                throw new ArgumentNullException(nameof(Category), "La Categoria no puede ser nulo");
            }

            try
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al eliminar La Categoria a la base de datos", dbExi);
            }
            catch (Exception exi)
            {
                throw new Exception("ocurrio un error a la hora de eliminar La Categoria", exi);
            }
        }

        public async Task Update(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "La Categoria no puede ser nulo");
            }

            try
            {
                _context.Entry(category).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al actualizar La Categoria en la base de datos", dbExi);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al actualizar La Categoria.", ex);
            }
        }

        // GET

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

    }
}