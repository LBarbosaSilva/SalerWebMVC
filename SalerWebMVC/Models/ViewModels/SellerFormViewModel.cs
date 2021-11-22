using System.Collections.Generic;

namespace SalerWebMVC.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Saller Saller { get; set; }
        public ICollection<Department> Departments { get; set; } 
    }
}
