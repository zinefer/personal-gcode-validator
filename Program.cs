using System;
using System.IO;

namespace personal_gcode_validator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0) {
                Console.WriteLine("Missing file argument");
                Environment.Exit(1);
            }

            string file = args[0];

            if (File.Exists(file) == false) {
                Console.WriteLine("File does not exist");
                Environment.Exit(1);
            }

            Rule[] rules = {
                new Rule("FILE CONTAINS G28", "G28")
            };

            bool pass = true;
            foreach (string line in System.IO.File.ReadLines(file))
            {
                foreach (Rule rule in rules)
                {
                    bool result = rule.Validate(line);

                    if (result == false) {
                        Console.WriteLine("VIOLATION: " + rule.Name());
                    }

                    pass = pass && result;
                }                
            }

            if (pass) {
                Console.WriteLine("File Pass!! 🎉");
            } else {
                Console.WriteLine("File Failed - DO NOT RUN");
            }

            Console.ReadLine();
        }
    }
}
