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
    public class EmpleadoController: ControllerBase
    {
        private readonly EmpleadoService _empleadoService;

        public EmpleadoController(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        //Listado de todos los valores en la tabla Empleado
        [HttpGet]
        [Route("Lista Empleados")]
        public async Task<ActionResult<List<EmpleadoDTO>>> Get()
        {
            return Ok(await _empleadoService.Lista());
        }
        
        //Mostra un unico valor con un Id especifico
        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<ActionResult<EmpleadoDTO>>Get(int id)
        {
            var empleadoDTO = await _empleadoService.ListaPorID(id);
            
            return Ok(empleadoDTO);
        } 

        //Guardar un registro en la tabla
        [HttpPost]
        [Route("Crear")]
        public async Task<ActionResult> Guardar(EmpleadoDTO empleadoDTO)
        {   
            var resultado = await _empleadoService.GuardarRegistro(empleadoDTO);
            return Ok(resultado);
        }

        //Editar un registro ya ingresado
        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult<EmpleadoDTO>> Editar(EmpleadoDTO empleadoDTO)
        {
           var result = await _empleadoService.EditarEmpleado(empleadoDTO);
            return Ok(result);
        }

        
        [HttpDelete]
        [Route("Eliminar/{id}")]   
        public async Task<ActionResult<EmpleadoDTO>> Eliminar(int id)
        {
            var result = await _empleadoService.EliminarEmpleado(id);            
            return Ok(result);
        }  
    }
}