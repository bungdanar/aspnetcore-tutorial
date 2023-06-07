namespace aspnetcore_tutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IConfiguration configuration;
        public UsersController(AppDbContext context, IConfiguration configuration)
        {
            this.configuration = configuration;
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

            var token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtPrivateKey"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}