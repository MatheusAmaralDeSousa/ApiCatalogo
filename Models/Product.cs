using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCatalogo.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("ProductId")]
    public int Id { get; set; }
    [Required]
    [Column("ProductName")]
    [StringLength(150)]
    public string? Name { get; set; }
    [Required]
    [Column("ProductDescription")]
    [StringLength(300)]
    public string? Description { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    [Required]
    [Column("ProductImage")]
    [StringLength(300)]
    public string? ImageUrl { get; set; }
    [Required]
    [Column("ProductStock")]
    public float Stock {  get; set; }
    [Required]
    [Column("ProductDate")]
    public DateTime RegistrationDate { get; set; }
    //Mapeia a navegação inversa na tabela Category
    public int CategoryId { get; set; }
    //Faz com que não seja necessário preencher Category 
    [JsonIgnore]
    //Reforça a questão de FK e PK (Relacionamento tradicional)
    public Category? category { get; set; }
    public Product() { }

    [JsonConstructor]
    public Product(string name, string description, decimal price, string imageUrl, float stock, DateTime registrationDate, int categoryId)
    {
        this.Name = name;
        this.Description = description;
        this.Price = price;
        this.ImageUrl = imageUrl;
        this.Stock = stock;
        this.RegistrationDate = registrationDate;
        this.CategoryId = categoryId;
    }

}
