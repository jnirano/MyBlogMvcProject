using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogMvcProject.Models
{
    public class Blog
    {
        public int Id { get; set; } // This is the Primary key of the blog model
        public string AuthorId { get; set; } // Foreign key
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} entered must be atleast {2} and atmost {1} characters.", MinimumLength = 2)] // 0 = name of the property, 2 is the value of manimum lenth & 1 is the value of maximum lenth
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} entered must be atleast {2} and atmost {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

        [Display(Name = "Blog Image")]
        public byte[] ImageData { get; set; }

        [Display(Name = "Image Type")]
        public string ContentType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; } // IFormFile is the pysical representation of the image we select




    }
}
