using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDnamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistance.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //CreateMap<Model, GetListModelListitemDto>().ReverseMap(); farklı dtoda isimler aynı ise automapper eşleştirme yapabilir yapamaığı durumlarda yukarıdaki kullanılır...
        CreateMap<Model, GetListModelListitemDto>()
            .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
            .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
            .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name))
            .ReverseMap();
        CreateMap<Model, GetListByDnamicModelListItemDto>()
          .ForMember(destinationMember: c => c.BrandName, memberOptions: opt => opt.MapFrom(c => c.Brand.Name))
          .ForMember(destinationMember: c => c.FuelName, memberOptions: opt => opt.MapFrom(c => c.Fuel.Name))
          .ForMember(destinationMember: c => c.TransmissionName, memberOptions: opt => opt.MapFrom(c => c.Transmission.Name))
          .ReverseMap();

        CreateMap<Paginate<Model>, GetListResponse<GetListModelListitemDto>>().ReverseMap();
        CreateMap<Paginate<Model>, GetListResponse<GetListByDnamicModelListItemDto>>().ReverseMap();
    }
}
