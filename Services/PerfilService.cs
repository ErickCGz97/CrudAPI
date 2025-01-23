using Microsoft.EntityFrameworkCore;

using CrudApi.DTOs;
using CrudApi.Context;

namespace CrudApi.Services
{
    public class PerfilService
    {
        private readonly AppDbContext _appDbContext;

        public PerfilService(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task<List<PerfilDTO>> Lista()
        {
            var listaDTO = new List<PerfilDTO>();

            foreach (var item in await _appDbContext.Perfiles.ToListAsync()){
                listaDTO.Add(new PerfilDTO
                {
                    IdPerfil = item.IdPerfil,
                    Nombre = item.Nombre,
                });
            }

            return listaDTO;
        }
    }
}