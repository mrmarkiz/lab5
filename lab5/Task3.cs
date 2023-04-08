using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Task3
    {
        public static void Run()
        {

        }
    }

    class City
    {
        private string _name { get; set; }
        private string _country { get; set; }
        private int _num_of_citizens { get; set; }
        private string _telephone_code { get; set; }
        private string[] _districts_names { get; set; }


        public City(string name, string country, int num_of_citizens, string telephone_code, string[] districts_names)
        {
            this._name = name;
            this._country = country;
            this._num_of_citizens = num_of_citizens;
            this._telephone_code = telephone_code;
            this._districts_names = new string[districts_names.Length];
            districts_names.CopyTo(this._districts_names, 0);
        }

        public City()
        {
            this._name = "None";
            this._country = "None";
            this._num_of_citizens = 0;
            this._telephone_code = "None";
        }

        public void SetName(string name)
        {
            this._name = name;
        }
        public void SetCountry(string country)
        {
            this._country = country;
        }
        public void SetCitizens(int num_of_citizens)
        {
            this._num_of_citizens = num_of_citizens;
        }
        public void SetTelephone(string telephone)
        {
            this._telephone_code = telephone;
        }
        public void SetDistricts(string[] districts)
        {
            this._districts_names = new string[districts.Length];
            districts.CopyTo(this._districts_names, 0);
        }

        public string GetName()
        {
            return this._name;
        }
        public string GetCountry()
        {
            return this._country;
        }
        public int GetCitizens()
        {
            return this._num_of_citizens;
        }
        public string GetTelephone()
        {
            return this._telephone_code;
        }
        public string[] GetDistricts()
        {
            return this._districts_names;
        }

        public void ShowInfo()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("City info:");
            Console.WriteLine($"Name: {this._name}");
            Console.WriteLine($"Country belonging: {this._country}");
            Console.WriteLine($"Number of citizens: {this._num_of_citizens}");
            Console.WriteLine($"Telephone code: {this._telephone_code}");
            Console.WriteLine("Districts names:");
            foreach (string st in this._districts_names)
            {
                Console.WriteLine(st);
            }
            Console.WriteLine("--------------------------------");
        }
    }
}
