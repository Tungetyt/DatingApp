using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.DTO;
using DatingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Prototype1Context _context;

        public UsersController(Prototype1Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> GetUserToMatch(UserGetProfilesToMatchDTO userGetProfilesToMatchDTO)
        {
            //var universityNameFilter = userGetProfilesToMatchDTO.University;
            List<User> usersToReturn;
            if (userGetProfilesToMatchDTO.UniversityFilter is null || userGetProfilesToMatchDTO.UniversityFilter == "")
                usersToReturn = await _context.User.ToListAsync();
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


                usersToReturn = await (from us in _context.User
                                       from un in _context.University
                                       where un.Name == userGetProfilesToMatchDTO.UniversityFilter
                                       select us).ToListAsync();
            }

            return usersToReturn;
        }

        // GET: api/Users/5
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _context.User.ToListAsync();

            if (users == null) return NotFound();

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, User user)
        {
            if (id != user.PersonId) return BadRequest();

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.PersonId))
                    return Conflict();
                throw;
            }

            return CreatedAtAction("GetUser", new { id = user.PersonId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null) return NotFound();

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(string id)
        {
            return _context.User.Any(e => e.PersonId == id);
        }
    }
}