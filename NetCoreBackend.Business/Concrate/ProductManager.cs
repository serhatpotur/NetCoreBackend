using FluentValidation;
using NetCoreBackend.Business.Abstract;
using NetCoreBackend.Business.Constants;
using NetCoreBackend.Business.ValidationRules.FluentValidation;
using NetCoreBackend.Core.Aspects.Autofac.Validation;
using NetCoreBackend.Core.CrossCuttingConcerns.Validation;
using NetCoreBackend.Core.Utilities.Business;
using NetCoreBackend.Core.Utilities.Results.Abstract;
using NetCoreBackend.Core.Utilities.Results.Concrate;
using NetCoreBackend.DataAccess.Abstract;
using NetCoreBackend.Entities.Concrate;
using NetCoreBackend.Entities.DTOs;

namespace NetCoreBackend.Business.Concrate
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator))] // Bu methodu ProductValidator kullanarak doğrular
        public IResult Add(Product entity)
        {
            var results = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(entity.CategoryId), CheckIfProductNameExists(entity.ProductName), CheckIfCategoryLimitExceded());

            if (results != null)
            {
                return results;
            }
            _productDal.Add(entity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult();

        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new DataResult<List<Product>>(_productDal.GetAll(), true, Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryList(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.CategoryId == categoryId));
        }

        public IDataResult<Product> GetById(int TId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == TId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal minPrice, decimal maxPrice)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.UnitPrice >= minPrice && x.UnitPrice <= maxPrice));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        public IResult Update(Product entity)
        {
            _productDal.Update(entity);
            return new Result(true, "Güncelleme Başarılı");

        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count();
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }


    }
}
