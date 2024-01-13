using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.DL
{
    class StudentDL
    {
        static public List<Student> studentList = new List<Student>();

        public static void loadStudents(string path)
        {
            StreamReader file = new StreamReader(path);
            string line;

            if (File.Exists(path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] split = line.Split(',');

                    string name = split[0];
                    int age = int.Parse(split[1]);
                    float fscMarks = float.Parse(split[2]);
                    float ecatMarks = float.Parse(split[3]);
                    double merit = double.Parse(split[4]);
                    string[] l1 = split[5].Split(';');
                    DegreeProgram regDegree = DegreeProgramDL.getProgram(split[6]);
                    string[] l2 = split[7].Split(';');
                    float fee = float.Parse(split[8]);

                    List<DegreeProgram> pref = new List<DegreeProgram>();
                    List<Subject> reg = new List<Subject>();

                    foreach (var v in l1)
                    {
                        DegreeProgram d = DegreeProgramDL.getProgram(v);
                        pref.Add(d);
                    }

                    foreach(var v in l2)
                    {
                        Subject s = SubjectDL.getSubject(v);
                        reg.Add(s);
                    }

                    Student stu = new Student(name,age,fscMarks,ecatMarks,pref);
                    stu.setFee(fee);
                    stu.setRegDegree(regDegree);
                    stu.setRegSubjects(reg);
                    stu.setMerit(merit);
                    addIntoStudentList(stu);
                }
                file.Close();
            }
        }

        public static void storeStudents(string path)
        {
            StreamWriter f = new StreamWriter(path, false);
            bool flag = false;

            foreach(var v in studentList)
            {
                f.Write(v.getName() + "," + v.getAge() + "," + v.getFscMarks() + "," + v.getEcatMarks() + "," + v.getMerit() + ",");

                foreach( var d in v.getPreferences())
                {
                    if(flag)
                    {
                        f.Write(";");
                    }

                    f.Write(d.getDegreeName());
                    flag = true;
                }

                if(null != v.getRegDegree())
                {
                    f.Write( "," + v.getRegDegree().getDegreeName() + ",");
                }

                else
                {
                    f.Write(",null,");
                }

                flag = false;


                foreach (var s in v.getRegSubjects())
                {
                    if (flag)
                     {
                        f.Write(";");
                     }
                   f.Write(s.getCode());
                   flag = true;
                }
                

                f.WriteLine("," + v.getFee());
            }

            f.Flush();
            f.Close();
        }

        public static void addIntoStudentList(Student s)
        {
            studentList.Add(s);
        }

        public static List<Student> sortStudentsByMerit()
        {
            List<Student> sortedStudentList = new List<Student>();

            foreach (Student s in studentList)
            {
                s.calculateMerit();
            }

            sortedStudentList = studentList.OrderByDescending(o => o.getMerit()).ToList();
            return sortedStudentList;
        }

        public static Student studentPresent(string name)
        {
            foreach (Student s in studentList)
            {
                if (s.getName() == name)
                {
                    return s;
                }
            }

            return null;
        }
    }
}
