using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using WebBet.Validators;

namespace WebBet.Models
{
    public class User : BaseModel
    {
        //[Display(Name ="Nom")]
        [Display(Name = "Name", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceName = "MaxNameLength", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        public string Name { get; set; }

        //[Display(Name = "Prénom")]
        [Display(Name = "FirstName", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        public string FirstName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Languages.Resources.Resource))]
        [RegularExpression((@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Languages.Resources.Resource))]
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        [StringLength(18, MinimumLength = 6, ErrorMessageResourceName = "MaxNameLength", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        [Compare("Password", ErrorMessageResourceName = "ComparePassword", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        public string ConfirmedPasssword { get; set; }

        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [Major(18, ErrorMessageResourceName = "MajorError", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Bets", ResourceType = typeof(Languages.Resources.Resource))]
        public ICollection<Bet> Bets { get; set; }
    }
}
