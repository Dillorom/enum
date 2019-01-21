using System;
using System.Collections.Generic;

namespace SchoolTracker
{
    enum School
    {
        CanyonPark,
        Westhill,
        Kenmore, 
        Bothell,
    }

    class Program
    {
        static List<Student> students = new List<Student>();
        static void Main(string[] args)
        {
            

            var adding = true;

            while (adding)
            {
                try
                {
                    var newStudent = new Student();

                    newStudent.Name = Util.Console.Ask("Student Name: ");

                    newStudent.Grade = Util.Console.AskInt("Student Grade: ");

                    newStudent.School = (School) Util.Console.AskInt("School Name (select corresponing number): \n 0: Canyon Park, \n 1: Westhill Elementary,\n  2: Kenmore Elementary, \n 3: Bothell High \n ");

                    newStudent.Birthday = Util.Console.Ask("Student Birthday: ");

                    newStudent.Address = Util.Console.Ask("Student Address: ");

                    newStudent.Phone = Util.Console.AskInt("Student Phone Number: ");

                    students.Add(newStudent);
                    Student.Count++;
                    Console.WriteLine("Student Count: {0}", Student.Count);

                    Console.WriteLine("Add another? y/n");

                    if (Console.ReadLine() != "y")
                        adding = false;
                }
                catch (FormatException msg)
                {
                    Console.WriteLine(msg.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error adding student, Please try again");
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine("Name: {0}, Grade: {1}", student.Name, student.Grade);
            }
            Exports();
        }

        static void Import()
        {
            var importedStudent = new Student("Jenny", 86, "birthday", "address", 123456);
            Console.WriteLine(importedStudent.Name);
        }

        static void Exports()
        {
            foreach (var student in students)
            {
                switch(student.School)
                {
                    case School.CanyonPark:
                        Console.WriteLine("Exporting to Canyon Park");
                        break;
                    case School.Westhill:
                        Console.WriteLine("Exproting to Westhill Elementary");
                        break;
                    case School.Kenmore:
                        Console.WriteLine("Exporting to Kenmore Elementary");
                        break;
                    case School.Bothell:
                        Console.WriteLine("Exporting to Bothell High");
                        break;
                }
                Console.ReadKey();
            }
        }
    }

    class Member
    {
        public string Name;
        public string Address;
        protected int phone;

        public int Phone
        {
            set { phone = value; }
        }
    }

    class Student : Member
    {
        static public int Count = 0;

        public int Grade;
        public string Birthday;
        public School School;

        public Student()
        {

        }

        public Student(string name, int grade, string birthday, string address, int phone)
        {
            Name = name;
            Grade = grade;
            Birthday = birthday;
            Address = address;
            Phone = phone;
        }
    }

    class Teacher : Member
    {
        public string Subject;
    }
}
