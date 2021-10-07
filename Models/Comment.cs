using Microsoft.AspNetCore.Identity;
using MyBlogMvcProject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogMvcProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        public string ModeratorId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be atleast {2|} and no more than {1} characters long. ", MinimumLength = 2)]
        [Display(Name = "Content")]
        public string Body { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime Moderated { get; set; }
        public DateTime Deleted { get; set; }

        [StringLength(500, ErrorMessage = "The {0} must be atleast {2|} and no more than {1} characters long. ", MinimumLength = 2)]
        [Display(Name = "Moderated Comment")]
        public string ModeratedBody { get; set; }

        public ModerationType ModerationType { get; set; }


        // Navigation Properties
        public virtual Post Post { get; set; }
        public virtual IdentityUser Author { get; set; }
        public virtual IdentityUser Moderator { get; set; }
    }
}
