using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingInCSharp.DataStructures
{
    class Instructor
    {
        public string first_name;
        public string last_name;

        public Instructor(int instructor_id)
        {
            first_name = "INST-" + instructor_id.ToString();
            last_name = "INST-" + instructor_id.ToString();
        }
    }
}
