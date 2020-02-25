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
        static int vote_yes = 0;
        static int vote_no = 0;
        static int vote_abstain = 0;
        static void Main(string[] args)
        {
            string[] lines = readFile();    // Take an array of strings as 'lines'
            while (true)
            {
                userInterface(Console.ReadLine());
            }
            
        }
        static string[] readFile()  // Read the file Countries.txt and convert into an array of strings
        {
            try { // Proofing for if the file is not there
                 string[] countries = File.ReadAllLines("Countries.txt"); // Files are used as this data is dynamic. Brexit for example, has meant that this list needed to be changed.
                 string[] population = File.ReadAllLines("popPercentage.txt"); // Pop percentage is used for storing the percentage, we dont ever end up using this, but it does add expandibility in the future.

                 int count = 0;
                 
                foreach (string s in countries)
                {
                    Country a = new Country(countries[count], float.Parse(population[count]));
                    countryList.Add(a); // Adds each country in the .txt file to the list
                    count++;
                }
                 return null;
            }
            catch (FileNotFoundException)
            {
                string[] temp = { "Countries.txt not found. Has it been moved/deleted?" }; 
                return temp;
            }
      
        }
        static void userInterface(string command)
            {

                string[] a = command.Split(' '); // Breaks the command into segments to be processed.
                switch (a[0])
                {
                    case ("vote"): // Granted, a very fiddly interface, but it allows each and every country to be edited at any time. 
                    if(a.Count() != 3)
                    {
                        Console.WriteLine("Too few, or too many arguments.\nStructure as so: vote <country> <yes:no:abstain>"); // Proofing against arguments being invalid
                        break;
                    }
                    int counter = 0;
                        foreach(Country countries in countryList) {

                        if (countryList[counter].name == a[1]) // Provides no output if the country isnt found, but stops the user from entering a country that doesnt exist.
                        {
                            if (a[2] != "yes" && a[2] != "abstain" && a[2] != "no")
                            {
                                Console.WriteLine("Invalid vote!");
                                break;
                            }

                            countryList[counter].vote = a[2];
                            Console.WriteLine($"{countryList[counter].name} is now voting {countryList[counter].vote}"); // Visual feedback
                        }
                        counter++;
                    }
                    break;
                    case ("qualifiedMajority"):
                        Console.WriteLine(qualifiedMajority()); // Console.WriteLine is used to give a text output.
                        break;
                    case ("listCountries"): // Simply calls the listCountries() function.
                        listCountries();
                        break;
                    default:
                        Console.WriteLine("Invalid. Acceptable commands are:\nvote <country> <yes:no:abstain>\nqualifiedMajority\nlistCountries"); // Shows the user all usable commands.
                        break;

                }
            }
        static void listCountries()
        {
            int count = 0;
            foreach(Country country in countryList)
            {
                Console.WriteLine($"{countryList[count].name} has a population of {countryList[count].popPercentile}% and vote {countryList[count].vote}"); // Simply shows each value in the countryList and breaks it down to its component parts.
                count++;
            }
        }
        static string qualifiedMajority(){
            int count = 0;

            foreach(Country countries in countryList){
                if(countryList[count].vote == "yes"){
                vote_yes++;
                }else if(countryList[count].vote == "no"){
                vote_no++;
                }else{
                vote_abstain++;
                }
                count++;
            }
            int a = countryList.Count / 2; // If more than half the countries say yes, then its passes. Else, it has failed.
            if(a > vote_yes){
                return "The vote has failed.";
                }else{
                return "The vote has passed";
                }
        }

    }
    class Country{
        public string name { get; set;}
        public float popPercentile { get; set; }
        public string vote { get; set; }
        public Country(string name_, float popPercentile_){ // Automatically assumes Abstain. Its safer than assuming a vote of "yes" or "no"
            name = name_;
            popPercentile = popPercentile_;
            vote = "abstain";
        }
    }
}

