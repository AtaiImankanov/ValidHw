using LabAspMvc.Models;
using System.Collections.Generic;

namespace LabAspMvc.ViewModels
{
    public class PhonesNCategoriesNBrandsViewModel
    {

        public Phone Phone { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }

    }
}
