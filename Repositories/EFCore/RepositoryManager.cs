using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryDbContext _context;
        private readonly Lazy<ProductRepository> _productRepository;
        private readonly Lazy<CategoryRepository> _categoryRepository;

        public RepositoryManager(RepositoryDbContext context)
        {
            _context = context;
            _productRepository = new Lazy<ProductRepository>(() => new ProductRepository(_context));
            _categoryRepository = new Lazy<CategoryRepository>(() => new CategoryRepository(_context));
        }

        public IProductRepository product => _productRepository.Value;

        public ICategoryRepository category => _categoryRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
