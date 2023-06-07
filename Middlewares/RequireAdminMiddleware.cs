namespace aspnetcore_tutorial.Middlewares
{
    public class RequireAdminMiddleware
    {
        private readonly RequestDelegate next;
        public RequireAdminMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, AppDbContext dbContext)
        {
            if (context.User.Identity is not null && context.User.Identity.IsAuthenticated)
            {
                var userId = Int32.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                var user = await dbContext.Users.Where(u => u.Id == userId).Include(u => u.Role).SingleOrDefaultAsync();
                if (user is null)
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsync("User not found");
                    return;
                }

                if (user.RoleId == 1)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("You are not admin");
                    return;
                }

                var claims = new List<Claim> { new Claim(ClaimTypes.Role, "ADMIN") };
                context.User.AddIdentity(new ClaimsIdentity(claims));
            }

            await next(context);
        }
    }
}