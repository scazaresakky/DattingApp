using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class UsersController: BaseApiController
    {

        private readonly DataContext _context;
        public UsersController(DataContext context){
            _context = context;
        }


        //Endpoints 


        //
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Entities.AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Entities.AppUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }

    }
}