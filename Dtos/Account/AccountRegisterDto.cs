using System.ComponentModel.DataAnnotations;

namespace start.Dtos
{
  public class AccountRegisterDto
  {
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
  }
}