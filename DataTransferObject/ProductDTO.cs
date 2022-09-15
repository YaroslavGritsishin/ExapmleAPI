using AutoMapper;
using DomainEntity;
using EntitiesDataLayer;

namespace DataTransferObject
{
    public static class ProductDTO
    {
        public static MapperConfiguration ToEntityMap() => new MapperConfiguration(cfg => 
        {
            cfg.CreateMap<ProductDomain, ProductEntity>()
                .ForMember(src => src.Name, opt => opt.MapFrom(target => target.ProductName))
                .ForPath(src => src.Category.CategoryName, opt => opt.MapFrom(target => target.CategoryName))
                .ForMember(src => src.Price, opt => opt.MapFrom(target => double.Parse(target.ProductPrice)))
                .ForMember(src => src.Id, opt => opt.MapFrom(target => target.ProductId));
        });
        public static MapperConfiguration ToDomainMap() => new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ProductEntity, ProductDomain>()
                .ForMember(src => src.ProductName, opt => opt.MapFrom(target => target.Name))
                .ForPath(src => src.CategoryName, opt => opt.MapFrom(target => target.Category.CategoryName))
                .ForMember(src => src.ProductPrice, opt => opt.MapFrom(target => target.Price.ToString()))
                .ForMember(src => src.ProductId, opt => opt.MapFrom(target => target.Id));
        });
        
        public static ProductEntity ToEntity(this ProductDomain product) => new Mapper(ToEntityMap()).Map<ProductDomain, ProductEntity>(product);
        public static IEnumerable<ProductEntity> ToEntity(this IEnumerable<ProductDomain> product) => new Mapper(ToEntityMap())
            .Map<IEnumerable<ProductDomain>, IEnumerable<ProductEntity>>(product);

        public static ProductDomain ToDomain(this ProductEntity product) => new Mapper(ToDomainMap()).Map<ProductEntity, ProductDomain>(product);
        public static IEnumerable<ProductDomain> ToDomain(this IEnumerable<ProductEntity> product) => new Mapper(ToDomainMap())
            .Map<IEnumerable<ProductEntity>, IEnumerable<ProductDomain>>(product);
        

    }
}