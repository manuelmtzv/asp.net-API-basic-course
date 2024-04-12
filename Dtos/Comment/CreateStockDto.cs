using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace start.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Title must be at least 3 characters long")]
        [MaxLength(120, ErrorMessage = "Title must be less than 120 characters long")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "Content must be at least 3 characters long")]
        [MaxLength(280, ErrorMessage = "Content must be less than 280 characters long")]
        public string Content { get; set; } = string.Empty;
    }
}