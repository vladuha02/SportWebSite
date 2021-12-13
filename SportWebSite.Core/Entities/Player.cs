using System;
using System.ComponentModel.DataAnnotations;

namespace SportWebSite.Domain.Entities
{
    public class Player
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(60)]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string Position { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [StringLength(30)]
        public string CountryOfBirth { get; set; }

        [StringLength(35)]
        public string Nationality { get; set; }

        [StringLength(30)]
        public string Role { get; set; }

        public Team Team { get; set; }

        public int? TeamId { get; set; }
    }
}
