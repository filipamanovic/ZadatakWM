using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Dto.Maker
{
    public class MakerDto
    {
        public int Id { get; set; }
        [Required][MaxLength(50, ErrorMessage = "Max lengyh is 50")]
        public string MakerName { get; set; }
    }
}
