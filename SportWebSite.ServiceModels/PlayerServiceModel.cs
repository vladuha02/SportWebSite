using System;
using System.ComponentModel.DataAnnotations;

namespace SportWebSite.ServiceModels
{
    public class PlayerServiceModel
    {
        [Required]
        public int id { get; set; }

        [Required, StringLength(60)]
        public string name { get; set; }

        [StringLength(20, MinimumLength = 2)]
        public string position { get; set; }

        [Required]
        public DateTime dateOfBirth { get; set; }

        [StringLength(30)]
        public string countryOfBirth { get; set; }

        [StringLength(35)]
        public string nationality { get; set; }

        [StringLength(30)]
        public string role { get; set; }
    }
}
