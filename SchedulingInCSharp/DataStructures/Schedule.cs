using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulingInCSharp.DataStructures;

namespace SchedulingInCSharp
{
    // Class to contain data relevant to the schedule as a whole
    class Schedule
    {
        public int course_count;
        public List<Semester> semesters;
        public List<Student> students;
        public SortedDictionary<int, Course> course_offerings;

        // Set initial course offerings to nothing
        public Schedule(int semester_count, int block_count)
        {
            semesters = new List<Semester>();
            for (int semester = 0; semester < semester_count; semester++)
            {
                semesters.Add(new Semester(block_count));
            }

            students = new List<Student>();
            course_offerings = new SortedDictionary<int, Course>();
            course_count = 0;
        }

        // Add a course to the course offerings
        public void AddCourse(Course course)
        {
            course_offerings.Add(course_count, course);
            course_count++;
        }
    }
}
