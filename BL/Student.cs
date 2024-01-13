using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    class Student
    {
        private string name;
        private int age;
        private float fscMarks;
        private float ecatMarks;
        private double merit;
        private List<DegreeProgram> preferences = new List<DegreeProgram>();
        private DegreeProgram regDegree = null;
        private List<Subject> regSubjects;
        private float fee = 0.0F;

        public Student(string name, int age, float fscMarks, float ecatMarks, List<DegreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
            regSubjects = new List<Subject>();
        }

        public string getName()
        {
            return name;
        }

        public int getAge()
        {
            return age;
        }

        public float getFscMarks()
        {
            return fscMarks;
        }

        public float getEcatMarks()
        {
            return ecatMarks;
        }

        public double getMerit()
        {
            return merit;
        }

        public void setMerit(double merit)
        {
            this.merit = merit;
        }

        public DegreeProgram getRegDegree()
        {
            return regDegree;
        }

        public void setRegDegree(DegreeProgram d)
        {
            regDegree = d;
        }

        public List<DegreeProgram> getPreferences()
        {
            return preferences;
        }

        public List<Subject> getRegSubjects()
        {
            return regSubjects;
        }

        public void setRegSubjects(List<Subject> s)
        {
            this.regSubjects = s;
        }

        public float getFee()
        {
            return fee;
        }

        public void setFee(float fee)
        {
            this.fee = fee;
        }

        public void calculateMerit()
        {
            merit = (((fscMarks / 1100) * 0.45F) + ((ecatMarks / 400) * 0.55F));
        }

        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();

            if (regDegree != null && regDegree.isSubjectExist(s) && stCH + s.getCreditHours() <= 9)
            {
                regSubjects.Add(s);
                return true;
            }

            else
            {
                return false;
            }

        }

        public int getCreditHours()
        {
            int count = 0;

            foreach (Subject s in regSubjects)
            {
                count = count + s.getCreditHours();
            }

            return count;
        }

        public float calculateFee()
        {
            float fee = 0;

            if (regDegree != null)
            {
                foreach (Subject s in regSubjects)
                {
                    fee = fee + s.getSubjectFee();
                }
            }

            return fee;
        }

    }    
}