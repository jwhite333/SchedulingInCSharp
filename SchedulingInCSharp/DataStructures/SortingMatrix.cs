using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingInCSharp.DataStructures
{
    class SortingMatrixElement
    {
        public int size;
        private List<Student> students;

        public SortingMatrixElement()
        {
            students = new List<Student>();
            size = 0;
        }

        // Make sure size always changes with student count
        public void AddStudent(Student student)
        {
            students.Add(student);
            size = students.Count();
        }
    }

    class SortingMatrix
    {
        public List<List<SortingMatrixElement>> elements;

        public SortingMatrix(int size)
        {
            elements = new List<List<SortingMatrixElement>>();
            for (int row = 0; row < size; row++)
            {
                elements.Add(new List<SortingMatrixElement>());
                for (int column = 0; column < size; column++)
                {
                    elements[row].Add(new SortingMatrixElement());
                }
            }
        }
    }
}
