using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace start.Dtos.Stock
{
    public class CreateStockDto
    {
        [Required]
        [MaxLength(5, ErrorMessage = "Symbol must be less than 5 characters long")]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MinLength(3, ErrorMessage = "Company Name must be at least 3 characters long")]
        [MaxLength(120, ErrorMessage = "Company Name must be less than 120 characters long")]
        public string CompanyName { get; set; } = string.Empty;        
        [Required]
        [Range(0, 1000000000, ErrorMessage = "Purchase must be between 0 and 1000")]
        public decimal Purchase { get; set; }    
        [Required]
        [Range(0, 1000, ErrorMessage = "Last Div must be between 0 and 1000")]
        public decimal LastDiv { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Industry must be at least 3 characters long")]    
        [MaxLength(30, ErrorMessage = "Industry must be less than 120 characters long")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(0, 5000000000, ErrorMessage = "Market Cap must be between 0 and 1000")]
        public long MarketCap { get; set; }
        
    }
}