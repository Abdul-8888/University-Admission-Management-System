using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;

namespace UAMS.UI
{
    class StudentUI
    {
        public static void calculateFeeForAll()
        {
            foreach (Student s in StudentDL.studentList)
            {
                if (s.getRegDegree() != null)
                {
                    Console.WriteLine("{0} has {1} fee.", s.getName(), s.calculateFee());
                }
            }
        }

        public static void registeredSubjects(Student s)
        {
            Console.WriteLine("How many subjects you want to register: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter subject code: ");
                string code = Console.ReadLine();
                bool flag = false;

                foreach (Subject sub in s.getRegDegree().getSubjects())
                {
                    if (code == sub.getCode() && !(s.getRegSubjects().Contains(sub)))
                    {
                        s.regStudentSubject(sub);
                        flag = true;
                        break;
                    }
                }

                if (flag == false)
                {
                    Console.WriteLine("Enter valid course");
                    i--;
                }
            }
        }

        public static void viewRegisteredStudents()
        {
            Console.WriteLine("Name \t Age \t Fsc \t Ecat");

            foreach (Student s in StudentDL.studentList)
            {
                if (s.getRegDegree() != null)
                {
                    Console.WriteLine("{0} \t {1} \t {2} \t {3}", s.getName(), s.getAge(), s.getFscMarks(), s.getEcatMarks());
                }
            }
        }

        public static Student takeInputForStudent()
        {
            string name;
            int age;
            float fscMarks;
            float ecatMarks;
            List<DegreeProgram> preferences = new List<DegreeProgram>();

            Console.WriteLine("Enter Student name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Student Age: ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student FSc Marks: ");
            fscMarks = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Ecat Marks: ");
            ecatMarks = float.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs");

            DegreeProgramUI.viewDegreeProgram();

            Console.WriteLine("Enter how many Preferences to enter: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string degName = Console.ReadLine();
                bool flag = false;

                foreach (DegreeProgram dp in DegreeProgramDL.programList)
                {
                    if (degName == dp.getDegreeName() && !(preferences.Contains(dp)))
                    {
                        preferences.Add(dp);
                        flag = true;
                    }
                }

                if (flag == false)
                {
                    Console.WriteLine("Enter valid Degree Program Name");
                    i--;
                }
            }

            Student s = new Student(name, age, fscMarks, ecatMarks, preferences);
            return s;
        }

        public static void viewSubjects(Student s)
        {
            if (s.getRegDegree() != null)
            {
                Console.WriteLine("Sub Code \t Sub Type");
                foreach (Subject sub in s.getRegDegree().getSubjects())
                {
                    Console.WriteLine("{0} \t\t {1}", sub.getCode(), sub.getSubjectType());
                }
            }
        }

        public static string enterStudentName()
        {
            Console.WriteLine("Enter the Student Name: ");
            return (Console.ReadLine());
        }
    }
}
