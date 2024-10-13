using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    class Course : IDisplayable
    {
        public string Name { get; set; }
        public int Credits { get; set; }
        public string Instructor { get; set; }

        public Course(string name, int credits, string instructor)
        {
            Name = name;
            Credits = credits;
            Instructor = instructor;
        }

        public void Display()
        {
            Console.WriteLine($"วิชา: {Name}, หน่วยกิต: {Credits}, อาจารย์ผู้สอน: {Instructor}");
        }
    }
}
