using System;
using System.Collections.Generic;
using System.Linq;

namespace GradebookDictVerTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create gradebook dict where the keys are unique IDs and the values are names as strings

            Dictionary<int, string> students = new Dictionary<int, string>();
            List<string> studentNames = new List<string>();

            string newStudent;
            int newID;

            Console.WriteLine("Enter your students (or ENTER to finish):");
            
            //collect student names and add to a temp list
            do
            {
                newStudent = Console.ReadLine();
                if (newStudent != "")
                {
                    studentNames.Add(newStudent);
                }
            } while (newStudent != "");

            //loop thru list, enter ID and add dictionary k/v pairs
            Console.WriteLine("Enter student IDs for each student:");
            foreach (string student in studentNames)
            {
                Console.WriteLine(string.Format("Student: {0}", student));
                newID = int.Parse(Console.ReadLine());
                students.Add(newID, student);
            }

            //print class roster
            Console.WriteLine("\nClass Roster:");
            foreach (KeyValuePair<int, string> student in students)
            {
                Console.WriteLine(string.Format("ID: {0} \t Name: {1}", student.Key, student.Value));
            }

            Console.ReadLine();
        }
    }
}
