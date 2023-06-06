namespace aspnetcore_tutorial.Core.Models
{
    [Table("Users")]
    [Index(nameof(Username), nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(2048)]
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
    }
}