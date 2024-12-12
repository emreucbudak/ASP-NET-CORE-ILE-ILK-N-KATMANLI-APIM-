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

        public RepositoryManager(RepositoryDbContext context)
        {
            _context = context;
            _productRepository = new Lazy<ProductRepository>(() => new ProductRepository(_context));
        }

        public IProductRepository product => _productRepository.Value;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
