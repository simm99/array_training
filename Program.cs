using System;
using System.Collections.Generic;

namespace StudentList
{
    class Students
    {
        static void Main(string[] args)
        {
            Console.Write("How many students do you want to add to you class: ");
            string studentString = Console.ReadLine();
            int amount;

            // Validera att användaren skriver ett giltigt tal
            while (!int.TryParse(studentString, out amount) || amount <= 0)
            {
                Console.Write("Invalid input. Please enter a valid number greater than 0: ");
                studentString = Console.ReadLine();
            }

            bool IsValidName(string name)
            {
                foreach (char c in name)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        return false;
                    }
                }
                return !string.IsNullOrWhiteSpace(name);
            }

            string[] studentList = new String[amount];


            Console.WriteLine("\nPlease type in the names of the students: ");

            for (int i = 0; i < studentList.Length; i++)
            {
                string studentName = "";
                // Tvinga användaren att skriva in ett namn
                while(!IsValidName(studentName))
                {
                    Console.WriteLine($"Enter name for student {i + 1}: ");
                    studentName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(studentName))
                    {
                        Console.WriteLine("You have to enter a name. Try again: ");
                    }
                }
                studentList[i] = studentName;
            }
            
            Console.WriteLine("\nHere the students are in Alphabetically order: ");
            Array.Sort(studentList);
            for (int i = 0; i < studentList.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {studentList[i]}");
            }
            Console.WriteLine("\nWould you like to remove a student from the list? if so, please type the name of the student ");
            string input = Console.ReadLine();
            if (studentList.Contains(input))
            {
                studentList = studentList.Where(name => name != input) .ToArray();
                Console.WriteLine("\nUpdated list of names: ");
                if (studentList.Length == 0)
                {
                    Console.WriteLine("The student list is now empty.");
                }
                else
                {
                    for(int i = 0; i < studentList.Length; i++)
                        {
                            Console.WriteLine(studentList[i]);
                        }
                }
                
            }
            else
            {
                Console.WriteLine("That name does not exist in the current class");
                
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();


        }  
    }
}