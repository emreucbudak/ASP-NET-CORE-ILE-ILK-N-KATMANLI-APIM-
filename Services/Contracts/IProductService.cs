using DTOLAR;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProductss(bool trackChanges);
        Product GetProduct(int id, bool trackChanges);
        void ProductAdd(Product product);
        void ProductRemove(int id , bool trackChanges);
        void ProductUpdate(int id ,Product product,bool trackChanges);
        IEnumerable<ProductDto> GetProductsWithCategory(bool trackChanges);
        public bool ProductExists(int id);


    }
}
