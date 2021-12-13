using SportWebSite.Domain.Entities;
using SportWebSite.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportWebSite.ServiceModels
{
    public class TeamServiceModel
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(25)]
        public string TeamName { get; set; }

        [Required]
        public SportType SportType { get; set; }

        public IEnumerable<Player> Players { get; set; }

        public IEnumerable<int> PlayerIds { get; set; }
    }
}
