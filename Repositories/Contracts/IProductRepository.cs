﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetProductList(bool trackChanges);
        Product GetProductById(int id,bool trackChanges);
        void AddProduct (Product product);
        void DeleteProduct (Product product);
        void UpdateProduct (Product product);
        bool ProductExists(int id);


    }
}