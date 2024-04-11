using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace start.Dtos.Comment
{
    public class UpdateCommentDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
    }
}