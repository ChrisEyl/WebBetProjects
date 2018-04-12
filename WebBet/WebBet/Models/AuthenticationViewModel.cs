using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBet.Models
{
    public class AuthenticationLoginViewModel
    {
        [Display(Name = "Login", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        public string Login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        public string Password { get; set; }
    }
}
