using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
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
        [Required]
        public DateTime CreatedDate { get; set; }
        //Faz com que o Ef Core reconheça corretamente a classe User.
        public User() { }

        public User(string name, string email, string password, string cpf, int age, DateTime createdDate)
        {
            Name = name;
            Email = email;
            Password = password;
            CPF = cpf;
            Age = age;
            CreatedDate = createdDate;
        }
    }
}
