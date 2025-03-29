using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.DTO
{
    public class UserDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(150, ErrorMessage="O nome é muito longo.")]
        public string Name {  get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(10, ErrorMessage="A senha deve ter no máximo 10 digitos.")]
        public string Password { get; set; }
        [Required]
        [StringLength(14, ErrorMessage = "O CPF deve ter 14 números.")]
        [MinLength(14)]
        public string CPF { get; set; }
        [Required]
        [Range(0, 999, ErrorMessage ="Digite uma idade válida.")]
        public int Age { get; set; }
    }
}
