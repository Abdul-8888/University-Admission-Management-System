using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;

namespace UAMS.UI
{
    class DegreeProgramUI
    {
        public static void viewStudentsInDegree(string degName)
        {
            Console.WriteLine("Name \t FSC \t Ecat \t Age");

            foreach (Student s in StudentDL.studentList)
            {
                if (s.getRegDegree() != null)
                {
                    Console.WriteLine("{0} \t {1} \t {2} \t {3}", s.getName(), s.getFscMarks(), s.getEcatMarks(), s.getAge());
                }
            }
        }

        public static void viewDegreeProgram()
        {
            foreach (DegreeProgram dp in DegreeProgramDL.programList)
            {
                Console.WriteLine(dp.getDegreeName());
            }
        }

        public static string enterDegreeName()
        {
            Console.WriteLine("Enter degree name: ");
            return (Console.ReadLine());
        }
    }
}
