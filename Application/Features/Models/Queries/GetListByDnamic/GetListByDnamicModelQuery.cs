using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Dynamic;
using Core.Persistance.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListByDnamic;

public class GetListByDnamicModelQuery : IRequest<GetListResponse<GetListByDnamicModelListItemDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDnamicModelQueryHandler : IRequestHandler<GetListByDnamicModelQuery, GetListResponse<GetListByDnamicModelListItemDto>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetListByDnamicModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByDnamicModelListItemDto>> Handle(GetListByDnamicModelQuery request, CancellationToken cancellationToken)
        {
            Paginate<Model> models = await _modelRepository.GetListByDynamicAsync(
                 request.DynamicQuery,
                 include: m => m.Include(m => m.Brand).Include(m => m.Fuel).Include(m => m.Transmission),
                 index: request.PageRequest.PageIndex,
                 size: request.PageRequest.PageSize
                 );
            var response = _mapper.Map<GetListResponse<GetListByDnamicModelListItemDto>>(models);
            return response;

        }
    }
}
