﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MyBlogMvcProject.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogMvcProject.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Display(Name = "Blog Name")]
        public int BlogId { get; set; }

        public string BlogUserId { get; set; }

        [Required]
        [StringLength(75, ErrorMessage = "The {0} must be atleast {2} and not more than {1} character long. ", MinimumLength = 2)]
        public string Title { get; set; }
       
        [StringLength(75, ErrorMessage = "The {0} must be atleast {2} and not more than {1} character long. ", MinimumLength = 2)]
        [Required]
        public string Abstract { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime Updated { get; set; }

        public ReadyStatus ReadyStatus { get; set; } // This hold the true or false instead of using bool

        public string Slug { get; set; }

        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        //Navigation Properties
        public virtual Blog Blog { get; set; }
        public virtual BlogUser BlogUser { get; set; }

        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

    }
}
