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
            
            Console.ReadKey();       
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

                string[] a = command.Split(' ');
                switch (a[0])
                {
                    case ("vote"):
                    
                    if(a.Count() != 3)
                    {
                        Console.WriteLine("Too few, or too many arguments.\nStructure as so: vote <country> <yes:no:abstain>");
                        break;
                    }
                    int counter = 0;
                        foreach(Country countries in countryList) {

                        if (countryList[counter].name == a[1])
                        {
                            if (a[2] != "yes" && a[2] != "abstain" && a[2] != "no")
                            {
                                Console.WriteLine("Invalid vote!");
                                break;
                            }

                            Console.WriteLine($"{countryList[counter].name} is now voting {countryList[counter].vote}");
                            countryList[counter].vote = a[2];
                        }
                        counter++;
                    }
                    break;
                    case ("qualifiedMajority"):
                        Console.WriteLine(qualifiedMajority());
                        
                        break;
                    default:
                        Console.WriteLine("Invalid. Acceptable commands are:\nvote <country> <yes:no:abstain>\nqualifiedMajority");
                        break;

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
            int a = countryList.Count / 2;
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
        public Country(string name_, float popPercentile_){
            name = name_;
            popPercentile = popPercentile_;
        }
        public void voting(string vote_){ // We pass it the vote through the interface. There is no error checking here, as the interface will only accept <country> <yes, no, abstain>
          vote = vote_;
        }
    }
}

