using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Task3
    {
        public static void Run()
        {
            City city1 = new City(), city2 = new City();
            Console.WriteLine("Init first city:");
            city1.Init();
            Console.WriteLine("Init second city:");
            city2.Init();
            string action, city;
            do
            {
                Console.Write("Enter what to do(rise(citizens), cut(citizens), compare, show, exit): ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "rise":
                        Console.Write("Enter which city to work with(first, second): ");
                        city = Console.ReadLine();
                        Console.Write("Enter sum of rising: ");
                        int rise;
                        int.TryParse(Console.ReadLine(), out rise);
                        if (city == "first")
                            city1 = city1 + rise;
                        else if (city == "second")
                            city2 = city2 + rise;
                        break;

                    case "cut":
                        Console.Write("Enter which city to work with(first, second): ");
                        city = Console.ReadLine();
                        Console.Write("Enter sum of rising: ");
                        int cut;
                        int.TryParse(Console.ReadLine(), out cut);
                        if (city == "first")
                            city1 = city1 - cut;
                        else if (city == "second")
                            city2 = city2 - cut;
                        break;

                    case "compare":
                        Console.Write("Which compare result you want(>, <, ==, !=, Equals): ");
                        string compare = Console.ReadLine();
                        switch (compare)
                        {
                            case ">":
                                Console.WriteLine($"Result(city1 > city2): {city1 > city2}");
                                break;
                            case "<":
                                Console.WriteLine($"Result(city1 < city2): {city1 < city2}");
                                break;
                            case "==":
                                Console.WriteLine($"Result(city1 == city2): {city1 == city2}");
                                break;
                            case "!=":
                                Console.WriteLine($"Result(city1 != city2): {city1 != city2}");
                                break;
                            case "Equals":
                                Console.WriteLine($"Result(city1.Equals(city2)): {city1.Equals(city2)}");
                                break;
                        }
                        break;

                    case "show":
                        Console.WriteLine("First city's info:");
                        city1.ShowInfo();
                        Console.WriteLine("Second city's info:");
                        city2.ShowInfo();
                        break;
                }

            } while (action != "exit");
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

        public void Init()
        {
            Console.Write("Enter city's name: ");
            _name = Console.ReadLine();
            Console.Write("Enter the country it belongs to: ");
            _country = Console.ReadLine();
            int num;
            Console.Write("Enter number of citizens: ");
            int.TryParse(Console.ReadLine(), out num);
            _num_of_citizens = num;
            Console.Write("Enter its telephone code: ");
            _telephone_code = Console.ReadLine();
            Console.Write("Enter its districts names: ");
            _districts_names = Console.ReadLine().Split(' ');
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

        public static City operator +(City city, int num)
        {
            city.SetCitizens(city.GetCitizens() + num);
            return city;
        }
        public static City operator +(int num, City city)
        {
            city.SetCitizens(city.GetCitizens() + num);
            return city;
        }

        public static City operator -(City city, int num)
        {
            city.SetCitizens(city.GetCitizens() - num);
            return city;
        }
        public static City operator -(int num, City city)
        {
            city.SetCitizens(city.GetCitizens() - num);
            return city;
        }

        public static bool operator >(City city1, City city2)
        {
            return city1.GetCitizens() > city2.GetCitizens();
        }
        public static bool operator <(City city1, City city2)
        {
            return city1.GetCitizens() < city2.GetCitizens();
        }

        public static bool operator ==(City city1, City city2)
        {
            return city1.GetCitizens() == city2.GetCitizens();
        }
        public static bool operator !=(City city1, City city2)
        {
            return city1.GetCitizens() != city2.GetCitizens();
        }
        
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj.GetType().Equals(GetType())))
                return false;
            City cmp = (City)obj;
            if (cmp.GetName() != GetName()) 
                return false;
            if (cmp.GetCountry() != GetCountry())
                return false;
            if (cmp.GetCitizens() != GetCitizens())
                return false;
            if (cmp.GetTelephone() != GetTelephone())
                return false;
            if(cmp.GetDistricts().Length!=GetDistricts().Length)
                return false;
            for (int i = 0; i < cmp.GetDistricts().Length; i++)
                if (cmp.GetDistricts()[i] != GetDistricts()[i])
                    return false;
            return true;
        }
    }
}
