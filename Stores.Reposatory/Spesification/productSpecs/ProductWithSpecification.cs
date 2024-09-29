using Stores.Data.Entities;

namespace Stores.Reposatory.Spesification.productSpecs
{
    public class ProductWithSpecification : BaseSpesfication<Product>
    {
        public ProductWithSpecification(ProductSpecification Specs)
            : base(Product => (!Specs.BrandId.HasValue || Product.BrandId == Specs.BrandId.Value)
            && (!Specs.TypeId.HasValue || Product.TypeId == Specs.TypeId.Value)
            && (string.IsNullOrEmpty(Specs.Search) || Product.Name.Trim().ToLower().Contains(Specs.Search)))
        {
            AddIclude(x => x.BrandId);
            AddIclude(x => x.TypeId);
            AddIclude(x=> x.Name);

            ApplyPagination(Specs.PageIndex,Specs.PageSize);
            if (!string.IsNullOrEmpty(Specs.Sort))
            {
               switch(Specs.Sort)
               {
                    case "PriceAsc":
                        AddOrderBy(x=>x.Price);
                        break;
                    case "priceDecs":
                        AddOrderByDesending(x=>x.Price);
                        break;
                    default:
                        AddOrderBy(x=>x.Name);
                        break;

               }
            }
        }
        public ProductWithSpecification(int? id)
           : base(Product =>Product.Id==id)
        {
            AddIclude(x => x.BrandId);
            AddIclude(x => x.TypeId);
        }
           
    }
}
