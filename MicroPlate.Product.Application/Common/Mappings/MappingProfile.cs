using AutoMapper;
using MicroPlate.Product.Application.Product.Commands.CreateProduct;
using MicroPlate.Product.Application.Product.Commands.UpdateProduct;
using System.Reflection;

namespace MicroPlate.Product.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateProductCommand, Domain.Entities.Product>();
        CreateMap<UpdateProductCommand, Domain.Entities.Product>();
        //Auto Mapping for classes implemented with IMapFrom<SourceType>
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();
        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping") ??
                                            type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}
