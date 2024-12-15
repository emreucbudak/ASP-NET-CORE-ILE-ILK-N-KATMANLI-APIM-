using DTOLAR;
using Entities.Models;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;

        public ProductManager(IRepositoryManager manager, ILoggerService logger)
        {
            _manager = manager;
            _logger = logger;
        }

        public IEnumerable<Product> GetAllProductss(bool trackChanges)
        {
            return _manager.product.GetProductList(trackChanges);
        }

        public Product GetProduct(int id, bool trackChanges)
        {
            return _manager.product.GetProductById(id, trackChanges);
        }

        public ProductDto GetProductDtoById(int id, bool trackChanges)
        {
            return _manager.product.GetProductDtoById(id, trackChanges);
        }

        public IEnumerable<ProductDto> GetProductsWithCategory(bool trackChanges) => _manager.product.GetProductsWithCategoryAsync(false);

        public void ProductAdd(Product product)
        {
            _manager.product.AddProduct(product);
            _manager.Save();
        }

        public bool ProductExists(int id)
        {
            return _manager.product.ProductExists(id);
        }

        public void ProductRemove(int id, bool trackChanges)
        {
            var x = _manager.product.GetProductById(id,trackChanges);
            if (x is null)
            {
                string message = $"Ürünler Listesinde Id'si {id} olan öğe bulunamadı ";
                _logger.LogInfo(message);
                throw new Exception(message);
            }
            _manager.product.DeleteProduct(x);

            _manager.Save();
        }

        public void ProductUpdate(int id ,Product product, bool trackChanges)
        {
            var x = _manager.product.GetProductById(id,trackChanges);
            if (x is null)
            {
                string message = $"Id'si {id} olan öğe bulunamadı ";
                _logger.LogInfo(message);
                throw new Exception(message);
            }
            x.ProductName = product.ProductName;
            _manager.product.UpdateProduct(x);

            _manager.Save();
        }


    }
}
