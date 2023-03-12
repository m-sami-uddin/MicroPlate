using System.ComponentModel.DataAnnotations.Schema;

namespace MicroPlate.JwtAuthenticationManager.Models;

public class UserAccount
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}
public enum UserRole
{
    User = 1,
    Admin = 2

}
