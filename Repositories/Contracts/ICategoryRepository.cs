using DTOLAR;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        IQueryable<Category> GetAll(bool trackChanges);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        Category GetCategory(int id,bool trackChanges);
        bool ProductExists(int id);
        public IEnumerable<CategoryDTO> GetCategoriesWithCategoryAsync(bool trackChanges);
        IQueryable<CategoryDTO> GetCategoryWithProduct(int id , bool trackChanges);
    }
}
