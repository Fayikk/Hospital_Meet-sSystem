using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksim_Bootcamp.Shared.Model
{
    public class UserRegister
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,StringLength(100,MinimumLength =6)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="the passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
