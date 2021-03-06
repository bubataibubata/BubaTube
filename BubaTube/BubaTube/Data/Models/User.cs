﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BubaTube.Data.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User : IdentityUser
    {
        [Required]
        [StringLength(15, ErrorMessage = "First name cannot be more than 15 symbols."), 
            MinLength(2, ErrorMessage ="First name cannot be less than 2 symbols")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Last name cannot be more than 15 symbols."),
            MinLength(2, ErrorMessage = "Last name cannot be less than 2 symbols")]
        public string LastName { get; set; }

        public byte[] AvatarImage { get; set; }

        public ICollection<User> FavouriteUsers { get; set; }

        public ICollection<UserVideo> UserVideo { get; set; }

        public ICollection<Video> UploadedVideos { get; set; }
    }
}
