﻿using NetCoreBackend.DataAccess.Abstract;
using NetCoreBackend.Entities.Concrate;
using NetCoreBackend.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBackend.DataAccess.Concrate.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitsInStock=50,UnitPrice=50},
                new Product{ProductId=2,CategoryId=2,ProductName="Kamera",UnitsInStock=5,UnitPrice=500},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitsInStock=5,UnitPrice=5000},
                new Product{ProductId=4,CategoryId=3,ProductName="Asus Laptop",UnitsInStock=2,UnitPrice=15000},
                new Product{ProductId=5,CategoryId=3,ProductName="Lenovo Laptop",UnitsInStock=2,UnitPrice=15000},
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product? productToDelete;

            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
