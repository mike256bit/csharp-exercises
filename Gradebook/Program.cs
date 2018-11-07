using System;
using System.Collections.Generic;
using System.Linq;

namespace Gradebook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // initialize the list objects and declare what kind of data they will store.
            List<string> students = new List<string>();
            List<double> grades = new List<double>();
            string newStudent;

            Console.WriteLine("Enter your students (or ENTER to finish):");

            // prompt for name, if name isn't empty, add it to the student list. Get the next ReadLine and add until user returns "" (by returning the empty line)

            do
            {
                newStudent = Console.ReadLine();
                if (newStudent != "")
                {
                    students.Add(newStudent);
                }
            }
            while (newStudent != "");

            // Get student grades
            foreach (string student in students)
            {
                Console.WriteLine("Grade for " + student + ": ");
                double newGrade = double.Parse(Console.ReadLine());
                grades.Add(newGrade);
            }

            // Print class roster
            Console.WriteLine("\nClass roster:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i] + " (" + grades[i] + ")");
            }

            double sum = grades.Sum();
            double avg = sum / grades.Count;
            Console.WriteLine("Average grade: " + avg);

            Console.ReadLine();
        }
    }
}

/*
 *  List Methods:
 *      .Add()          Adds item
 *      .Contains()     Checks list for item, returns boolean
 *      .IndexOf()      Returns index pos of first occurance of item, else -1 if not in list
 *      .Sort()         Sorts list by default sort comparison (?)
 *      .ToArray()      Return array containing elements of list
