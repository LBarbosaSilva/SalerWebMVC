using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalerWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Saller> Sellers { get; set; } = new List<Saller>();

        public Department()
        {

        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSaller(Saller saller)
        {
            Sellers.Add(saller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
