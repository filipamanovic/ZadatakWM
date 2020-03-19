﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace Application.Dto.Product
{
    public class ProductInsert
    {
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
        [Display(Name = "Market")]
        public int MakerId { get; set; }
    }
}