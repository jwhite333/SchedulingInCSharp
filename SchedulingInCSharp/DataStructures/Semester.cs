using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingInCSharp.DataStructures
{
    // Class to contain one semester worth of classes
    class Semester
    {
        public List<Block> blocks;

        public Semester(int block_count)
        {
            blocks = new List<Block>();
            for (int block = 0; block < block_count; block++)
            {
                blocks.Add(new Block());
            }
        }
    }
}
