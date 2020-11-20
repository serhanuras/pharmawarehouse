using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PharmaWarehouse.Api.Dto;
using PharmaWarehouse.Api.Dtos;
using PharmaWarehouse.Api.Entities;
using PharmaWarehouse.Api.Modules.Attributes;
using PharmaWarehouse.Api.Services;

namespace PharmaWarehouse.Api.Controllers
{
    [ApiController]
    public abstract class ControllerBase<TEntity, TDto, TUpsertDto> : Controller
        where TEntity : class, IEntityBase
        where TDto : class, IDto
        where TUpsertDto : class, IUpsertDto
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IServiceBase<TEntity> service;

        public ControllerBase(
            ILogger logger,
            IMapper mapper,
            IServiceBase<TEntity> service)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.service = service;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public ActionResult GetPageData(PaginationDto paginationDto)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var item = this.service.GetPageData(paginationDto.Page, paginationDto.RecordsPerPage);

            if (item == null && item.Count > 0)
            {
                this.logger.LogWarning($"There is not any record.");
                return this.NotFound();
            }

            var dtoItem = this.mapper.Map<List<TDto>>(item);

            return this.Ok(dtoItem);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public ActionResult GetById(long id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var item = this.service.Get(id);

            if (item == null)
            {
                this.logger.LogWarning($"There is not record according to this id. Id is {id}");
                return this.NotFound();
            }

            var dtoItem = this.mapper.Map<TDto>(item);

            return this.Ok(dtoItem);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public ActionResult Upsert(TUpsertDto upsertDto)
        {
            TEntity item = this.service.Upsert(this.mapper.Map<TEntity>(upsertDto));

            var itemDto = this.mapper.Map<TDto>(item);

            return new CustomCreatedAtRouteResult(itemDto.Id, itemDto);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public ActionResult Delete(long id)
        {
            var entity = this.service.Get(id);

            this.service.Delete(id);

            return this.Ok(entity);
        }
    }
}
