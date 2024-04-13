using System.ComponentModel.DataAnnotations;

namespace start.Dtos
{
  public class AccountRegisterDto
  {
    [Required]
    public string? Username { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string Password { get; set; } = string.Empty;
  }
}