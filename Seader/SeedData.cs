using Microsoft.EntityFrameworkCore;
using OrderTrack.Models;

namespace OrderTrack.Data
{
    public class SeedData
    {
        public static void SeedCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category("Electronics", "Devices and gadgets for everyday use")
                {
                    Id = 1
                },
                new Category("Home Appliances", "Equipment and tools for home improvement")
                {
                    Id = 2
                },
                new Category("Books", "Literature and educational materials")
                {
                    Id = 3
                },
                new Category("Fashion", "Clothing and accessories")
                {
                    Id = 4
                },
                new Category("Toys", "Games and entertainment for children")
                {
                    Id = 5
                }
            );
        }
    }
}