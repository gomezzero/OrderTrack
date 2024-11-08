using Microsoft.EntityFrameworkCore;
using OrderTrack.Data;
using OrderTrack.Models;
using OrderTrack.Repositories;

namespace OrderTrack.Services
{
    public class UserServices(MyDbContext context) : IUser
    {
        private MyDbContext _context = context;

        public async Task Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(User), "El usuario no puede ser nulo");
            }

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al agregar el Usuario a la base de datps", dbExi);
            }
            catch (Exception exi)
            {
                throw new Exception("Ocurrio un error inesperado al ingresar al Useario a la base de datos", exi);
            }
        }

        public async Task Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                throw new ArgumentNullException(nameof(User), "El Usuario no puede ser nulo");
            }

            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al eliminar al Usuario en la base de datos", dbExi);
            }
            catch (Exception exi)
            {
                throw new Exception("ocurrio un error a la hora de eliminar al Usuario", exi);
            }
        }

        public async Task Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "El Usuario no puede ser nulo");
            }

            try
            {
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbExi)
            {
                throw new Exception("Error al actualizar el Usuario en la base de datos", dbExi);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado al actualizar el Usuario.", ex);
            }
        }

        //  GET
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<bool> CheckExistence(int id)
        {
            try
            {
                return await _context.Users.AnyAsync(u => u.Id == id);
            }
            catch (Exception exi)
            {
                throw new Exception("ocurrio un error a la hora de busacar el Usuario", exi);
            }
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}