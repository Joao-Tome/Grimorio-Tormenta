using GrimorioTormenta.Intefaces.Instancia;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Models;
using GrimorioTormenta.Repositorio.Config;
using GrimorioTormenta.Repositorio.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Grimorio_Tormenta_Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoInstancia _instancia;

        public GrupoController(IGrupoInstancia grupoInstancia)
        {
            _instancia = grupoInstancia;
        }

        [HttpGet]
        public IEnumerable<GrupoDTO>? GetAll()
        {
            return _instancia.GetInstancias();
        }
    }
}
