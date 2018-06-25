using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SchedulingInCSharp.DataStructures;
using SchedulingInCSharp.Utils;

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

            Console.WriteLine("Writing to the grid now");
            foreach (KeyValuePair<int, Course> pairing in schedule.course_offerings)
            {
                base_form.textBoxSchedule.AppendText("Class: " + pairing.Value.name + "\n");
                base_form.textBoxSchedule.AppendText("  Instructors: \n");
                foreach (Instructor instructor in pairing.Value.instructors)
                {
                    base_form.textBoxSchedule.AppendText("  " + instructor.first_name + "\n");
                }
                base_form.textBoxSchedule.AppendText("Student Requests: \n");
            }

            foreach (Student student in schedule.students)
            {
                base_form.textBoxSchedule.AppendText("Student: " + student.first_name + "\n");
                foreach (Course course in student.course_requests)
                {
                    base_form.textBoxSchedule.AppendText("  " + course.name + "\n");
                }
            }

            // Show the form, blocks
            Application.Run(base_form);
        }
    }
}
