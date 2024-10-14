using Microsoft.EntityFrameworkCore;
using OrderTrack.Data;
using OrderTrack.Models;
using OrderTrack.Repositories;

namespace OrderTrack.Services
{
    public class ProductService(MyDbContext context) : IProduct
    {
        private MyDbContext _context = context;
        public async Task Add(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(Product), "El Producto no puede ser nulo");
            }

            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al agregar el Producto a la base de datps", dbExi);
            }
            catch (Exception exi)
            {
                throw new Exception("Ocurrio un error inesperado al ingresar el Producto a la base de datos", exi);
            }
        }
        public async Task Update(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "El Producto no puede ser nulo");
            }

            try
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al actualizar un Producto", dbExi);
            }
            catch (Exception exi)
            {
                throw new Exception("Ocurrio un error inesperado al actiualizar el producto", exi);
            }
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync();

            if (product == null)
            {
                throw new ArgumentNullException(nameof(Product), "El Producto no puede ser nulo");
            }

            try
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("ocurrio un error a la hora de eliminar el Producto en la base de datos");
            }
            catch (Exception exi)
            {
                throw new Exception("ocurrio un error inesperado a la hora de eliminar el Producto en la base de datos");
            }
        }

        // GET
        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();

        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }
        // Util
        public async Task<bool> CheckExistence(int id)
        {
            try
            {
                return await _context.Products.AnyAsync(p => p.Id == id);
            }
            catch (Exception exi)
            {
                throw new Exception("ocurrio un error a la hora de buscar el Producto", exi);
            }
        }

    }
}