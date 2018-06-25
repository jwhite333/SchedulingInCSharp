using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingInCSharp.DataStructures
{
    class Student
    {
        public string first_name;
        public string last_name;
        public List<Course> course_requests;
        public List<Course> course_assignments;

        public Student(int student_id)
        {
            course_requests = new List<Course>();
            course_assignments = new List<Course>();
            first_name = "STU-" + student_id.ToString();
            last_name = "STU-" + student_id.ToString();
        }
    }
}
