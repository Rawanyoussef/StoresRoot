using Stores.Data.Entities;

namespace Stores.Reposatory.Spesification.productSpecs
{
    public class ProductWithCountSpecification : BaseSpesfication<Product>
    {
        public ProductWithCountSpecification(ProductSpecification Specs)
        : base(Product => (!Specs.BrandId.HasValue || Product.BrandId == Specs.BrandId.Value)
               && (!Specs.TypeId.HasValue || Product.TypeId == Specs.TypeId.Value)
             && (string.IsNullOrEmpty(Specs.Search)||Product.Name.Trim().ToLower().Contains(Specs.Search)))
        {
        }
    }
}
