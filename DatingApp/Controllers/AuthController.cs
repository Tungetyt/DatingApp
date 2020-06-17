using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<ProfileToShowInMatching>>> GetUserToMatch(UserGetProfilesToMatchDTO userGetProfilesToMatchDTO)
        {
            List<ProfileToShowInMatching> usersToReturn;
            if (userGetProfilesToMatchDTO.UniversityFilter is null || userGetProfilesToMatchDTO.UniversityFilter == "")
            {
                //https://stackoverflow.com/questions/15829309/remove-item-have-same-key-in-list-c-sharp
                var usersToReturn1 = await (from us in _context.User
                                            from un in _context.University
                                            from ua in _context.UniversityAttendance
                                            where us.PersonId != userGetProfilesToMatchDTO.Id && us.PersonId == ua.UserId && un.UniversityId == ua.UniversityId
                                            select new ProfileToShowInMatching
                                            {
                                                Name = us.Name,
                                                Universities = new List<University> { un },
                                                Description = us.Description,
                                                Gender = us.Gender,
                                                Id = us.PersonId
                                            }).ToListAsync();
                usersToReturn = usersToReturn1.GroupBy(t => t.Id).Select(g => g.First()).ToList();
            }
            else
            {
                usersToReturn = await (from us in _context.User
                                       from un in _context.University
                                       from ua in _context.UniversityAttendance
                                       where un.Name == userGetProfilesToMatchDTO.UniversityFilter && us.PersonId != userGetProfilesToMatchDTO.Id && us.PersonId == ua.UserId && un.UniversityId == ua.UniversityId
                                       select new ProfileToShowInMatching
                                       {
                                           Name = us.Name,
                                           Universities = new List<University> { un },
                                           Description = us.Description,
                                           Gender = us.Gender,
                                           Id = us.PersonId
                                       }).ToListAsync();
            }

            return usersToReturn;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<UserView>> LogIn(UserLogInDTO userLogInDTO /*[FromForm] ImageDTO img*/)
        {
            var existingUser = _context.User
                .FirstOrDefaultAsync(u => u.Email == userLogInDTO.Email && u.PasswordHash == userLogInDTO.Password)
                .Result;
            if (existingUser is null) return NotFound();

            return new UserView
            {
                Id = existingUser.PersonId,
                Email = existingUser.Email
            };
        }

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