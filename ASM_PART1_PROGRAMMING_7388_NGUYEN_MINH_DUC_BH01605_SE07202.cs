using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace WaterBillCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Water Bill Calculator");

            // Input gathering
            Console.Write("Enter customer name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter last month's water meter readings: ");
            int lastMonthReadings = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter this month's water meter readings: ");
            int thisMonthReadings = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the customer type (1 - Household, 2 - Administrative agency, 3 - Production units, 4 - Business services): ");
            int customerType = Convert.ToInt32(Console.ReadLine());

            int numberOfPeople = 0;
            if (customerType == 1)
            {
                Console.Write("Enter the number of people in the household: ");
                numberOfPeople = Convert.ToInt32(Console.ReadLine());
            }

            // Consumption calculation
            int consumption = thisMonthReadings - lastMonthReadings;

            // Bill calculation
            double price = 0;
            double environmentFees = 0;

            switch (customerType)
            {
                case 1: // Household
                    if (consumption <= 10 * numberOfPeople)
                    {
                        price = 5.973;
                        environmentFees = 597.30;
                    }
                    else if (consumption <= 20 * numberOfPeople)
                    {
                        price = 7.052;
                        environmentFees = 705.20;
                    }
                    else if (consumption <= 30 * numberOfPeople)
                    {
                        price = 8.699;
                        environmentFees = 866.90;
                    }
                    else
                    {
                        price = 15.929;
                        environmentFees = 1592.90;
                    }
                    break;

                case 2: // Administrative agency, public services
                    price = 9.955;
                    environmentFees = 995.50;
                    break;

                case 3: // Production units
                    price = 11.615;
                    environmentFees = 1161.50;
                    break;

                case 4: // Business services
                    price = 22.068;
                    environmentFees = 2206.80;
                    break;

                default:
                    Console.WriteLine("Invalid customer type.");
                    return;
            }

            // Total water bill calculation
            double totalBill = (price * consumption) + environmentFees;

            // Output generation
            Console.WriteLine();
            Console.WriteLine("Customer Name: " + customerName);
            Console.WriteLine("Last Month's Water Meter Readings: " + lastMonthReadings);
            Console.WriteLine("This Month's Water Meter Readings: " + thisMonthReadings);
            Console.WriteLine("Amount of Consumption: " + consumption);
            Console.WriteLine("Total Water Bill: " + totalBill.ToString("0.00 VND"));

            // Additional features (not implemented)
            // Sorting, searching, invoice generation, payment dues

            Console.ReadLine();
        }
    }
}