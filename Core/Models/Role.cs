namespace aspnetcore_tutorial.Core.Models
{
    [Table("Roles")]
    public class Role
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new Collection<User>();
        }
    }
}