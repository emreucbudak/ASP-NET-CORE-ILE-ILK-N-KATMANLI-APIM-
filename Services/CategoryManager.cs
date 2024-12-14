using DTOLAR;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager repositoryManager;
        public CategoryManager(IRepositoryManager manager) 
        {
            repositoryManager = manager;
        }
        public void AddCategoryFromService(Category category)
        {
            repositoryManager.category.AddCategory(category);
            repositoryManager.Save();
        }

        public void DeleteCategoryFromService(Category category)
        {
            repositoryManager.category.DeleteCategory(category);
            repositoryManager.Save();
        }

        public IQueryable<Category> GetAllCategoriesFromService(bool trackChanges)
        {
            return repositoryManager.category.GetAll(trackChanges);
        }

        public IEnumerable<CategoryDTO> GetAllCategoriesWithProduct(bool trackChanges) => repositoryManager.category.GetCategoriesWithCategoryAsync(trackChanges);

        public Category GetCategory(int id, bool trackChanges)
        {
            return repositoryManager.category.GetCategory(id, trackChanges);
        }

        public IQueryable<CategoryDTO> GetCategoryWithProduct(int id, bool trackChanges)
        {
           return repositoryManager.category.GetCategoryWithProduct(id, trackChanges);
        }

        public bool ProductExists(int id)
        {
            return repositoryManager.category.ProductExists(id);
        }

        public void UpdateCategoryFromService(Category category)
        {
            repositoryManager.category.UpdateCategory(category);
            repositoryManager.Save();
        }


    }
}
