using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderTrack.Models;

namespace OrderTrack.Repositories
{
    public interface ICategory
    {
        // CRUD
        Task Add(Category category);
        Task Update(Category category);
        Task Delete(int id);

        // GET
        Task<IEnumerable<Category>> GetAll();
        Task<Category?> GetById(int id);
        Task<bool> CheckExistence(int id);


    }
}