using Microsoft.EntityFrameworkCore;
using SpeedLinecars.Controllers;
using SpeedLinecars.Data;
using SpeedLinecars.Models;


namespace SpeedLinecars.Service.BrandService
{
    public class BrandService 
    {
        private readonly SpeedLineDbContext _dbContext;

        public BrandService(SpeedLineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBrandAsync(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            _dbContext.SaveChanges();
        }

        public async Task<Brand> BrandDetailsAsync(Guid id)
        {
            var brand = await _dbContext.Brands.FirstOrDefaultAsync(x => x.BrandId == id);
            return brand;
        }

        public void BrandDelete(int id)
        {
            var brand = _dbContext.Brands.Find(id);
            if (brand != null)
            {
                _dbContext.Brands.Remove(brand);
                _dbContext.SaveChanges();
            }
        }
    }
}
