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
            //var universityNameFilter = userGetProfilesToMatchDTO.University;
            List<ProfileToShowInMatching> usersToReturn;
            if (userGetProfilesToMatchDTO.UniversityFilter is null || userGetProfilesToMatchDTO.UniversityFilter == "")
            {
                //usersToReturn = await (from us in _context.User
                //                       from un in _context.University
                //                       where un.Name == us.UniversityAttendance
                //                       select new ProfileToShowInMatching
                //                       {
                //                           Name = us.Name,
                //                           University = un.Name,
                //                           Description = us.Description,
                //                           Gender = us.Gender,
                //                           Id = us.PersonId
                //                       }).ToListAsync();

                //var leftOuterJoinQuery =
                //    from us in _context.User
                //    join ua in _context.UniversityAttendance on us.ID equals ua.CategoryID into prodGroup
                //    from item in prodGroup.DefaultIfEmpty(new Product { Name = String.Empty, CategoryID = 0 })
                //    select new { CatName = _context.User.Name, ProdName = item.Name };



                //_context.User
                //    .FromSqlRaw("select * from person p inner join UniversityAttendance ua on ua.UserId = p.PersonId inner join University u on ua.UniversityId = u.UniversityId
                //")
                //    .ToList();


                //_context.User.Include(u => u.UniversityAttendance).Include(a => a.)


                //List<User> users = _context.User.ToList();
                //List<UniversityAttendance> universityAttendances = _context.UniversityAttendance.ToList();
                //List<University> universities = _context.University.ToList();

                //var employeeRecord = from e in users
                //                     join d in universityAttendances on e.PersonId equals d.UserId into table1
                //                     from d in table1.ToList()
                //                     join i in universities on d.UniversityId equals i.UniversityId into table2
                //                     from i in table2.ToList()
                //                     select new ProfileToShowInMatching
                //                     {
                //                         employee = e,
                //                         department = d,
                //                         incentive = i
                //                     };


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
                //await _context..Where(u => u.UniversityAttendance.).ToListAsync();

                //var foundUser =
                //    (from users in _context.User
                //        join roles in _context.UniversityAttendance on users. equals roles.Name
                //        where users.Name == user.Name && users.Password == user.Password
                //        select new UserRoleView { Id = users.Id, Name = user.Name, Role = roles.Name }).FirstOrDefaultAsync()
                //    .Result;

                //var query = _context.University.Where(u => u.Name == userGetProfilesToMatchDTO.University).SelectMany(u => );

                //var query1 = from u in _context.User
                //    where u..Any(c => c.Category_ID == cat_id)
                //    select u;


                //usersToReturn = await (from us in _context.User
                //                       from un in _context.University
                //                       where un.Name == userGetProfilesToMatchDTO.University
                //                       select us).ToListAsync();
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
                //usersToReturn =
                //    usersToReturn.FindAll(u => u.Universities.(u => u.Name == userGetProfilesToMatchDTO.UniversityFilter));

                //usersToReturn = usersToReturn.Where(p =>
                //    p.Universities.Exists(un => un.Name == userGetProfilesToMatchDTO.UniversityFilter)).ToList();
            }

            return usersToReturn;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<UserView>> LogIn(UserLogInDTO userLogInDTO /*[FromForm] ImageDTO img*/)
        {
            //var existingUser = _context.User.Include("UniversityAttendance").Include("University").FirstOrDefaultAsync(u => u.Email == userLogInDTO.Email && u.PasswordHash == userLogInDTO.Password).Result;



            var existingUser = _context.User
                .FirstOrDefaultAsync(u => u.Email == userLogInDTO.Email && u.PasswordHash == userLogInDTO.Password)
                .Result;
            if (existingUser is null) return NotFound();

            return new UserView
            {
                Id = existingUser.PersonId,
                Email = existingUser.Email
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