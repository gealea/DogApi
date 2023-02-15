using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DogApi.BLL.Model;

public class Dog
{
    public Dog(Guid guiId, string name, string? breed, DateTime birthDate)
    {
        GuiId = guiId;
        Name = name;
        Breed = breed;
        BirthDate = birthDate;
    }

    [Required]
    public Guid GuiId { get; set; }

    [Required]
    public string Name { get; set; }

    public string? Breed { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set;}
}

public class DogRequest
{
    public DogRequest(string name, string birthDate)
    {
        Name = name;
        BirthDate = birthDate;
    }

    [Required]
    public string Name { get; set; }

    public string? Breed { get; set; }
        
    [Required]
    public string BirthDate { get; set;}
}