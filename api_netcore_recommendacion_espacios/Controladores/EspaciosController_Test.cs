using api_netcore_recommendacion_espacios.Data;
using api_netcore_recommendacion_espacios.Modelo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api_netcore_recommendacion_espacios.Controladores
{
    [Route("rec_espacios/espacios")]
    [ApiController]
    public class EspaciosController_Test : ControllerBase
    {
        private readonly IEspaciosTestRepo _repo;
        public EspaciosController_Test(IEspaciosTestRepo repo)
        {
            _repo = repo;
            _repo.CreateData();
        }
        [HttpGet]
        public ActionResult <IEnumerable<Espacios_Test>> GetAllEspacios()
        {
            var espacioItems = _repo.GetAllEspacios();
            return Ok(espacioItems);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Espacios_Test>> GetEspaciosById(int id)
        {
            var espacioItem = _repo.GetEspaciosById(id);
            if (espacioItem != null) return Ok(espacioItem);
            else return BadRequest();
        }

    }
}
