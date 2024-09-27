using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
