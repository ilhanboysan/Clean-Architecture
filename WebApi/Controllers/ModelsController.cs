﻿using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDnamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistance.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListmodelQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListModelListitemDto> response = await Mediator.Send(getListmodelQuery);
            return Ok(response);
        }
        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery = null)
        {
            GetListByDnamicModelQuery getListByDynamicmodelQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
            GetListResponse<GetListByDnamicModelListItemDto> response = await Mediator.Send(getListByDynamicmodelQuery);
            return Ok(response);
        }
    }
}
