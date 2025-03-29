using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.DTO
{
    public class UserDTO
    {
        [Required]
        [StringLength(150)]
        public string Name {  get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string Password { get; set; }
        [Required]
        [StringLength(14)]
        public string CPF { get; set; }
        [Required]
        [Range(0, 999)]
        public int Age { get; set; }
    }
}
