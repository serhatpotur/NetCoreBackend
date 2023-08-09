using NetCoreBackend.Business.Abstract;
using NetCoreBackend.DataAccess.Abstract;
using NetCoreBackend.DataAccess.Concrate.InMemory;
using NetCoreBackend.Entities.Concrate;
using NetCoreBackend.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreBackend.Business.Concrate
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _productDal.Get(filter);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryList(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetByUnitPrice(decimal minPrice, decimal maxPrice)
        {
            return _productDal.GetAll(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);

        }
    }
}
