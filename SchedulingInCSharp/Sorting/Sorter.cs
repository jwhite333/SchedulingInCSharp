using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulingInCSharp.DataStructures;

namespace SchedulingInCSharp.Sorting
{
    // Handles the sorting of data
    class ScheduleSorter
    {
        public Schedule schedule;

        // Take a reference to the schedule so we don't always need to pass it as an arg
        public ScheduleSorter(ref Schedule unsorted_schedule)
        {
            schedule = unsorted_schedule;
        }

        // Sort courses by size
        public void OrderCoursesBySize()
        {
            Console.WriteLine("Ordering courses");
            schedule.course_offerings.Sort();

            // Change IDs to reflect the new order
            AdjustCourseIds();
        }

        // Add students to courses
        public void AddStudents()
        {
            foreach (Student student in schedule.students)
            {
                // Add student to course
                foreach (Course course in student.course_requests)
                {
                    course.students.Add(student);
                }
            }
        }

        // Change course IDs based on size, biggest_course.id = 1, smallest_course.id = n
        public void AdjustCourseIds()
        {
            int new_id = 0;
            foreach (Course course in schedule.course_offerings)
            {
                course.id = new_id++;
            }
        }

        // Add to the sorting matrix all the conflicts from students choices
        public void FindConflicts()
        {
            Console.WriteLine("Size of sorting_matrix: {0}x{1}", schedule.sorting_matrix.elements.Count(), schedule.sorting_matrix.elements[0].Count());
            foreach (Student student in schedule.students)
            {
                // Get conflicts from students
                int course_1_id, course_2_id;
                for (int course_1 = 0; course_1 < student.course_requests.Count(); course_1++)
                {
                    for (int course_2 = course_1 + 1; course_2 < student.course_requests.Count(); course_2++)
                    {
                        course_1_id = student.course_requests[course_1].id;
                        course_2_id = student.course_requests[course_2].id;
                        try
                        {
                            schedule.sorting_matrix.elements[course_1_id][course_2_id].students.Add(student);
                        }
                        catch(System.ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("[ERROR] Index was out of range, course_1_id: {0}, course_2_id: {1}", course_1_id, course_2_id);
                            return;
                        }
                    }
                }
            }
        }
    }
}
