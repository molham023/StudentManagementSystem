using System.Collections.Generic;

namespace STUDENTMANGEMENTSYSTEM
{
    class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<double> Greads { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
            Greads = new List<double>();
        }
    }
}
