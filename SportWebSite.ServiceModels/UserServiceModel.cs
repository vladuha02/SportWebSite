using Microsoft.AspNetCore.Mvc.Rendering;
using SportWebSite.Domain.Entities;
using SportWebSite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportWebSite.ServiceModels
{
    public class UserServiceModel
    {
        [Required]
        public string Id { get; set; }

        [Required, StringLength(100)]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string UserName { get; set; }

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

        public List<SelectListItem> RolesList { get; set; }

        public UserServiceModel()
        {
        }

        public UserServiceModel(User user)
            : this()
        {
            Id = user.Id;
            Name = user.Name;
            UserName = user.UserName;
            Email = user.Email;
            BirthDate = user.BirthDate;
            Location = user.Location;
        }
    }
}