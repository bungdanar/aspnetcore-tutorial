namespace aspnetcore_tutorial.Controllers.Resources
{
    public class UserRegisterResource : UserResource
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}