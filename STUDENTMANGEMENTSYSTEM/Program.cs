using System;
using System.Collections.Generic;
using System.Linq;

namespace STUDENTMANGEMENTSYSTEM
{
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== STUDENT MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. Show All Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Remove Student");
                Console.WriteLine("6. Add Grades");
                Console.WriteLine("7. Calculate Average");
                Console.WriteLine("8. Exit");

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        ShowAllStudents();
                        break;

                    case "3":
                        SearchStudent();
                        break;

                    case "4":
                        UpdateStudent();
                        break;

                    case "5":
                        RemoveStudent();
                        break;

                    case "6":
                        AddGrade();
                        break;

                    case "7":
                        CalculateAverage();
                        break;

                    case "8":
                        running = false;
                        Console.WriteLine(">> EXIT");
                        break;

                    default:
                        Console.WriteLine(">> Please enter a number from 1 to 8.");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.WriteLine("\n--- Add New Student ---");

            Console.Write("Enter Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(">> Invalid ID.");
                return;
            }

            if (students.Exists(s => s.Id == id))
            {
                Console.WriteLine(">> Student ID already exists.");
                return;
            }

            Console.Write("Enter Student Name: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine(">> Invalid Name.");
                return;
            }

            if (name.Any(char.IsDigit))
            {
                Console.WriteLine(">> Name cannot contain numbers.");
                return;
            }

            Student student = new Student(id, name);

            students.Add(student);

            Console.WriteLine(">> Student Added Successfully.");
        }

        static void ShowAllStudents()
        {
            Console.WriteLine("\n--- Show All Students ---");

            if (students.Count == 0)
            {
                Console.WriteLine(">> No students found.");
                return;
            }

            foreach (Student student in students)
            {
                Console.WriteLine($"ID: {student.Id} | Name: {student.Name}");
            }
        }

        static void SearchStudent()
        {
            Console.WriteLine("\n--- Search Student ---");

            Console.Write("Enter Student ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(">> Invalid ID.");
                return;
            }

            Student? student = students.Find(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine(">> Student Not Found.");
            }
            else
            {
                Console.WriteLine($"ID: {student.Id}");
                Console.WriteLine($"Name: {student.Name}");
            }
        }
        static void UpdateStudent()
        {
            Console.WriteLine("\n--- Update Student ---");

            Console.Write("Enter Student ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(">> Invalid ID.");
                return;
            }

            Student? student = students.Find(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine(">> Student Not Found.");
                return;
            }

            Console.Write("Enter New Name: ");
            string? newName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine(">> Invalid Name.");
                return;
            }

            if (newName.Any(char.IsDigit))
            {
                Console.WriteLine(">> Name cannot contain numbers.");
                return;
            }

            student.Name = newName;

            Console.WriteLine(">> Student Updated Successfully.");
        }

        static void RemoveStudent()
        {
            Console.WriteLine("\n--- Remove Student ---");

            Console.Write("Enter Student ID: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(">> Invalid ID.");
                return;
            }

            Student? student = students.Find(s => s.Id == id);

            if (student == null)
            {
                Console.WriteLine(">> Student Not Found.");
                return;
            }

            students.Remove(student);

            Console.WriteLine(">> Student Removed Successfully.");
        }

        static void AddGrade()
        {
            Console.WriteLine("\n--- Add Grades ---");

            if (students.Count == 0)
            {
                Console.WriteLine(">> No students found.");
                return;
            }

            foreach (Student student in students)
            {
                student.Greads.Clear();

                Console.WriteLine($"\nStudent: {student.Name}");

                for (int i = 1; i <= 8; i++)
                {
                    while (true)
                    {
                        Console.Write($"Enter Grade {i}: ");

                        if (!double.TryParse(Console.ReadLine(), out double grade))
                        {
                            Console.WriteLine(">> Invalid Grade.");
                            continue;
                        }

                        if (grade < 0 || grade > 100)
                        {
                            Console.WriteLine(">> Grade must be between 0 and 100.");
                            continue;
                        }

                        student.Greads.Add(grade);
                        break;
                    }
                }
            }

            Console.WriteLine(">> Grades Added Successfully.");
        }

        static void CalculateAverage()
        {
            Console.WriteLine("\n--- Calculate Average ---");

            if (students.Count == 0)
            {
                Console.WriteLine(">> No students found.");
                return;
            }

            foreach (Student student in students)
            {
                if (student.Greads.Count == 0)
                {
                    Console.WriteLine($"{student.Name} : No Grades");
                    continue;
                }

                double sum = 0;

                foreach (double grade in student.Greads)
                {
                    sum += grade;
                }

                double average = sum / student.Greads.Count;

                Console.WriteLine($"{student.Name} Average = {average:F2}");
            }
        }
    }
}