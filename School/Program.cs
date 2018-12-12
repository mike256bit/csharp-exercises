using System;
using System.Linq;
using System.Collections.Generic;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>();
            
            //initialize student classes
            Student Mike = new Student("Mike", 254377, 18);
            Student Nicole = new Student("Nicole", 331988, 18);
            Student Samara = new Student("Samara", 229916, 18);
            Student Cezar = new Student("Cezar", 492151, 18);
            Student Senada = new Student("Senada", 737321, 18);
            
            //initialize courses
            Course Bio = new Course("Biology", "Mr. Franklin");
            Course Chem = new Course("Chemistry", "Mr. Dettloff");

            //add courses to course list
            courses.Add(Bio);
            courses.Add(Chem);

            //add students to courses
            Bio.AddStudent(Mike);
            Bio.AddStudent(Cezar);
            Bio.AddStudent(Senada);
            Chem.AddStudent(Nicole);
            Chem.AddStudent(Samara);


            foreach (Course course in courses)
            {
                Console.WriteLine("\nCourse: {0}\nInstructor: {1}", course.CourseTitle, course.Instructor);
                course.PrintStudents();
            }

            Console.ReadLine();

        }
    }

    class Course
    {
        public string CourseTitle { get; set; }
        public string Instructor { get; set; }
        private List<Student> Enrolled = new List<Student>();
        public const int CLASS_LIMIT = 30;

        public Course(string course, string instructor)
        {
            CourseTitle = course;
            Instructor = instructor;
        }

        public void AddStudent(Student student) {
            Enrolled.Add(student);     
        
        }

        public void PrintStudents()
        {
            Console.WriteLine("\nStudents:");
            foreach (Student student in Enrolled)
            {
                Console.WriteLine("Name: {0} \t ID: {1} \t ENROLLED",
                    student.Name, student.StudentID);
            }
        }
    }

    class Student
    {
        public string Name { get; set; }
        public int StudentID { get; set; }
        public int NumberOfCredits { get; set; }
        private double gpa;
        public double Gpa
        {
            get { return gpa; }
            internal set { gpa = value;  }
        }

        public Student(string name, int id, int numcredits)
        {
            Name = name;
            StudentID = id;
            NumberOfCredits = numcredits;
            Gpa = 4.0;
        }

    }
}
