using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int age { get; set; }

        public DateTime CreatedDate { get; set; }

        public User(int id, string name, string email, int age, DateTime createdDate)
        {
            Id = id;
            Name = name;
            Email = email;
            this.age = age;
            CreatedDate = createdDate;
        }
    }
}
