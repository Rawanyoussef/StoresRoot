using Stores.Reposatory.Spesification.productSpecs;
using Stores.Services.Services.ProductServices.Dto;

namespace Stores.Services.ProductServices.Product
{
    public interface IProductServices
    {
        Task<ProductDetailsDto> GetProductByIdAsync(int? productId);
        Task<PaginationResultDto<ProductDetailsDto>> GetAllProductAsync(ProductSpecification productSpecification);
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync();
        Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync();
    }
}
 