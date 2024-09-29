namespace Stores.Reposatory.Spesification.productSpecs
{
    public class ProductSpecification
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }
        public int PageIndex { get; set; } = 1;
        private int _PageSize = 6;
        private const int MAXPAGESIZE = 50;
        public int PageSize
        {
            get => _PageSize;
            set => _PageSize =(value> MAXPAGESIZE)?int.MaxValue:value;
        }
        private string? _Search;
        public string Search
        {
            get=>_Search; 
            set => _Search = value?.Trim().ToLower();
        }

    }
}