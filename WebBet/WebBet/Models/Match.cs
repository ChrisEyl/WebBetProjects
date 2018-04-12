using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBet.Models
{
    public class Match: BaseModel
    {
        [Display(Name = "Team1", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        public string Team1 { get; set; }

        [Display(Name = "Team2", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]
        public string Team2 { get; set; }

        [Display(Name = "OddTeam1", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]

        public int OddTeam1 { get; set; }

        [Display(Name = "OddTeam2", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]

        public int OddTeam2{ get; set; }

        [Display(Name = "OddDraw", ResourceType = typeof(Languages.Resources.Resource))]
        [Required(ErrorMessageResourceName = "Mandatory", ErrorMessageResourceType = typeof(Languages.Resources.Resource))]

        public int OddDraw { get; set; }
    }
}
