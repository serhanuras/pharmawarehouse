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
    public class UserController : ControllerBase<User, UserDto, UserUpsertDto>
    {
        private readonly IUserService<User> userService;
        private readonly IMapper mapper;

        public UserController(
            ILogger<UserController> logger,
            IMapper mapper,
            IUserService<User> userService)
            : base(logger, mapper, userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        /// <summary>
        /// Get Item Type By Id.
        /// </summary>
        /// <param name="paginationDto">PaginationDto object.</param>
        /// <returns>List of UserDto.</returns>
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(UserDto), 200)]
        [HttpPost]
        public new ActionResult<List<UserDto>> GetPageData([FromQuery] PaginationDto paginationDto)
        {
            return base.GetPageData(paginationDto);
        }

        /// <summary>
        /// Get Item Type By Id.
        /// </summary>
        /// <param name="id">Id of the item to get.</param>
        /// <returns>UserDto.</returns>
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(UserDto), 200)]
        [HttpGet("{id}")]
        public new ActionResult<UserDto> GetById(long id)
        {
            return base.GetById(id);
        }

        /// <summary>
        /// Upserting Item.
        /// </summary>
        /// <param name="userUpsertDto">UpserDto object.</param>
        /// <returns>UserDto.</returns>
        [HttpPost("[action]")]
        public new ActionResult<UserDto> Upsert(UserUpsertDto userUpsertDto)
        {
            return base.Upsert(userUpsertDto);
        }

        /// <summary>
        /// Delete a item.
        /// </summary>
        /// <param name="id">Id of the item to delete.</param>
        /// <returns>UserDto.</returns>
        [HttpDelete("{id}")]
        public new ActionResult<UserDto> Delete(long id)
        {
            return base.Delete(id);
        }
    }
}