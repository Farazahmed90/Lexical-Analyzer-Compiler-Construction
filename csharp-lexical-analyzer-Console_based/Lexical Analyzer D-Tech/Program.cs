using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lexical_Analyzer_D_Tech
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Assigning_Tokens analyzer = new Assigning_Tokens();
            Console.WriteLine("Statement must end with terminator");
            Console.WriteLine("Enter Something To Assign Tokens :");
            input = Console.ReadLine();
            Console.WriteLine("\nTokens for the given sentence :\n");
            
            while (input != null)
            {
                input = input.Trim(' ', '\t');
                string output = analyzer.Checking_Given_String(ref input);
                Console.Write(output);           
            }

            Console.ReadLine();
        }
    }
}