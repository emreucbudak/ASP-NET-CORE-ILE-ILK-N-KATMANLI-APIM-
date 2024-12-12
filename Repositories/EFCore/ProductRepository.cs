using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryDbContext context) : base(context)
        {
        }

        public void AddProduct(Product product) => Add(product);

        public void DeleteProduct(Product product) => Delete(product);

        public Product GetProductById(int id, bool trackChanges) => GetByCondition(b => b.ID.Equals(id),trackChanges).SingleOrDefault();

        public IQueryable<Product> GetProductList(bool trackChanges) => GetAll(trackChanges);

        public void UpdateProduct(Product product) =>  Update(product);
        public bool ProductExists(int id)
        {
            return _context.Set<Product>().Any(p => p.ID == id); // ID'ye göre kontrol
        }
    }
}
