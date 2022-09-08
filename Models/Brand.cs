using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace LabAspMvc.Models
{
    public class Brand
    {
        
        public int Id { get; set; }
        [Remote(action: "ValidBrand", controller: "Brands", ErrorMessage = "This Brand already exist")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Remote(action:"ValidDate",controller:"Brands",ErrorMessage ="Invalid Date")]
        public DateTime DateFounded { get; set; }
    }
}
