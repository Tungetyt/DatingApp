using System;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.DTO;
using DatingApp.Models;
using DatingApp.RequestModels;
using DatingApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Prototype1Context _context;

        public AuthController(Prototype1Context context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<UserView>> LogIn(UserLogInDTO userLogInDTO /*[FromForm] ImageDTO img*/)
        {
            //var existingUser = _context.User.Include("UniversityAttendance").Include("University").FirstOrDefaultAsync(u => u.Email == userLogInDTO.Email && u.PasswordHash == userLogInDTO.Password).Result;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine('f');
            }
            var test = _context.User.ToList();

            ;
            var existingUser = test;
            //var existingUser = _context.User
            //    .FirstOrDefaultAsync(u => u.Email == userLogInDTO.Email && u.PasswordHash == userLogInDTO.Password)
            //    .Result;
            if (existingUser is null) return NotFound();

            return new UserView
            {
                Id = /*existingUser.PersonId*/"",
                Email = /*existingUser.Email*/""
                //University = existingUser.Name
            };
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserView>> SignUp(UserSignUpDTO userSignUpDto /*[FromForm] ImageDTO img*/)
        {
            var isEmailTaken = _context.User.AnyAsync(u => u.Email == userSignUpDto.Email).Result;
            if (isEmailTaken) return NotFound();

            var newUser = new User
            {
                PersonId = Guid.NewGuid().ToString(),
                Email = userSignUpDto.Email,
                Name = userSignUpDto.Name,
                PasswordHash = userSignUpDto.Password
            };


            var existingUniversity =
                _context.University.FirstOrDefaultAsync(u => u.Name == userSignUpDto.University).Result;
            var universityToAssign = existingUniversity;
            if (existingUniversity is null)
            {
                var newUniversity = new University
                {
                    UniversityId = Guid.NewGuid().ToString(),
                    Name = userSignUpDto.University
                };

                universityToAssign = newUniversity;
                await _context.University.AddAsync(newUniversity);
            }

            await _context.User.AddAsync(newUser);
            await _context.UniversityAttendance.AddAsync(new UniversityAttendance
            {
                University = universityToAssign,
                User = newUser
            });

            await _context.SaveChangesAsync();

            return new UserView
            {
                Id = newUser.PersonId,
                Email = newUser.Email,
                University = universityToAssign.Name
            };
        }
    }
}