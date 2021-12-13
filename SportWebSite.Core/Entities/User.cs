using Microsoft.AspNetCore.Identity;
using SportWebSite.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SportWebSite.Domain.Entities
{
    public class User : IdentityUser
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required, StringLength(40)]
        public string Location { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public int? TeamId { get; set; }

        public virtual Team Team { get; set; }

        public int? PlayerId { get; set; }

        public virtual Player Player { get; set; }
    }
}