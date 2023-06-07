namespace aspnetcore_tutorial.Controllers.Resources
{
    public class UserResource
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}