using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Lab11_MVCApplication.Models
{
    public class TimePerson
    {
        //properties for the time person
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }


        public static List<TimePerson> GetPersons(int startYear, int endYear)
        {
            //creat a list of TimePerson
            List<TimePerson> persons = new List<TimePerson>();
            //create new path with current directory
            string path = Environment.CurrentDirectory;
            //combine the current directory and locates the persons who fit the criteria given
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            // read all lines of csv file
            string[] myFile = File.ReadAllLines(newPath);

            //for loop to read all lines in the csv
            for(int i = 1; i < myFile.Length; i++)
            {
                // split lines 
                string[] fields = myFile[i].Split(',');
                // adds and creates a new person for the list
                persons.Add(new TimePerson
                {
                    //parse through data to fill out props for person
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }

            //Use lambda LINQ function to filter persons to the given years
            List<TimePerson> listOfPersons = persons.Where(p => (p.Year >= startYear) && (p.Year <= endYear)).ToList();

            //returns list of persons who match criteria
            return listOfPersons;
        }
    }
}
