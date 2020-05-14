using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository;

namespace Novo_Dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context context;

        private readonly ILoginService loginService;

        public LoginController(Context context, ILoginService loginService)
        {
            this.context = context;
            this.loginService = loginService;
        }

        [HttpPost]
        public ActionResult<dynamic> Authenticate([FromBody]Login login)
        {
            var result = loginService.Authenticate(login);            
            
            if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Username)) {
                return BadRequest();
            }

            if (result.user == null)
                return NotFound();

            if (result.token == null)
                return Forbid();            
                        
            return new
            {
                user = result.user,
                token = result.token
            };
        }
    }
}