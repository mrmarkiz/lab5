using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace lab5
{
    internal class Task1
    {
        public static void Run()
        {
            Worker worker1 = new Worker(), worker2 = new Worker();
            Console.WriteLine("Enter first worker's parameters: ");
            worker1.Init();
            Console.WriteLine("Enter second worker's parameters: ");
            worker2.Init();
            string action, worker;
            do
            {
                Console.Write("Enter what to do(rise(salary), cut(salary), compare, show, exit): ");
                action = Console.ReadLine();
                switch (action)
                {
                    case "rise":
                        Console.Write("Enter which worker to work with(first, second): ");
                        worker = Console.ReadLine();
                        Console.Write("Enter sum of rising: ");
                        int rise;
                        int.TryParse(Console.ReadLine(), out rise);
                        if (worker == "first")
                            worker1 = worker1 + rise;
                        else if (worker == "second")
                            worker2 = worker2 + rise;
                        break;

                    case "cut":
                        Console.Write("Enter which worker to work with(first, second): ");
                        worker = Console.ReadLine();
                        Console.Write("Enter sum of cutting: ");
                        int cut;
                        int.TryParse(Console.ReadLine(), out cut);
                        if (worker == "first")
                            worker1 = worker1 - cut;
                        else if (worker == "second")
                            worker2 = worker2 - cut;
                        break;

                    case "compare":
                        Console.Write("Which compare result you want(>, <, ==, !=, Equals): ");
                        string compare = Console.ReadLine();
                        switch(compare)
                        {
                            case ">":
                                Console.WriteLine($"Result(worker1 > worker2): {worker1 > worker2}");
                                break;
                            case "<":
                                Console.WriteLine($"Result(worker1 < worker2): {worker1 < worker2}");
                                break;
                            case "==":
                                Console.WriteLine($"Result(worker1 == worker2): {worker1 == worker2}");
                                break;
                            case "!=":
                                Console.WriteLine($"Result(worker1 != worker2): {worker1 != worker2}");
                                break;
                            case "Equals":
                                Console.WriteLine($"Result(worker1.Equals(worker2)): {worker1.Equals(worker2)}");
                                break;
                        }
                        break;

                    case "show":
                        Console.WriteLine("First worker's info:");
                        worker1.ShowInfo();
                        Console.WriteLine("Second worker's info:");
                        worker2.ShowInfo();
                        break;
                }

            } while (action != "exit");
        }
    }

    class Worker
    {
        private string _initials { get; set; }
        private int[] _birthday { get; set; }
        private string _telephone { get; set; }
        private string _email { get; set; }
        private string _position { get; set; }
        private int _salary { get; set; }
        private string[] _duties { get; set; }

        public Worker(string initials, int[] birthday, string telephone, string email, string post, int salary ,string[] duties)
        {
            this._initials = initials;
            this._birthday = new int[birthday.Length];
            birthday.CopyTo(this._birthday, 0);
            this._telephone = telephone;
            this._email = email;
            this._position = post;
            this._salary = salary;
            this._duties = new string[duties.Length];
            duties.CopyTo(this._duties, 0);
        }

        public Worker(Worker other)
        {
            this._initials = other._initials;
            this._birthday = new int[other._birthday.Length];
            other._birthday.CopyTo(this._birthday, 0);
            this._telephone = other._telephone;
            this._email = other._email;
            this._position = other._position;
            this._salary = other._salary;
            this._duties = new string[other._duties.Length];
            other._duties.CopyTo(this._duties, 0);
        }

        public Worker()
        {
            this._initials = "None None None";
            this._birthday = new int[3] { 0, 0, 0 };
            this._telephone = "None";
            this._email = "None";
            this._position = "None";
            this._salary = 0;
            this._duties = new string[0];
        }

        public void Init()
        {
            Console.Write("Enter worker's initials: ");
            this._initials = Console.ReadLine();
            Console.Write("Enter worker's birthday: ");
            string[] birth = Console.ReadLine().Split(' ', '.');
            this._birthday = new int[birth.Length];
            for (int i = 0; i < birth.Length; i++)
                int.TryParse(birth[i], out this._birthday[i]);
            Console.Write("Enter telephone: ");
            this._telephone = Console.ReadLine();
            Console.Write("Enter e-mail: ");
            this._email = Console.ReadLine();
            Console.Write("Enter position: ");
            this._position = Console.ReadLine();
            Console.Write("Enter salary: ");
            int salary;
            int.TryParse(Console.ReadLine(), out salary);
            this._salary = salary;
            Console.WriteLine("Enter duties: ");
            this._duties = Console.ReadLine().Split(' ');
        }

        public void SetInitials(string initials)
        {
            this._initials = initials;
        }
        public void SetBirthday(int[] birthday)
        {
            this._birthday = new int[birthday.Length];
            birthday.CopyTo(this._birthday, 0);
        }
        public void SetTelephone(string telephone)
        {
            this._telephone = telephone;
        }
        public void SetEmail(string email)
        {
            this._email = email;
        }
        public void SetPosition(string post)
        {
            this._position = post;
        }
        public void SetSalary(int salary)
        {
            this._salary = salary;
        }
        public void SetDuties(string[] duties)
        {
            this._duties = new string[duties.Length];
            duties.CopyTo(this._duties, 0);
        }

        public string GetInitials()
        {
            return this._initials;
        }
        public int[] GetBirthday()
        {
            return this._birthday;
        }
        public string GetTelephone()
        {
            return this._telephone;
        }
        public string GetEmail()
        {
            return this._email;
        }
        public string GetPosition()
        {
            return this._position;
        }
        public int GetSalary()
        {
            return this._salary;
        }
        public string[] GetDuties()
        {
            return this._duties;
        }

        public void ShowInfo()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Initials: {this._initials}");
            Console.Write($"Birthday: ");
            foreach (int d in this._birthday)
            {
                Console.Write($"{d} ");
            }
            Console.WriteLine($"\nTelephone: {this._telephone}");
            Console.WriteLine($"E-mail: {this._email}");
            Console.WriteLine($"Position {this._position}");
            Console.WriteLine($"Salary {this._salary}");
            Console.WriteLine("Duties:");
            foreach (string dut in this._duties)
                Console.WriteLine(dut);
            Console.WriteLine("--------------------------------");
        }

        public void Edit()
        {
            string action, buf;
            Console.Write("Enter what to edit(initials, birthday, telephone, e-mail, position, salary, duties): ");
            action = Console.ReadLine();
            string[] bufarr, duties;
            int[] birthday;
            switch (action)
            {
                case "initials":
                    Console.WriteLine($"Previous initials: {this.GetInitials()}");
                    Console.Write("Enter new initials: ");
                    buf = Console.ReadLine();
                    this.SetInitials(buf);
                    break;

                case "birthday":
                    Console.Write($"Previous birthday: ");
                    foreach (int b in this.GetBirthday())
                        Console.Write($"{b} ");
                    Console.Write("\nEnter new birthday: ");
                    bufarr = Console.ReadLine().Split(' ', '.');
                    birthday = new int[bufarr.Length];
                    try
                    {
                        for (int i = 0; i < birthday.Length; i++)
                            birthday[i] = int.Parse(bufarr[i]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error collapsed: {ex.Message}");
                        return;
                    }
                    this.SetBirthday(birthday);
                    break;

                case "telephone":
                    Console.WriteLine($"Previous telephone: {this.GetTelephone()}");
                    Console.Write("Enter new telephone: ");
                    buf = Console.ReadLine();
                    this.SetTelephone(buf);
                    break;

                case "e-mail":
                    Console.WriteLine($"Previous e-mail: {this.GetEmail()}");
                    Console.Write("Enter new e-mail: ");
                    buf = Console.ReadLine();
                    this.SetEmail(buf);
                    break;

                case "position":
                    Console.WriteLine($"Previous position: {this.GetPosition()}");
                    Console.Write("Enter new position: ");
                    buf = Console.ReadLine();
                    this.SetPosition(buf);
                    break;

                case "salary":
                    Console.WriteLine($"Previous salary: {this.GetSalary()}");
                    Console.Write("Enter new salary: ");
                    int salary;
                    int.TryParse(Console.ReadLine(), out salary);
                    this.SetSalary(salary);
                    break;

                case "duties":
                    Console.WriteLine("Previous duties:");
                    foreach (string dut in this.GetDuties())
                        Console.Write($"{dut}   ");
                    Console.Write("\nEnter what to do(add, delete): ");
                    buf = Console.ReadLine();
                    duties = this.GetDuties();
                    string duty;
                    switch (buf)
                    {
                        case "add":
                            Console.Write("Enter name of duty: ");
                            duty = Console.ReadLine();
                            duties = duties.Append(duty).ToArray();
                            this.SetDuties(duties);
                            break;
                        case "delete":
                            Console.Write("Enter name of duty: ");
                            duty = Console.ReadLine();
                            duties = duties.Where(el => el != duty).ToArray();
                            this.SetDuties(duties);
                            break;
                    }
                    break;
            }
        }

        public static Worker operator + (int num, Worker worker)
        {
            worker.SetSalary(worker.GetSalary() + num);
            return worker;
        }
        public static Worker operator + (Worker worker, int num)
        {
            worker.SetSalary(worker.GetSalary() + num);
            return worker;
        }
        public static Worker operator - (int num, Worker worker)
        {
            worker.SetSalary(worker.GetSalary() - num);
            return worker;
        }
        public static Worker operator - (Worker worker, int num)
        {
            worker.SetSalary(worker.GetSalary() - num);
            return worker;
        }

        public static bool operator >(Worker worker1, Worker worker2)
        {
            return worker1.GetSalary() > worker2.GetSalary();
        }
        public static bool operator <(Worker worker1, Worker worker2)
        {
            return worker1.GetSalary() < worker2.GetSalary();
        }

        public static bool operator ==(Worker worker1, Worker worker2)
        {
            return worker1.GetSalary() == worker2.GetSalary();
        }
        public static bool operator !=(Worker worker1, Worker worker2)
        {
            return worker1.GetSalary() != worker2.GetSalary();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj.GetType().Equals(GetType())))
                return false;
            Worker worker2 = (Worker)obj;

            if (this.GetInitials() != worker2.GetInitials())
                return false;

            if (this.GetBirthday().Length != worker2.GetBirthday().Length)
                return false;
            for (int i = 0; i < this.GetBirthday().Length; i++)
                if (this.GetBirthday()[i] != worker2.GetBirthday()[i])
                    return false;

            if (this.GetTelephone() != worker2.GetTelephone())
                return false;

            if (this.GetEmail() != worker2.GetEmail())
                return false;

            if (this.GetPosition() != worker2.GetPosition())
                return false;

            if (this.GetSalary() != worker2.GetSalary())
                return false;

            if (this.GetDuties().Length != worker2.GetDuties().Length)
                return false;
            for (int i = 0; i < this.GetDuties().Length; i++)
                if (this.GetDuties()[i] != worker2.GetDuties()[i])
                    return false;
            return true;
        }


    }
}
