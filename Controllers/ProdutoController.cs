using System.Linq;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace Novo_Dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly Context context;
        public ProdutoController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var produtos = context.Produtos;
            return Ok(produtos);
        }

        [HttpGet("Search")]
        [Authorize]
        public IActionResult GetByName([FromQuery] string nome)
        {
            var produto = context.Produtos.FirstOrDefault(c => c.Nome == nome);
            return Ok(produto);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public void Post(Produto produto)
        {
            context.Produtos.Add(produto);
            context.SaveChanges();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put([FromBody]Produto produto)
        {
            context.Produtos.Update(produto);
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(string id)
        {
            var produto = context.Produtos.FirstOrDefault(c => c.ProdutoId == id);
            context.Produtos.Remove(produto);
            context.SaveChanges();   
            return Ok();                
        }
    }
}