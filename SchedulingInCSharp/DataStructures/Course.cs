using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulingInCSharp;
using SchedulingInCSharp.DataStructures;

namespace SchedulingInCSharp
{
    class Course : IComparable<Course>
    {
        public string name;
        public List<Instructor> instructors;
        public List<Student> students;
        public int id;
        public Block preassigned_block;         // Force class to happen at a certain time
        public Semester preassigned_semester;   // Force class to happen during a specific semester
        public List<Block> restricted_block;    // Force class to happen in a different block
        public bool elective;                   // Happens every other day

        public Course(int course_id)
        {
            instructors = new List<Instructor>();
            students = new List<Student>();
            preassigned_block = null;
            preassigned_semester = null;
            restricted_block = new List<Block>();
            name = "CRSE-" + course_id.ToString();
            id = course_id;

            // Give a 20% chance to be an elective
            Random generator = new Random();
            int random_value = generator.Next(100);
            elective = (random_value < 20) ? true : false;
        }

        // Allow for sorting of courses by size (Largest first)
        public int CompareTo(Course other)
        {
            if (this.students.Count() == other.students.Count())
                return 0;
            else if (this.students.Count() < other.students.Count())
                return 1;
            else
                return -1;
        }
    }
}
