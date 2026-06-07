using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new()
        {
            new User
            {
                Id = 1,
                Name = "John Doe",
                Email = "john@example.com",
                Department = "IT"
            }
        };

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var user = users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return NotFound(
                        $"User with ID {id} not found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                user.Id = users.Any()
                    ? users.Max(u => u.Id) + 1
                    : 1;

                users.Add(user);

                return CreatedAtAction(
                    nameof(GetUser),
                    new { id = user.Id },
                    user);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return NotFound(
                        $"User with ID {id} not found");
                }

                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;
                user.Department = updatedUser.Department;

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return NotFound(
                        $"User with ID {id} not found");
                }

                users.Remove(user);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"An error occurred: {ex.Message}");
            }
        }
    }
}