using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models;
[Table("Categories")]
public class Category
{
    public Category(){
        //Inicializa a coleção de produtos na table Category.
        Products = new Collection<Product>();    
    }
    [Key]
    [Column("CategoryId")]
    public int Id { get; set; }
    [Required]
    [Column("CategoryName")]
    [StringLength(150)]
    public string? Name { get; set; }
    [Required]
    [Column("CategoryImage")]
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    //Faz com que seja possivel ver quais produtos estão atrelados a categoria
    //"Consulta inversa"
    public ICollection<Product>? Products { get; set; }

    public Category(string name, string imageUrl)
    {
        this.Name = name;
        this.ImageUrl = imageUrl;
    }
}
