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
        public List<Course> course_offerings;
        public SortingMatrix sorting_matrix;

        // Set initial course offerings to nothing
        public Schedule(int semester_count, int block_count)
        {
            semesters = new List<Semester>();
            for (int semester = 0; semester < semester_count; semester++)
            {
                semesters.Add(new Semester(block_count));
            }

            students = new List<Student>();
            course_offerings = new List<Course>();
            course_count = 0;
        }

        // Add a course to the course offerings
        public void AddCourse(ref Course course)
        {
            course_offerings.Add(course);
            course_count++;
        }

        // Allocate space for the sorting matrix, call after adding all desired classes
        public void CreateSortingMatrix()
        {
            sorting_matrix = new SortingMatrix(course_count);
        }
    }
}
