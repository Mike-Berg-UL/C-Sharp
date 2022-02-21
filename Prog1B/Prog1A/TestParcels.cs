// Program 1B
// CIS 200-50
// Fall 2021
// Due: 10/8/2020
// By: Michael Bergamini 1416810

// File: TestParcels.cs
// Created several LINQ lists to display data


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            Address a5 = new Address("Bill Murray", "Funny Guy Place", "Apt. 9",
                "Chicageo", "IL", 53201); // Test Address 4
            Address a6 = new Address("Happy Gilmore", "111 Happy Place",
                "Jacksonville", "FL", 90192); // Test Address 4
            Address a7 = new Address("Bill Nye", "125 Smart Guy Way", 
                "Houston", "TX", 42654); // Test Address 4
            Address a8 = new Address("Bob Dylan", "845 Guitar Place", "Apt. 1",
                "Dolouth", "MN", 22004); // Test Address 4

            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test object
            Letter letter2 = new Letter(a7, a8, 10.67M);
            Letter letter3 = new Letter(a4, a5, 5.99M);
            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 30, 12.5);        // Ground test object
            GroundPackage gp2 = new GroundPackage(a6, a7, 10, 11, 5, 12.5);
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a2, 25, 15, 15,    // Next Day test object
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a4, a5, 3, 15, 4,    // Next Day test object
               5, 7.99M);
            NextDayAirPackage ndap3 = new NextDayAirPackage(a7, a3, 10, 15, 7,    // Next Day test object
               90, 7.99M);
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test object
                80.5, TwoDayAirPackage.Delivery.Saver);

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();
                        
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(ndap3);
            parcels.Add(tdap1);
            parcels.Add(letter1); // Populate list
            parcels.Add(letter2);
            parcels.Add(letter3);
            parcels.Add(gp1);
            parcels.Add(gp2);

            /*WriteLine("Original List:");
            WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                WriteLine(p);
                WriteLine("====================");
            }
            Pause(); */

            //sorts parcels by destination Zip
            var parcelsSortedByDestZip =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;

            WriteLine("Parcels sorted by Destination Zip descending:");
            WriteLine("=============================================");
            foreach (Parcel p in parcelsSortedByDestZip)
            {
                WriteLine($"{p.DestinationAddress.Zip:D5}");
            }
            Pause();

            //sorts parcels by cost
            var parcelsSortedByCostAsceding =
                from p in parcels
                orderby p.CalcCost()
                select p;

            WriteLine("Parcels sorted by cost ascending");
            WriteLine("================================");
            foreach (Parcel p in parcelsSortedByCostAsceding)
            {
                WriteLine($"{p.CalcCost():C}");
            }
            Pause();

            //sorts parcels by type and cost
            var parcelsSortedByTypeCostDescending =
                from p in parcels
                orderby p.GetType().ToString(), p.CalcCost() descending
                select p;

            WriteLine("Parcels ordered by Type and then Cost descending");
            WriteLine("===============================================");
            foreach (Parcel p in parcelsSortedByTypeCostDescending)
            {
                WriteLine($"{p.GetType().ToString(),-20} {p.CalcCost():C}");
            }
            Pause();

            //sorts heavy air packages
            var AirPackagesHeavySortedByWeightDescending =
                from p in parcels
                let airPack = p as AirPackage
                where (airPack != null) && airPack.IsHeavy()
                orderby airPack.Weight descending
                select airPack;

            WriteLine("Air Packages that are heavy sorted by weight desecending");
            WriteLine("===============================================");
            foreach(AirPackage ap in AirPackagesHeavySortedByWeightDescending)
            {
                WriteLine($"{ap.GetType().ToString(),-20} {ap.Weight}");
            }
            Pause();
        }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            WriteLine("Press Enter to Continue...");
            ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
