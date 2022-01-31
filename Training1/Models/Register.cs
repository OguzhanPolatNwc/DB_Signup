using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training1.Models;

public class RegisterModel
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Username { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    
    public DateTime CreatedAt { get; set; }

    [Required]
    public string Password { get; set; }
    
    [Required]
    public bool IsAgreed { get; set; }
    
}