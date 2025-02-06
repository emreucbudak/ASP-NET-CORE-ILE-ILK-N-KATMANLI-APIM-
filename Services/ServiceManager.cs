using AutoMapper;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<ICategoryService> _categoryService;

        public ServiceManager(IRepositoryManager _repomanage ,ILoggerService _service, IMapper mapper)
        { 
            _productService = new Lazy<IProductService>(() => new ProductManager(_repomanage, _service , mapper));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryManager(_repomanage));
        }

        public IProductService ProductService => _productService.Value;

        public ICategoryService CategoryService => _categoryService.Value;
    }
}
