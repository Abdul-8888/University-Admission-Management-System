using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    class DegreeProgram
    {
        private string degreeName;
        private string degreeDuration;
        private List<Subject> subjects;
        private int seats;
        
        public DegreeProgram(string degreeName, string degreeDuration, int seats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.seats = seats;
            subjects = new List<Subject>();
        }

        public string getDegreeName()
        {
            return degreeName;
        }

        public string getDegreeDuration()
        {
            return degreeDuration;
        }

        public int getSeats()
        {
            return seats;
        }

        public void setSeats(int seats)
        {
            this.seats = seats;
        }

        public List<Subject> getSubjects()
        {
            return subjects;
        }

        public void setSubjects(List<Subject> s)
        {
            subjects = s;
        }

        public int calculateCreditHours()
        {
            int count = 0;

            for(int i = 0; i < subjects.Count; i++ )
            {
                count = count + subjects[i].getCreditHours();
            }

            return count;
        }

        public bool addSubject( Subject s )
        {
            int creditHours = calculateCreditHours();

            if( creditHours + s.getCreditHours() <= 20 )
            {
                subjects.Add(s);
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool isSubjectExist( Subject sub )
        {
            foreach( Subject s in subjects )
            {
                if( s.getCode() == sub.getCode() )
                {
                    return true;
                }
            }

            return false;
        }
    }
}
