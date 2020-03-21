using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required][MaxLength(50, ErrorMessage = "Max length is 50")]
        public string CategoryName { get; set; }
    }
}
