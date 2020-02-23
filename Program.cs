using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Object_Oriented_Programming_Assessment_1
{
    class Program
    {
        static List<Country> countryList = new List<Country>();
        static void Main(string[] args)
        {
            // Country estonia = new Country("bob", 2);
            // Console.WriteLine($"{estonia.name} {estonia.popPercentile}");
            string[] lines = readFile();    // Take an array of strings as 'lines'
            int count = 0;

            /*foreach(string s in lines)
            {
                Console.WriteLine(lines[count]);
                count++;
            }
            Console.ReadKey();            
            */
            
        }
        static string[] readFile()  // Read the file Countries.txt and convert into an array of strings
        {
            try { 
                 string[] countries = File.ReadAllLines("Countries.txt");
                 string[] population = File.ReadAllLines("popPercentage.txt");

                 int count = 0;
                 
                foreach (string s in countries)
                {
                    Country a = new Country(countries[count], float.Parse(population[count]));
                    countryList.Add(a);
                    Console.WriteLine(countryList[count].name);
                    count++;
                }
                Console.ReadKey();
                 return null;
            }
            catch (FileNotFoundException)
            {
                string[] temp = { "Countries.txt not found. Has it been moved/deleted?" }; 
                return temp;
            }
        }


    }
    class Country{
        public string name { get; set;}
        public float popPercentile { get; set; }
        public string vote { get; set; }
        public Country(string name_, float popPercentile_){
            name = name_;
            popPercentile = popPercentile_;
        }
        public void voting(string vote_){ // We pass it the vote through the interface. There is no error checking here, as the interface will only accept <country> <yes, no, abstain>
          vote = vote_;
        }
    }
}

