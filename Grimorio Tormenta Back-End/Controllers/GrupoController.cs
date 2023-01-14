using GrimorioTormenta.Intefaces.Repositorio;
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
        private readonly IGrupoRepositorio rep;

        public GrupoController(IGrupoRepositorio GrupoRep)
        {
            rep = GrupoRep;
        }

        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<GrupoModel>? GetAll()
        {
            return rep.GetAll();
        }
    }
}
