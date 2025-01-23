using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using CrudApi.Context;
using CrudApi.Entities;
using CrudApi.DTOs;
using CrudApi.Services;

namespace CrudApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly PerfilService _perfilService;

        public PerfilController(PerfilService context)
        {
            _perfilService = context;
        }

        [HttpGet]
        [Route("Lista Perfiles")]
        public async Task<ActionResult<List<PerfilDTO>>> Get()
        {
            return Ok(await _perfilService.Lista());
        }
    }
}