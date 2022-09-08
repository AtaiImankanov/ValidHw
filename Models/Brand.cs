using System;
using System.ComponentModel.DataAnnotations;

namespace LabAspMvc.Models
{
    public class Brand
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        
        public DateTime DateFounded { get; set; }
    }
}
