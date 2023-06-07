using System.Security.Claims;

namespace aspnetcore_tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;
        public UsersController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterResource resource)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(resource.Password);

            var user = new User
            {
                Username = resource.Username.ToLower(),
                Email = resource.Email,
                PasswordHash = passwordHash,
                RoleId = resource.RoleId
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            return Ok(new
            {
                Username = user.Username,
                Email = user.Email
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserResource resource)
        {
            var user = await context.Users.Where(u => u.Username == resource.Username.ToLower()).FirstOrDefaultAsync();
            if (user == null)
                return BadRequest("User not found");

            if (!BCrypt.Net.BCrypt.Verify(resource.Password, user.PasswordHash))
                return BadRequest("Password is wrong");

            return Ok();
        }

        // private string CreateToken(User user)
        // {
        //     var claims = new List<Claim>{ new Claim()};
        // }
    }
}