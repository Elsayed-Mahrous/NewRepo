using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

namespace Hallo_world
{

    class Student
    {
        public int StudentId;
        public string Name;
        public int Age;
        public List<Course> Courses;



        public Student(int studentId, string name, int age)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
            Courses = new List<Course>();
        }

        public bool Enroll(Course course)
        {

            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].Title == course.Title)
                    return false;

            }
            Courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            return $"Name: {Name}, ID: {StudentId}, Age: {Age}";
        }
    }

    class Instructor
    {
        public int InstructorId;
        public string Name;
        public string Specialization;

        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }

        public string PrintDetails()
        {
            return $"Instructor Id:  {InstructorId}, Name:  {Name},  specialization:  {Specialization}";
        }
    }

    class Course
    {
        public int CourseId;
        public string Title;
        public Instructor Instructor;

        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            this.Instructor = instructor;
        }

        public string PrintDetails()
        {
            return $"Course Id:  {CourseId}, Title:  {Title},  instructor:  {Instructor.Name}";
        }
    }

    class School
    {
        public List<Student> Students;
        public List<Course> Courses;
        public List<Instructor> Instructors;
        public School()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
            Instructors = new List<Instructor>();
        }


        public bool AddStudent(Student student)
        {
            if (student is not null)
            {
                Students.Add(student);
                return true;
            }
            return false;
        }
        public bool AddCourse(Course course)
        {
            if (course is not null)
            {
                Courses.Add(course);
                return true;
            }
            return false;
        }
        public bool AddInstructor(Instructor instructor)
        {
            if (instructor is not null)
            {
                Instructors.Add(instructor);
                return true;
            }
            return false;

        }
        public Student FindStudent(int studentId)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == studentId)
                {
                    return Students[i];
                }
            }
            return null;
        }
        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                {
                    return Courses[i];
                }
            }
            return null;
        }
        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructorId)
                {
                    return Instructors[i];
                }
            }
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student != null && course != null)
            {
                student.Enroll(course);
                return true;
            }


            return false;
        }



        internal class Program
        {
            static void Main(string[] args)
            {
                School school = new School();
                int yourOption;

                do
                {
                    Console.WriteLine("\n\n\n1.Add Student");
                    Console.WriteLine("2.Add Instructor");
                    Console.WriteLine("3.Add Course");
                    Console.WriteLine("4.Enroll Student in Course");
                    Console.WriteLine("5.Show All Students");
                    Console.WriteLine("6.Show All Courses");
                    Console.WriteLine("7.Show All Instructors");
                    Console.WriteLine("8.Find the student by id or name");
                    Console.WriteLine("9.Fine the course by id or name");
                    Console.WriteLine("10.Exit");
                    yourOption = Convert.ToInt32(Console.ReadLine());

                    switch (yourOption)
                    {
                        case 1:
                            {
                                Console.Write("enter name student: ");
                                string name = Console.ReadLine();
                                Console.Write("enter age student: ");
                                int age = Convert.ToInt32(Console.ReadLine());
                                int studentId = school.Students.Count + 1;
                                Student student = new Student(studentId, name, age);
                                school.AddStudent(student);
                            }
                            break;
                        case 2:
                            {
                                Console.Write("enter name insructor: ");
                                string name = Console.ReadLine();
                                Console.Write("enter insructor Specialization: ");
                                string Specialization = Console.ReadLine();
                                int studentId = school.Instructors.Count + 1;
                                Instructor instructor = new Instructor(studentId, name, Specialization);
                                school.AddInstructor(instructor);
                            }
                            break;
                        case 3:
                            {
                                Console.Write("enter title Coruse: ");
                                string titleCourse = Console.ReadLine();

                                Console.Write("enter instructorId: ");
                                int instructorId = Convert.ToInt32(Console.ReadLine());

                                bool isHere = false;
                                for (int i = 0; i < school.Instructors.Count; i++)
                                {
                                    if (school.Instructors[i].InstructorId == instructorId)
                                    {
                                        Course course = new Course(school.Courses.Count + 1, titleCourse, school.Instructors[i]);
                                        school.AddCourse(course);
                                        isHere = true;
                                        break;
                                    }
                                }
                                if (isHere == false)
                                    Console.WriteLine("instructor Id is not avaliable");
                            }
                            break;

                        case 4:
                            {
                                Console.Write("enter student id: ");
                                int studentId = Convert.ToInt32(Console.ReadLine());

                                Console.Write("enter course Id: ");
                                int courseId = Convert.ToInt32(Console.ReadLine());

                                if (school.EnrollStudentInCourse(studentId, courseId))
                                    Console.WriteLine("done");
                                else
                                    Console.WriteLine("invalid");

                            }
                            break;

                        case 5:
                            {
                                if (school.Students.Count > 0)
                                {
                                    for (int i = 0; i < school.Students.Count; i++)
                                    {
                                        Console.WriteLine(school.Students[i].PrintDetails());
                                    }
                                }
                                else
                                    Console.WriteLine("no students avaliable");
                            }
                            break;

                        case 6:
                            {
                                if (school.Courses.Count > 0)
                                {
                                    for (int i = 0; i < school.Courses.Count; i++)
                                    {
                                        Console.WriteLine(school.Courses[i].PrintDetails());
                                    }
                                }
                                else
                                    Console.WriteLine("no Courses avaliable");
                            }
                            break;

                        case 7:
                            {
                                if (school.Instructors.Count > 0)
                                {
                                    for (int i = 0; i < school.Instructors.Count; i++)
                                    {
                                        Console.WriteLine(school.Instructors[i].PrintDetails());
                                    }
                                }
                                else
                                    Console.WriteLine("no Instructors avaliable");
                            }
                            break;

                        case 8:
                            {
                                bool isRightOptaion = true;
                                do
                                {
                                    Console.Write("enter id student or name (id/name): ");
                                    string option = Console.ReadLine().ToLower();

                                    if (option == "id")
                                    {
                                        Console.Write("\nenter Id:  ");
                                        int id = Convert.ToInt32(Console.ReadLine());
                                        Student student = school.FindStudent(id);
                                        if (student != null)
                                        {
                                            Console.WriteLine(student.PrintDetails());
                                        }
                                        else
                                            Console.WriteLine("this id is not avaliable");
                                    }
                                    else if (option == "name")
                                    {
                                        Console.Write("\nenter name:  ");
                                        string name = Console.ReadLine();
                                        bool isHere = false;
                                        for (int i = 0; i < school.Students.Count; i++)
                                        {
                                            if (school.Students[i].Name == name)
                                            {
                                                Console.WriteLine(school.Students[i].PrintDetails());
                                                isHere = true;
                                            }
                                        }
                                        if (isHere == false)
                                            Console.WriteLine("this name is not avaliable");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid option. Please enter 'id' or 'name'.");
                                        isRightOptaion = false;
                                    }
                                } while (isRightOptaion == false);


                            }
                            break;

                        case 9:
                            {
                                bool isRightOptaion = true;
                                do
                                {
                                    Console.Write("enter id course or name (id/name): ");
                                    string option = Console.ReadLine().ToLower();

                                    if (option == "id")
                                    {
                                        Console.Write("\nenter Id:  ");
                                        int id = Convert.ToInt32(Console.ReadLine());
                                        Course course = school.FindCourse(id);
                                        if (course != null)
                                        {
                                            Console.WriteLine(course.PrintDetails());
                                        }
                                        else
                                            Console.WriteLine("this id is not avaliable");
                                    }
                                    else if (option == "name")
                                    {
                                        Console.Write("\nenter name:  ");
                                        string name = Console.ReadLine();
                                        bool isHere = false;
                                        for (int i = 0; i < school.Courses.Count; i++)
                                        {
                                            if (school.Courses[i].Title == name)
                                            {
                                                Console.WriteLine(school.Courses[i].PrintDetails());
                                                isHere = true;
                                            }
                                        }
                                        if (isHere == false)
                                            Console.WriteLine("this name is not avaliable");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid option. Please enter 'id' or 'name'.");
                                        isRightOptaion = false;
                                    }
                                } while (isRightOptaion == false);


                            }
                            break;

                        case 10:
                            {
                                Console.WriteLine("goodbye");
                                return;
                            }
                            break;



                    }

                } while (yourOption != 10);







            }
        }
    }
}






