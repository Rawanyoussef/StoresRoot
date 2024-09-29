using AutoMapper;
using Stores.Data.Entities;
using Stores.Reposatory.Interface;
using Stores.Reposatory.Spesification.productSpecs;
using Stores.Services.ProductServices.Product;
using Stores.Services.Services.ProductServices.Dto;
using ProductEntity = Stores.Data.Entities.Product;
namespace Stores.Services.Services.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsNoTrakingAsync();
            var mappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(brands);

            return mappedBrands;
        }

     

        public async Task<PaginationResultDto<ProductDetailsDto>> GetAllProductAsync(ProductSpecification productSpecification)
        {
            var specs = new ProductWithSpecification(productSpecification);
            var product = await _unitOfWork.Repository<ProductEntity, int>().GetWithSpecificationByIdAsync(specs);
            var products = await _unitOfWork.Repository<ProductEntity, int>().GetAllAsNoTrakingAsync();

            var countSpecs = new ProductWithCountSpecification(productSpecification);
            var count =await _unitOfWork.Repository<ProductEntity,int>().GetCountSpecificationAsync(countSpecs);
            var mappedProducts = _mapper.Map<IReadOnlyList<ProductDetailsDto>>(products);



            return  new PaginationResultDto<ProductDetailsDto>(productSpecification.PageIndex, productSpecification.PageSize , count ,mappedProducts);
        }

   

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductTypes, int>().GetAllAsNoTrakingAsync();
            var mappedTypes = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(types);


            return mappedTypes;
        }

        public async Task<ProductDetailsDto> GetProductByIdAsync(int? productId)
        {
            if (productId is null)
                throw new Exception("Id is Null");
            var specs = new ProductWithSpecification(productId);

            var product = await _unitOfWork.Repository<ProductEntity, int>().GetWithSpecificationByIdAsync(specs);
            if (product is null)
                throw new Exception("Product Not Found");

            var mappedProduct = _mapper.Map<ProductDetailsDto>(product);

            return mappedProduct;
        }
    }
}
