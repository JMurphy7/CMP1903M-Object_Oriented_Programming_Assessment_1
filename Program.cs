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
            
        
            /* Joe + maybe david if he looks before tuesday - still dont fully understand switch statements yet and i dont fully 
            think what ive added will 100% work as i cant test it but i have codded atleast the basics of how this
            process would work (i think kek)*/
      

        static void userInterface(string command)
            {
                int vote_yes = 0;
                
                int vote_no = 0;
                
                int vote_abstain = 0;

                string[] a = command.Split(' ');

                switch (a[1])
                {
                    case ("vote"):
                        Console.WriteLine("Please enter your vote.");
                        Countries_Vote= Console.ReadLine();

                        if (Countries_Vote = "yes")
                        {
                            vote_yes += 1;

                        }
                        else if (Countries_Vote = "no")
                        {
                            vote_no += 1;
                        }
                        else if (Countries_vote = "Abstain")
                        {
                            vote_abstain += 1 ;    
                        }
                        else
                        {
                            Console.WriteLine("You have entered an incorrect vote");
                        }
                        //
                        break;
                    case ("qualifiedMajority"):
                        Console.WriteLine("this function is incomplete.");
                        //qualifiedmajority();
                        break;
                    case ("allCountriesParticipating"):
                        Console.WriteLine("this function is incomplete");
                        //allcountriesparticipating();
                        break;
                    default:
                        Console.WriteLine("this function is incomplete.");
                        break;

                }
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

