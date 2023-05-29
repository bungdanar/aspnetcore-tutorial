namespace aspnetcore_tutorial.Models
{
    [Owned]
    public class Contact
    {
        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }

        [StringLength(255)]
        public string ContactEmail { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }
    }
}