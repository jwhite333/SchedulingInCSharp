using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchedulingInCSharp.DataStructures;
using SchedulingInCSharp.Utils;
using SchedulingInCSharp.Sorting;

namespace SchedulingInCSharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Starting");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 base_form = new Form1();

            // Start of the fun stuff
            DataGeneration data_gen = new DataGeneration();
            Schedule schedule = data_gen.GenerateDataset();

            // Get ready to sort!
            schedule.CreateSortingMatrix();
            ScheduleSorter schedule_sorter = new ScheduleSorter(ref schedule);

            // Add students to requested classes
            schedule_sorter.AddStudents();

            // Print some things
            Console.WriteLine("Writing to the grid now");
            base_form.textBoxSchedule.AppendText("Unsorted classes\n");
            print_courses(ref base_form, ref schedule);

            // Order courses
            schedule_sorter.OrderCoursesBySize();
            base_form.textBoxSchedule.AppendText("Sorted classes\n");
            print_courses(ref base_form, ref schedule);

            // Create sorting matrix
            schedule_sorter.FindConflicts();

            // Show the form, blocks
            Application.Run(base_form);
        }

        // Print out the info about courses in the textbox
        static void print_courses(ref Form1 base_form, ref Schedule schedule)
        {
            foreach (Course course in schedule.course_offerings)
            {
                base_form.textBoxSchedule.AppendText("Class: " + course.name + "\n");
                base_form.textBoxSchedule.AppendText("  ID: " + course.id.ToString() + "\n");
                base_form.textBoxSchedule.AppendText("  Instructors: \n");
                foreach (Instructor instructor in course.instructors)
                {
                    base_form.textBoxSchedule.AppendText("  " + instructor.first_name + "\n");
                }
                base_form.textBoxSchedule.AppendText("  Size: " + course.students.Count().ToString() + "\n");
            }
        }

        // Print out the info about the sorting_matrix in the textbox
        static void print_sorting_matrix(ref Form1 base_form, ref Schedule schedule)
        {
            for (int row = 0; row < schedule.sorting_matrix.elements.Count(); row++)
            {
                for (int column = 0; column < schedule.sorting_matrix.elements[row].Count(); column++)
                {
                    base_form.textBoxSchedule.AppendText(" " + schedule.sorting_matrix.elements[row][column].students.Count());
                }
                base_form.textBoxSchedule.AppendText("\n");
            }
        }
    }
}
