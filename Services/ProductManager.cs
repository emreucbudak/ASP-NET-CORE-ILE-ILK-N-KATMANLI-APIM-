using AutoMapper;
using DTOLAR;
using Entities.Dto;
using Entities.Exceptions;
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
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetAllProductss(bool trackChanges)
        {
            var x =  _manager.product.GetProductList(trackChanges);
            return _mapper.Map<IEnumerable<ProductDto>>(x);
        }

        public Product GetProduct(int id, bool trackChanges)
        {
            return _manager.product.GetProductById(id, trackChanges);
        }

        public ProductDto GetProductDtoById(int id, bool trackChanges)
        {
            var x = _manager.product.GetProductDtoById(id, trackChanges);
            if (x == null)
            {
                throw new ProductNotFoundException(id);
            }
            return x;
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
            var x = _manager.product.GetProductById(id, trackChanges);
            if (x is null)
            {
                throw new ProductNotFoundException(id);
            }
            _manager.product.DeleteProduct(x);

            _manager.Save();
        }

        public void ProductUpdate(int id, ProductDtoForUpdate product, bool trackChanges)
        {
            var x = _manager.product.GetProductById(id, trackChanges);
            if (x is null)
            {
                throw new ProductNotFoundException(id);
            }
            x = _mapper.Map<Product>(product);
            _manager.product.UpdateProduct(x);

            _manager.Save();
        }
    }
}
