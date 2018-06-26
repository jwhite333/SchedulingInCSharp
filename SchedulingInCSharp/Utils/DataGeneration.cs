using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulingInCSharp.DataStructures;

namespace SchedulingInCSharp.Utils
{
    class DataGeneration
    {
        int blocks;
        int total_students;
        int courses_requests_allowed;
        int total_instructors;
        int courses_per_instructor;
        int semesters;
        int total_courses;

        // Set some initial data for generating requests
        public DataGeneration()
        {
            blocks = 4;
            total_students = 20;
            courses_requests_allowed = 4;
            total_instructors = 25;
            courses_per_instructor = 3;
            semesters = 2;
            total_courses = 8; // courses_per_instructor * total_instructors;
        }

        // Create a fake dataset of student course requests
        public Schedule GenerateDataset()
        {
            Schedule schedule = new Schedule(semesters, blocks);

            // Generate courses and add them to the schedule
            Console.WriteLine("Adding courses");
            for (int course_id = 0; course_id < total_courses; course_id++)
            {
                Course new_course = new Course(course_id);
                schedule.AddCourse(ref new_course);
            }

            // Generate instructors
            Console.WriteLine("Adding instructors");
            Random generator = new Random();
            for (int instructor_id = 0; instructor_id < total_instructors; instructor_id++)
            {
                Instructor new_instructor = new Instructor(instructor_id);

                // Add instructor to the right amount of courses, ensuring 1 per course
                /* for (int course_num = 0; course_num < courses_per_instructor; course_num++)
                {
                    int offset = (courses_per_instructor * instructor_id) + course_num;
                    schedule.course_offerings[offset].instructors.Add(new_instructor);
                }*/
            }

            // Create student requests
            Console.WriteLine("Adding student requests");
            for (int student_id = 0; student_id < total_students; student_id++)
            {
                Student new_student = new Student(student_id);

                // Add requests
                for (int request = 0; request < courses_requests_allowed; request++)
                {
                    int random_course = generator.Next(total_courses);
                    new_student.course_requests.Add(schedule.course_offerings[random_course]);
                }

                schedule.students.Add(new_student);
            }

            // Return dataset
            Console.WriteLine("Returning schedule");
            return schedule;
        }
    }
}
