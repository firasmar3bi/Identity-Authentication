using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityAuthentication.Models.ViewModel
{
	public class RegisterViewModel
	{
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Compare(nameof(Password))]
        public string ConfirmPasseord { get; set; }

        public string Phone { get; set; }
    }
}

