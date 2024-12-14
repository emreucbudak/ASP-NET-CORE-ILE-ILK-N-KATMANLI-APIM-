using DTOLAR;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        void AddCategoryFromService(Category category);
        void DeleteCategoryFromService (Category category);
        void UpdateCategoryFromService(Category category);
        IQueryable<Category> GetAllCategoriesFromService(bool trackChanges);
        Category GetCategory(int id, bool trackChanges);
        public bool ProductExists(int id);
        public IEnumerable<CategoryDTO> GetAllCategoriesWithProduct(bool trackChanges);
        public IQueryable<CategoryDTO> GetCategoryWithProduct(int id, bool trackChanges);
    }
}
