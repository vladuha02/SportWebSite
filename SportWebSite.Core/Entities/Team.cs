using SportWebSite.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportWebSite.Domain.Entities
{
    public class Team
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(25)]
        public string TeamName { get; set; }

        [Required]
        public SportType SportType { get; set; }

        public virtual IEnumerable<Player> Players { get; set; }
    }
}