﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogMvcProject.Models
{
    public class BlogUser : IdentityUser
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and not more than {1} character long.", MinimumLength = 2)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and not more than {1} character long.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and not more than {1} character long.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
<<<<<<< HEAD
        public string DisplayName { get; set; }
=======
        public string DisplayName  { get; set; }
>>>>>>> 3f01bee6813313ce190a9462f70acece2ef81951

        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and not more than {1} character long.", MinimumLength = 2)]
        public string FacebookUrl { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and not more than {1} character long.", MinimumLength = 2)]
        public string TwitterUrl { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        // This attached/associate posts written by a particular with that person
        public virtual ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>(); 
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();


    }
}
