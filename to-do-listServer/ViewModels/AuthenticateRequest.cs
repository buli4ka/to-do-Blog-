using System.ComponentModel.DataAnnotations;

namespace to_do_listServer.ViewModels
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}