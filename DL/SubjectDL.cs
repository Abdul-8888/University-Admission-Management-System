using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.DL
{
    class SubjectDL
    {
        public static List<Subject> allSubjects = new List<Subject>();

        //_______________________________________________Adding new Subjects in List
        public static void addSubjectInList(Subject s)
        {
            allSubjects.Add(s);
        }

        //________________________________________________Loading Subjects from File
        public static void loadSubjects(string path)
        {
            StreamReader file = new StreamReader(path);
            string line;

            if(File.Exists(path))
            {
                while( (line = file.ReadLine()) != null )
                {
                    string[] split = line.Split(',');

                    string code = split[0];
                    string subjectType = split[1];
                    int creditHours = int.Parse(split[2]);
                    int subjectFee = int.Parse(split[3]);

                    Subject s = new Subject(code,creditHours , subjectType, subjectFee);
                    addSubjectInList(s);
                }
                file.Close();
            }
        }

        //_____________________________________________Storing Subjects in File
        public static void storeSubjects(string path)
        {
            StreamWriter file = new StreamWriter(path,false);

            foreach(var v in allSubjects)
            {
                file.WriteLine(v.getCode() + "," + v.getSubjectType() + "," + v.getCreditHours() + "," + v.getSubjectFee());
            }

            file.Flush();
            file.Close();
        }

        public static Subject getSubject(string code)
        {
            foreach(var v in allSubjects)
            {
                if(code == v.getCode())
                {
                    return v;
                }
            }

            return null;
        }

    }
}
