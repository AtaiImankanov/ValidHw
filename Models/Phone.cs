using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LabAspMvc.Models
{
    public class Phone
    {
        public int Id { get; set; }
        [Required]
        [Remote(action: "ValidPhone", controller: "Phones", ErrorMessage = "This Phone already exist")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Pic { get; set; }
        [Required]
        public int Price { get; set; }

        public int CategoryId { get; set; }
        public Category Categories { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Comment> ?Comments { get; set; }
    }
}
