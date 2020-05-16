using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ajuda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository;

namespace Novo_Dev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "admin")]
    public class UserController : ControllerBase
    {
        private readonly Context context;
        public UserController(Context context)
        {
            this.context = context;
        }

        private static dynamic MapUser(User user)
        {
            return new
            {
                Id = user.UserId,
                Username = user.Nome
            };
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetUsers()
        {
            return await context.Users.Select(u => MapUser(u)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetUser(string id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return MapUser(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            user.Senha = AuthenticationHelper.ComputeHash(user.Senha);

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, MapUser(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
