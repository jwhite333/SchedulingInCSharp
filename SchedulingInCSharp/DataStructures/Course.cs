using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulingInCSharp;
using SchedulingInCSharp.DataStructures;

namespace SchedulingInCSharp
{
    class Course
    {
        public string name;
        public List<Instructor> instructors;
        public List<Student> students;
        public int id;
        public Block preassigned_block;         // Force class to happen at a certain time
        public Semester preassigned_semester;   // Force class to happen during a specific semester
        public bool elective;                   // Happens every other day

        public Course(int course_id)
        {
            instructors = new List<Instructor>();
            students = new List<Student>();
            preassigned_block = null;
            preassigned_semester = null;
            name = "CRSE-" + course_id.ToString();
            id = course_id;

            // Give a 20% chance to be an elective
            Random generator = new Random();
            int random_value = generator.Next(100);
            if (random_value < 20)
                elective = true;
            else
                elective = false;
        }
    }
}
