using System;
using System.Collections.Generic;
using System.Linq;

namespace linq {
    // Build a collection of customers who are millionaires
    // this is used at the bottomg
public class Customer
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public string Bank { get; set; }
}
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ();
            Console.WriteLine ("Exercise 1");
            Console.WriteLine ("-----------------------------------------------------------------------------");
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string> () { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };
            IEnumerable<string> LFruits = from fruit in fruits
            where fruit.StartsWith ("L")
            select fruit;
            //output
            foreach (string fruit in LFruits) {
                Console.WriteLine (fruit);
            }
            Console.WriteLine ();
            Console.WriteLine ("Exercise 2");
            Console.WriteLine ("-----------------------------------------------------------------------------");
            // Which of the following numbers are multiples of 4 or 6
            // List<int> numbers = new List<int> () {
            //     15,
            //     8,
            //     21,
            //     24,
            //     32,
            //     13,
            //     30,
            //     12,
            //     7,
            //     54,
            //     48,
            //     4,
            //     49,
            //     96
            // };

            // IEnumerable<int> fourSixMultiples = numbers.Where (n => n % 4 == 0 || n % 6 == 0);
            // foreach (int num in fourSixMultiples) {
            //     Console.WriteLine (num);
            // }

            // Order these student names alphabetically, in descending order (Z to A)
            Console.WriteLine ();
            Console.WriteLine ("Exercise 3");
            Console.WriteLine ("-----------------------------------------------------------------------------");
            List<string> names = new List<string> () {
                "Heather",
                "James",
                "Xavier",
                "Michelle",
                "Brian",
                "Nina",
                "Kathleen",
                "Sophia",
                "Amir",
                "Douglas",
                "Zarley",
                "Beatrice",
                "Theodora",
                "William",
                "Svetlana",
                "Charisse",
                "Yolanda",
                "Gregorio",
                "Jean-Paul",
                "Evangelina",
                "Viktor",
                "Jacqueline",
                "Francisco",
                "Tre"
            };

            List<string> descend = names.OrderByDescending (name => name).ToList ();
            foreach (string name in descend) {
                Console.WriteLine (name);
            }

            // Build a collection of these numbers sorted in ascending order
            Console.WriteLine ();
            Console.WriteLine ("Exercise 4");
            Console.WriteLine ("-----------------------------------------------------------------------------");
            List<int> numbers = new List<int> () {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };

            List<int> sortedNumbers = numbers.OrderBy (n => n).ToList ();
            foreach (int snum in sortedNumbers) {
                Console.WriteLine (snum);
            }
            Console.WriteLine ();
            Console.WriteLine ("Exercise 5");
            Console.WriteLine ("-----------------------------------------------------------------------------");
            // Output how many numbers are in this list
            List<int> nums = new List<int> () {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };
            int numCount = nums.Count ();
            Console.WriteLine (numCount);

            Console.WriteLine ();
            Console.WriteLine ("Exercise 6");
            Console.WriteLine ("-----------------------------------------------------------------------------");
            // How much money have we made?
            List<double> purchases = new List<double> () {
                2340.29,
                745.31,
                21.76,
                34.03,
                4786.45,
                879.45,
                9442.85,
                2454.63,
                45.65
            };
            double total = purchases.Sum ();
            Console.WriteLine (total);

            Console.WriteLine ();
            Console.WriteLine ("Exercise 7");
            Console.WriteLine ("-----------------------------------------------------------------------------");
            // What is our most expensive product?
            List<double> prices = new List<double> () {
                879.45,
                9442.85,
                2454.63,
                45.65,
                2340.29,
                34.03,
                4786.45,
                745.31,
                21.76
            };
            double mostExp = prices.Max ();
            Console.WriteLine (mostExp);

            /*
    Store each number in the following List until a perfect square
    is detected.

    Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
*/
            List<int> wheresSquaredo = new List<int> () {
                66,
                12,
                8,
                27,
                82,
                34,
                7,
                50,
                19,
                46,
                81,
                23,
                30,
                4,
                68,
                14
            };
            Console.WriteLine ();
            Console.WriteLine ("Exercise 8");
            Console.WriteLine ("-----------------------------------------------------------------------------");
            List<int> numsBeforeSquare = wheresSquaredo.TakeWhile (num => {
                //return true if i is a perfect square
                double sqrt = Math.Sqrt (num);
                return sqrt % 1 != 0;
            }).ToList ();
            foreach (var x in numsBeforeSquare) {
                Console.WriteLine (x);
            }
            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------- 
        
            Console.WriteLine ();
            Console.WriteLine ("Exercise 9");
            Console.WriteLine ("-----------------------------------------------------------------------------");

            List<Customer> customers = new List<Customer> () {
                new Customer () { Name = "Bob Lesman", Balance = 80345.66, Bank = "FTB" },
                new Customer () { Name = "Joe Landy", Balance = 9284756.21, Bank = "WF" },
                new Customer () { Name = "Meg Ford", Balance = 487233.01, Bank = "BOA" },
                new Customer () { Name = "Peg Vale", Balance = 7001449.92, Bank = "BOA" },
                new Customer () { Name = "Mike Johnson", Balance = 790872.12, Bank = "WF" },
                new Customer () { Name = "Les Paul", Balance = 8374892.54, Bank = "WF" },
                new Customer () { Name = "Sid Crosby", Balance = 957436.39, Bank = "FTB" },
                new Customer () { Name = "Sarah Ng", Balance = 56562389.85, Bank = "FTB" },
                new Customer () { Name = "Tina Fey", Balance = 1000000.00, Bank = "CITI" },
                new Customer () { Name = "Sid Brown", Balance = 49582.68, Bank = "CITI" }
            };

            // Another way to do GroupBy (another overload). Adam recommends this way.
            var report = customers
                .Where (c => c.Balance >= 1000000)
                .GroupBy (c => c.Bank)
                .Select (group => {
                    return new {
                    BankName = group.Key,
                    MillionaireCount = group.Count ()
                    };
                });

            List<ReportItem> millionaireReport = millionaires.Join (
                banks,
                millionaire => millionaire.Bank,
                bank => bank.Symbol,
                (millionaire, bank) =>
                new ReportItem {
                    CustomerName = millionaire.Name,
                        BankName = bank.Name
                }
            ).ToList ();

            millionaireReport.OrderBy (ReportItem => ReportItem.CustomerName.Split (" ").Last ());

        }
    }
}