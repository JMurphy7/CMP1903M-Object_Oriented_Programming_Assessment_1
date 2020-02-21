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
        static void Main(string[] args)
        {
            Country estonia = new Country("bob", 2);
            Console.WriteLine($"{estonia.name} {estonia.popPercentile}");
            Console.WriteLine(readFile());
            Console.ReadLine();
        }
        static string[] readFile()
        {
            string[] lines = File.ReadAllLines("Countries.txt");

            return lines;
        }
    }
    class Country{
        public string name {get; set;}
        public float popPercentile {get;set;}
        public Tuple<string, string, string> vote {get; set;} = new Tuple <string, string, string>("yes", "no", "abstain");
        public Country(string name_, float popPercentile_){
            name = name_;
            popPercentile = popPercentile_;
        }
    
    
        //public void voting(string vote_){
          //  vote = vote_;

       // }
    }
}

