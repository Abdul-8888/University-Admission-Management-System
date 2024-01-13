using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;

namespace UAMS.UI
{
    class ProgramUI
    {
        //______________________________________Header of the system
        public static void header()
        {
            Console.WriteLine("                   ********************************");
            Console.WriteLine("                                  UAMS             ");
            Console.WriteLine("                   ********************************");
        }

        //___________________________Menu for the user
        public static char menu()
        {
            char choice;

            Console.WriteLine("");
            Console.WriteLine("Menu");
            Console.WriteLine("");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a specific Program");
            Console.WriteLine("6. Registered Subjects for a specific Student");
            Console.WriteLine("7. Calculate Fee for all Registered Students");
            Console.WriteLine("8. Exit");
            Console.WriteLine("");
            Console.Write("Your Choice... ");
            choice = char.Parse(Console.ReadLine());

            return choice;
        }

        public static void printStudents()
        {
            foreach (Student s in StudentDL.studentList)
            {
                if (s.getRegDegree() != null)
                {
                    Console.WriteLine("{0} got admission in {1}", s.getName(), s.getRegDegree().getDegreeName());
                }

                else
                {
                    Console.WriteLine("{0} did not get admission", s.getName());
                }
            }
        }

        //______________________________Screen Clearing
        public static void clearScreen()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static DegreeProgram takeInputForDegree()
        {
            string degreeName;
            string degreeDuration;
            int seats;

            Console.WriteLine("Enter degree name: ");
            degreeName = Console.ReadLine();
            Console.WriteLine("Enter degree duration: ");
            degreeDuration = Console.ReadLine();
            Console.WriteLine("Enter seats for degree: ");
            seats = int.Parse(Console.ReadLine());

            DegreeProgram degProg = new DegreeProgram(degreeName, degreeDuration, seats);

            Console.WriteLine("Enter how many Subjects to enter: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                degProg.addSubject(takeInputForSubject());
            }

            return degProg;
        }

        static Subject takeInputForSubject()
        {
            Console.WriteLine("Enter Subject Code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter Subject type: ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Subject Credit hours: ");
            int creditHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Subject Fee: ");
            int subjectFee = int.Parse(Console.ReadLine());

            Subject sub = new Subject(code, creditHours, type, subjectFee);

            return sub;
        }

        public static void printOnScreen(string line)
        {
            Console.WriteLine(line);
        }
    }
}
