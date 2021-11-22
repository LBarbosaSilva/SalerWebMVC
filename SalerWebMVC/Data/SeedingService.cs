using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalerWebMVC.Models;
using SalerWebMVC.Models.Enums;

namespace SalerWebMVC.Data
{
    public class SeedingService
    {
        private SalerWebMVCContext _context;

        public SeedingService(SalerWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Saller.Any() || _context.SalesRecord.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");

            Saller s1 = new Saller(1, "Bob Brown", "Bob@gmail.com", new DateTime(1998, 03, 09), 1000.0, d1);
            Saller s2 = new Saller(2, "Maria", "Maria@gmail.com", new DateTime(1998, 03, 06), 1000.0, d2);
            Saller s3 = new Saller(3, "Junin", "Ju8nin@gmail.com", new DateTime(1998, 03, 03), 1000.0, d1);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);

            _context.Department.AddRange(d1, d2, d3, d4);
            _context.Saller.AddRange(s1, s2, s3);
            _context.SalesRecord.AddRange (r1, r2, r3, r4);

            _context.SaveChanges();
        }
    }
}
