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
                Username = resource.Username,
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
    }
}