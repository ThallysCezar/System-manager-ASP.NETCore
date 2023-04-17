using CarRental.Models;
using CarRental.Models.Enum;

namespace CarRental.Data
{
    public static class SeedingService
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            // Resolve o serviço SeedingService do contêiner de serviços
            using (var scope = app.ApplicationServices.CreateScope())
            {
                Seed(scope.ServiceProvider.GetService<CarRentalContext>()!); // executa a operação de seeding
            }
        }

        public static void Seed(CarRentalContext _context)
        {
            if (_context.Department.Any() ||
               _context.Seller.Any() ||
               _context.RentalRecord.Any())
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


            RentalRecord r1 = new RentalRecord(1, new DateTime(2023, 03, 25), 1100.0, RentalStatus.Billed, s1);
            RentalRecord r2 = new RentalRecord(2, new DateTime(2023, 03, 4), 1200.0, RentalStatus.Billed, s2);
            RentalRecord r3 = new RentalRecord(3, new DateTime(2023, 03, 23), 1300.0, RentalStatus.Billed, s3);
            RentalRecord r4 = new RentalRecord(4, new DateTime(2023, 03, 15), 3100.0, RentalStatus.Billed, s4);
            RentalRecord r5 = new RentalRecord(5, new DateTime(2023, 03, 5), 2100.0, RentalStatus.Billed, s5);
            RentalRecord r6 = new RentalRecord(6, new DateTime(2023, 03, 21), 1100.0, RentalStatus.Billed, s6);
            RentalRecord r7 = new RentalRecord(7, new DateTime(2023, 03, 29), 1500.0, RentalStatus.Billed, s8);
            RentalRecord r8 = new RentalRecord(8, new DateTime(2023, 03, 12), 1300.0, RentalStatus.Billed, s3);
            RentalRecord r9 = new RentalRecord(9, new DateTime(2023, 03, 7), 1230.0, RentalStatus.Billed, s1);
            RentalRecord r10 = new RentalRecord(10, new DateTime(2023, 03, 14), 1200.0, RentalStatus.Billed, s4);
            RentalRecord r11 = new RentalRecord(11, new DateTime(2023, 03, 17), 4100.0, RentalStatus.Billed, s2);
            RentalRecord r12 = new RentalRecord(12, new DateTime(2023, 03, 22), 2100.0, RentalStatus.Billed, s8);
            RentalRecord r13 = new RentalRecord(13, new DateTime(2023, 03, 20), 1300.0, RentalStatus.Billed, s2);
            RentalRecord r14 = new RentalRecord(14, new DateTime(2023, 03, 10), 2100.0, RentalStatus.Billed, s3);
            RentalRecord r15 = new RentalRecord(15, new DateTime(2023, 03, 2), 2100.0, RentalStatus.Billed, s5);
            RentalRecord r16 = new RentalRecord(16, new DateTime(2023, 03, 19), 2100.0, RentalStatus.Billed, s2);
            RentalRecord r17 = new RentalRecord(17, new DateTime(2023, 03, 11), 1300.0, RentalStatus.Billed, s6);
            RentalRecord r18 = new RentalRecord(18, new DateTime(2023, 03, 3), 1500.0, RentalStatus.Billed, s8);
            RentalRecord r19 = new RentalRecord(19, new DateTime(2023, 03, 13), 4100.0, RentalStatus.Billed, s6);
            RentalRecord r20 = new RentalRecord(20, new DateTime(2023, 03, 27), 1200.0, RentalStatus.Billed, s2);
            RentalRecord r21 = new RentalRecord(21, new DateTime(2023, 03, 1), 1600.0, RentalStatus.Billed, s3);
            RentalRecord r22 = new RentalRecord(22, new DateTime(2023, 03, 6), 4600.0, RentalStatus.Billed, s4);
            RentalRecord r23 = new RentalRecord(23, new DateTime(2023, 03, 16), 3400.0, RentalStatus.Billed, s7);
            RentalRecord r24 = new RentalRecord(24, new DateTime(2023, 03, 18), 2100.0, RentalStatus.Billed, s2);
            RentalRecord r25 = new RentalRecord(25, new DateTime(2023, 03, 23), 1100.0, RentalStatus.Billed, s7);
            RentalRecord r26 = new RentalRecord(26, new DateTime(2023, 03, 24), 3100.0, RentalStatus.Billed, s4);
            RentalRecord r27 = new RentalRecord(27, new DateTime(2023, 03, 26), 2155.0, RentalStatus.Billed, s5);
            RentalRecord r28 = new RentalRecord(28, new DateTime(2023, 03, 28), 1200.0, RentalStatus.Billed, s6);
            RentalRecord r29 = new RentalRecord(29, new DateTime(2023, 03, 29), 4100.0, RentalStatus.Billed, s7);
            RentalRecord r30 = new RentalRecord(30, new DateTime(2023, 03, 30), 3100.0, RentalStatus.Billed, s4);

            _context.Department.AddRange(d1, d2, d3, d4, d5, d6);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6, s7, s8);

            _context.RentalRecord.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();

        }
    }
}
