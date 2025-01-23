using Microsoft.EntityFrameworkCore;

using CrudApi.DTOs;
using CrudApi.Context;
using CrudApi.Entities;

namespace CrudApi.Services
{
    public class EmpleadoService
    {
        private readonly AppDbContext _appDbContext;

        public EmpleadoService(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task<List<EmpleadoDTO>> Lista()
        {
            var listaDTO = new List<EmpleadoDTO>();

            var listaDB = await _appDbContext.Empleados.Include(p => p.PerfilReferencia).ToListAsync();

            foreach (var item in listaDB)
            {
                listaDTO.Add(new EmpleadoDTO
                {
                    IdEmpleadoDTO = item.IdEmpleado,
                    NombreEmpleadoDTO = item.NombreEmpleado,
                    SueldoEmpleadoDTO = item.Sueldo,
                    IdPerfilDTO = item.IdPerfil,
                    NombrePerfilDTO = item.PerfilReferencia.Nombre
                });
            }
            return listaDTO;
        } 

        public async Task<EmpleadoDTO> ListaPorID(int id)
        {
            var empleadoDTO = new EmpleadoDTO();
            var empleadoDB = await _appDbContext.Empleados.Include(p => p.PerfilReferencia).Where(e => e.IdEmpleado == id).FirstAsync();

            empleadoDTO.IdEmpleadoDTO = id;
            empleadoDTO.NombreEmpleadoDTO = empleadoDB.NombreEmpleado;
            empleadoDTO.SueldoEmpleadoDTO = empleadoDB.Sueldo;
            empleadoDTO.IdPerfilDTO = empleadoDB.IdPerfil;  
            empleadoDTO.NombrePerfilDTO = empleadoDB.PerfilReferencia.Nombre;

            return empleadoDTO;
        }

        public async Task<string> GuardarRegistro(EmpleadoDTO empleadoDTO)
        {
            var empleadoDB = new Empleado
            {
                NombreEmpleado = empleadoDTO.NombreEmpleadoDTO,
                Sueldo = empleadoDTO.SueldoEmpleadoDTO,
                IdPerfil = empleadoDTO.IdPerfilDTO
            };

            await _appDbContext.Empleados.AddAsync(empleadoDB);
            await _appDbContext.SaveChangesAsync();

            return "Empleado guardado exitosamente";
        }

        public async Task<string> EditarEmpleado(EmpleadoDTO empleadoDTO)
        {
             var empleadoDB = await _appDbContext.Empleados.Include(p => p.PerfilReferencia)
                .Where(e => e.IdEmpleado == empleadoDTO.IdEmpleadoDTO).FirstAsync();

            if(empleadoDB  is null){
                 return "Empleado con el ID no encontrado";
            }
            
            empleadoDB.NombreEmpleado = empleadoDTO.NombreEmpleadoDTO;
            empleadoDB.Sueldo = empleadoDTO.SueldoEmpleadoDTO;
            empleadoDB.IdPerfil = empleadoDTO.IdPerfilDTO;

            _appDbContext.Empleados.Update(empleadoDB);
            await _appDbContext.SaveChangesAsync();
            
            return "Empleado modificado";
        }

        public async Task<string> EliminarEmpleado(int id)
        {
             var empleadoDB = await _appDbContext.Empleados.FindAsync(id);

            if(empleadoDB  is null){
                 return "Empleado con el ID no encontrado";
            }

            _appDbContext.Empleados.Remove(empleadoDB);
            await _appDbContext.SaveChangesAsync();
            
            return "Empleado eliminado";
        }
    }
}