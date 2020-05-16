using System.Linq;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;

namespace Novo_Dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranquiaController : ControllerBase
    {
        private readonly Context context;
        public FranquiaController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var franquias = context.Franquias;
            return Ok(franquias);
        }

        [HttpGet("Search")]
        [Authorize]
        public IActionResult GetByName([FromQuery] string nome)
        {
            var franquia = context.Franquias.FirstOrDefault(c => c.Nome == nome);
            return Ok(franquia);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public void Post(Franquia franquia)
        {
            context.Franquias.Add(franquia);
            context.SaveChanges();
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public void Put(Franquia franquia)
        {
            context.Franquias.Update(franquia);
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string id)
        {
            var franquia = context.Franquias.Find(id);
            context.Franquias.Remove(franquia);
            context.SaveChanges();
            return Ok();                 
        }
    }
}