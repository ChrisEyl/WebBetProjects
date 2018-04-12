using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebBet.Models
{
    [Table("Paris")] // renommage de la table
    public class Bet : BaseModel
    {
        [Display(Name = "Result", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        public int Result { get; set; }

        [Display(Name = "Amount", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]

        public int Amount { get; set; }
        [Display(Name = "State", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]

        public bool State { get; set; }
        [Display(Name = "UserId", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]

        public int UserId { get; set; }
        [Display(Name = "UserId", ResourceType = typeof(Languages.Resources.Resource))]
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Display(Name = "MatchId", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        public int MatchId { get; set; }

        [Display(Name = "MatchId", ResourceType = typeof(Languages.Resources.Resource))]
        [ForeignKey("MatchId")]
        public Match Match { get; set; }
    }
}
