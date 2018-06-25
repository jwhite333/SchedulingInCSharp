using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingInCSharp
{
    class Block
    {
        public string title;
        public int id;
        public DateTime start;
        public DateTime end;
        public bool elective_block; // Allows electives to be in this block
        public List<Course> courses;

        public Block()
        {
            courses = new List<Course>();
        }
    }
}
