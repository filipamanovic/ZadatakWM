using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto.Product
{
    public class ProductInsert
    {
        public long Id { get; set; }
        [Required]    
        [MaxLength(50, ErrorMessage = "Max length 50 caractes")]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(400)]
        public string Description { get; set; }
        [Required]
        [Range(0, 999999, ErrorMessage = "Range 0 - 999999")]
        public decimal Price { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        [Display(Name = "Maker")]
        public int MakerId { get; set; }
    }
}
