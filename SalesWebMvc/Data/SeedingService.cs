using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enum;


namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() || 
               _context.Seller.Any() ||
               _context.SalesRecord.Any())
            {
                return; //DB has been seeded
            }

            Department d1 = new Department(1, "Compacto com Ar");
            Department d2 = new Department(2, "Compacto");
            Department d3 = new Department(3, "Economico com Ar");
            Department d4 = new Department(4, "Economico Sedan com Ar");
            Department d5 = new Department(5, "Intermediario");
            Department d6 = new Department(6, "Intermediario Automatico");


            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new Seller(2, "Junior Carlos", "junior@hotmail.com", new DateTime(1971, 2, 11), 550.0, d2);
            Seller s3 = new Seller(3, "Thullyn Cezar", "tc@gmail.com", new DateTime(1998, 6, 12), 500.0, d3);
            Seller s4 = new Seller(4, "Gustavo Amorim", "gustavinho12@gmail.com", new DateTime(1997, 6, 28), 1100.0, d4);
            Seller s5 = new Seller(5, "Luis Roberto", "lrobertinho@gmail.com", new DateTime(1999, 7, 7), 2430.0, d5);
            Seller s6 = new Seller(6, "Claudia Nunes", "claudan@hotmail.com", new DateTime(1981, 2, 10), 3000.0, d1);
            Seller s7 = new Seller(7, "Rubens Vasconcelos", "rv@hotmail.com", new DateTime(1989, 4, 12), 3300.0, d5);
            Seller s8 = new Seller(8, "Luis Roberto", "lrobertinho@gmail.com", new DateTime(1999, 1, 20), 2470.0, d6);


            SalesRecord r1 = new SalesRecord(1, new DateTime(2023, 03, 25), 1100.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2023, 03, 4), 1200.0, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2023, 03, 23), 1300.0, SaleStatus.Billed, s3);
            SalesRecord r4 = new SalesRecord(4, new DateTime(2023, 03, 15), 3100.0, SaleStatus.Billed, s4);
            SalesRecord r5 = new SalesRecord(5, new DateTime(2023, 03, 5), 2100.0, SaleStatus.Billed, s5);
            SalesRecord r6 = new SalesRecord(6, new DateTime(2023, 03, 21), 1100.0, SaleStatus.Billed, s6);
            SalesRecord r7 = new SalesRecord(7, new DateTime(2023, 03, 29), 1500.0, SaleStatus.Billed, s8);
            SalesRecord r8 = new SalesRecord(8, new DateTime(2023, 03, 12), 1300.0, SaleStatus.Billed, s3);
            SalesRecord r9 = new SalesRecord(9, new DateTime(2023, 03, 7), 1230.0, SaleStatus.Billed, s1);
            SalesRecord r10 = new SalesRecord(10, new DateTime(2023, 03, 14), 1200.0, SaleStatus.Billed, s4);
            SalesRecord r11 = new SalesRecord(11, new DateTime(2023, 03, 17), 4100.0, SaleStatus.Billed, s2);
            SalesRecord r12 = new SalesRecord(12, new DateTime(2023, 03, 22), 2100.0, SaleStatus.Billed, s8);
            SalesRecord r13 = new SalesRecord(13, new DateTime(2023, 03, 20), 1300.0, SaleStatus.Billed, s2);
            SalesRecord r14 = new SalesRecord(14, new DateTime(2023, 03, 10), 2100.0, SaleStatus.Billed, s3);
            SalesRecord r15 = new SalesRecord(15, new DateTime(2023, 03, 2), 2100.0, SaleStatus.Billed, s5);
            SalesRecord r16 = new SalesRecord(16, new DateTime(2023, 03, 19), 2100.0, SaleStatus.Billed, s2);
            SalesRecord r17 = new SalesRecord(17, new DateTime(2023, 03, 11), 1300.0, SaleStatus.Billed, s6);
            SalesRecord r18 = new SalesRecord(18, new DateTime(2023, 03, 3), 1500.0, SaleStatus.Billed, s8);
            SalesRecord r19 = new SalesRecord(19, new DateTime(2023, 03, 13), 4100.0, SaleStatus.Billed, s6);
            SalesRecord r20 = new SalesRecord(20, new DateTime(2023, 03, 27), 1200.0, SaleStatus.Billed, s2);
            SalesRecord r21 = new SalesRecord(21, new DateTime(2023, 03, 1), 1600.0, SaleStatus.Billed, s3);
            SalesRecord r22 = new SalesRecord(22, new DateTime(2023, 03, 6), 4600.0, SaleStatus.Billed, s4);
            SalesRecord r23 = new SalesRecord(23, new DateTime(2023, 03, 16), 3400.0, SaleStatus.Billed, s7);
            SalesRecord r24 = new SalesRecord(24, new DateTime(2023, 03, 18), 2100.0, SaleStatus.Billed, s2);
            SalesRecord r25 = new SalesRecord(25, new DateTime(2023, 03, 23), 1100.0, SaleStatus.Billed, s7);
            SalesRecord r26 = new SalesRecord(26, new DateTime(2023, 03, 24), 3100.0, SaleStatus.Billed, s4);
            SalesRecord r27 = new SalesRecord(27, new DateTime(2023, 03, 26), 2155.0, SaleStatus.Billed, s5);
            SalesRecord r28 = new SalesRecord(28, new DateTime(2023, 03, 28), 1200.0, SaleStatus.Billed, s6);
            SalesRecord r29 = new SalesRecord(29, new DateTime(2023, 03, 29), 4100.0, SaleStatus.Billed, s7);
            SalesRecord r30 = new SalesRecord(30, new DateTime(2023, 03, 30), 3100.0, SaleStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4, d5, d6);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6, s7, s8);

            _context.SalesRecord.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();

        }
    }
}
