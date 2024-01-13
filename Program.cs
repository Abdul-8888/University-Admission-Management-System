using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;
using UAMS.UI;

namespace UAMS
{
    class Program
    {
        static void Main(string[] args)
        {
            string SubjectFilePath = "D:\\Study\\Semester 2\\UAMS\\bin\\Debug\\Subjects.txt";
            string DegreeProgramFilePath = "D:\\Study\\Semester 2\\UAMS\\bin\\Debug\\Degrees.txt";
            string StudentFilePath = "D:\\Study\\Semester 2\\UAMS\\bin\\Debug\\Students.txt";
            SubjectDL.loadSubjects(SubjectFilePath);
            DegreeProgramDL.loadDegreePrograms(DegreeProgramFilePath);
            StudentDL.loadStudents(StudentFilePath);

            while (true)
            {
                ProgramUI.header();
                char choice = ProgramUI.menu();

                //_____________________________________________________Adding Student
                if(choice =='1')
                {
                    if(DegreeProgramDL.programList.Count > 0)
                    {
                        Student s = StudentUI.takeInputForStudent();
                        StudentDL.addIntoStudentList(s);
                    }

                    else
                    {
                        ProgramUI.printOnScreen("No Programs to register Students.");
                    }
                }

                //_____________________________________________________Adding Degree Program
                else if(choice == '2')
                {
                    DegreeProgram d = ProgramUI.takeInputForDegree();
                    DegreeProgramDL.addInDegreeList(d);
                }

                //____________________________________________________Generating Merit
                else if (choice == '3')
                {
                    List<Student> sortedStudentList = new List<Student>();
                    sortedStudentList = StudentDL.sortStudentsByMerit();
                    DegreeProgramDL.giveAdmission(sortedStudentList);
                    ProgramUI.printStudents();
                }

                //_________________________________________________________View Registered Students
                else if (choice == '4')
                {
                    StudentUI.viewRegisteredStudents();
                }

                //_________________________________________________View Students of a specific program
                else if (choice == '5')
                {
                    string degName = DegreeProgramUI.enterDegreeName();
                    DegreeProgramUI.viewStudentsInDegree(degName);
                }

                //____________________________________________________Adding subjects for a specific Student
                else if(choice == '6')
                {
                    string name = StudentUI.enterStudentName();
                    Student s = StudentDL.studentPresent(name);

                    if(s != null)
                    {
                        StudentUI.viewSubjects(s);
                        StudentUI.registeredSubjects(s);
                    }
                }

                //______________________________________________Generating fee for admitted students
                else if(choice == '7')
                {
                    StudentUI.calculateFeeForAll();
                }

                //_____________________________________________Exiting
                else if(choice == '8')
                {
                    break;
                }

                //___________________________________________Wrong option
                else
                {
                    ProgramUI.printOnScreen("Invalid Choice.");
                }
                    ProgramUI.clearScreen();
            }

            SubjectDL.storeSubjects(SubjectFilePath);
            DegreeProgramDL.storeDegreePrograms(DegreeProgramFilePath);
            StudentDL.storeStudents(StudentFilePath);

            Console.ReadKey();
        }

    }
}
