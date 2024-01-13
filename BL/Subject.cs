using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    class Subject
    {
        private string code;
        private string subjectType;
        private int creditHours;
        private int subjectFee;

        public Subject( string code, int creditHours, string subjectType, int subjectFee)
        {
            this.code = code;
            this.creditHours = creditHours;
            this.subjectType = subjectType;
            this.subjectFee = subjectFee;
        }

        public string getCode()
        {
            return code;
        }

        public string getSubjectType()
        {
            return subjectType;
        }

        public int getCreditHours()
        {
            return creditHours;
        }

        public int getSubjectFee()
        {
            return subjectFee;
        }
    }
}
