using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get;  set; }
    [Required]
    public string Password { get;  set; }
    [Required]
    public string Role { get;  set; }
    [Required]
    public int SecurityLevel { get;  set; }
    [Required]
    public int BirthYear { get;  set; }
    [Required]
    public string Domain { get; set; }

    public User()
    {}
}