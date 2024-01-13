using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.DL
{
    class DegreeProgramDL
    {
        static public List<DegreeProgram> programList = new List<DegreeProgram>();

        public static void addInDegreeList(DegreeProgram d)
        {
            programList.Add(d);
        }

        public static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach (Student s in sortedStudentList)
            {
                foreach (DegreeProgram d in s.getPreferences())
                {
                    if (d.getSeats() > 0 && s.getRegDegree() == null)
                    {
                        s.setRegDegree(d);
                        d.setSeats(d.getSeats() - 1);
                        break;
                    }
                }
            }
        }

        //________________________________________________Loading Degree Programs from File
        public static void loadDegreePrograms(string path)
        {
            StreamReader file = new StreamReader(path);
            string line;

            if (File.Exists(path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] split = line.Split(',');

                    string name = split[0];
                    string duration = split[1];
                    int seats = int.Parse(split[2]);
                    string subjects = split[3];
                    List<Subject> inDegree = new List<Subject>();

                    string[] all = subjects.Split(';');

                    foreach( var v in all)
                    {
                        Subject s = SubjectDL.getSubject(v);
                        inDegree.Add(s);
                    }

                    DegreeProgram d = new DegreeProgram(name,duration,seats);
                    d.setSubjects(inDegree);
                    addInDegreeList(d);
                }
                file.Close();
            }
        }

        //_____________________________________________Storing Degree Programs in File
        public static void storeDegreePrograms(string path)
        {
            StreamWriter file = new StreamWriter(path, false);
            bool flag = false;

            foreach (var v in programList)
            {
                file.Write(v.getDegreeName() + "," + v.getDegreeDuration() + "," + v.getSeats() + ",");

                foreach(var c in v.getSubjects())
                {
                    if (flag)
                    {
                        file.Write(";");
                    }

                    file.Write(c.getCode());
                    flag = true;

                }

                file.WriteLine();
            }

            file.Flush();
            file.Close();
        }

        public static DegreeProgram getProgram(string d)
        {
            foreach(var v in programList)
            {
                if(d == v.getDegreeName())
                {
                    return v;
                }
            }

            return null;
        }
    }
}
