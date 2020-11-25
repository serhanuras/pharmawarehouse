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
using PharmaWarehouse.Api.Services;
using PharmaWarehouse.Api.Services.Interfaces;

namespace PharmaWarehouse.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase<Role, RoleDto, RoleUpsertDto>
    {
        private readonly IRoleService roleService;
        private readonly IMapper mapper;

        public RoleController(
            ILogger<RoleController> logger,
            IMapper mapper,
            IRoleService roleService)
            : base(logger, mapper, roleService)
        {
            this.mapper = mapper;
            this.roleService = roleService;
        }

        /// <summary>
        /// Get Item Type By Id. Alsinda su ise yariyor.
        /// </summary>
        /// <param name="paginationDto">PaginationDto object.</param>
        /// <returns>List of RoleDto.</returns>
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(RoleDto), 200)]
        [HttpPost]
        public new ActionResult<List<RoleDto>> GetPageData([FromQuery] PaginationDto paginationDto)
        {
            return base.GetPageData(paginationDto);
        }

        /// <summary>
        /// Get Item Type By Id.
        /// </summary>
        /// <param name="id">Id of the item to get.</param>
        /// <returns>RoleDto.</returns>
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(RoleDto), 200)]
        [HttpGet("{id}")]
        public new ActionResult<RoleDto> GetById(long id)
        {
            return base.GetById(id);
        }

        /// <summary>
        /// Upserting Item.
        /// </summary>
        /// <param name="roleUpsertDto">UpserDto object.</param>
        /// <returns>RoleDto.</returns>
        [HttpPost("[action]")]
        public new ActionResult<RoleDto> Upsert(RoleUpsertDto roleUpsertDto)
        {
            return base.Upsert(roleUpsertDto);
        }

        /// <summary>
        /// Delete a item.
        /// </summary>
        /// <param name="id">Id of the item to delete.</param>
        /// <returns>RoleDto.</returns>
        [HttpDelete("{id}")]
        public new ActionResult<RoleDto> Delete(long id)
        {
            return base.Delete(id);
        }
    }
}
