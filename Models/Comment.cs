using System.ComponentModel.DataAnnotations;

namespace LabAspMvc.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Discripton { get; set; }
        public int Rating { get; set; }

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
