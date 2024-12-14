using DTOLAR;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryDbContext context) : base(context)
        {
        }

        public void AddCategory(Category category) => Add(category);

        public void DeleteCategory(Category category) => Delete(category);

        public Category GetCategory(int id, bool trackChanges) => GetByCondition(b => b.CategoryID == id, trackChanges).SingleOrDefault();

        public bool ProductExists(int id)
        {
            return _context.Set<Category>().Any(p => p.CategoryID == id); // ID'ye göre kontrol
        }
        public IEnumerable<CategoryDTO> GetCategoriesWithCategoryAsync(bool trackChanges)
        {
            return !trackChanges
                ? _context.Category
                    .Include(p => p.Products)
                    .AsNoTracking()
                    .Select(p => new CategoryDTO
                    {
                        CategoryID = p.CategoryID,
                        CategoryName = p.CategoryName,
                        ProductName = p.Products.Select(p => p.ProductName).ToList()
                    })
                    .ToList()
                : _context.Category
                    .Include(p => p.Products)
                    .Select(p => new CategoryDTO
                    {
                        CategoryID = p.CategoryID,
                        CategoryName = p.CategoryName,
                        ProductName = p.Products.Select(p=>p.ProductName).ToList()

                    })
                    .ToList();
        }

        public void UpdateCategory(Category category) => Update(category);

        public IQueryable<CategoryDTO> GetCategoryWithProduct(int id, bool trackChanges)
        {
            if(trackChanges)
            {
                return null;
            }
            var x = _context.Category.Where(b => b.CategoryID == id)
                .Include(p => p.Products)
                .Select(p => new CategoryDTO
                {
                    CategoryID = p.CategoryID,
                    CategoryName = p.CategoryName,
                    ProductName = p.Products.Select(p => p.ProductName).ToList()
                });
            return x;
        }
    }
}
