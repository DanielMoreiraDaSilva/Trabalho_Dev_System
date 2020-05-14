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
    [Authorize]
    public class FranquiaController : ControllerBase
    {
        private readonly Context context;
        public FranquiaController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var franquias = context.Franquias;
            return Ok(franquias);
        }

        [HttpGet("Search")]
        public IActionResult GetByName([FromBody] string nome)
        {
            var franquia = context.Franquias.FirstOrDefault(c => c.Nome == nome);
            return Ok(franquia);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void Post(Franquia franquia)
        {
            context.Franquias.Add(franquia);
            context.SaveChanges();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public void Put(Franquia franquia)
        {
            context.Franquias.Update(franquia);
            context.SaveChanges();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(string id)
        {
            var franquia = context.Franquias.Find(id);
            context.Franquias.Remove(franquia);
            context.SaveChanges();                   
        }
    }
}