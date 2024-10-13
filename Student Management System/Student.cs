using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    class Student : IDisplayable
    {
        public string Name { get; set; }
        public string StudentId { get; set; }
        public List<Course> RegisteredCourses { get; set; }

        public Student(string name, string studentId)
        {
            Name = name;
            StudentId = studentId;
            RegisteredCourses = new List<Course>();
        }

        public void RegisterCourse(Course course)
        {
            RegisteredCourses.Add(course);
        }

        public void Display()
        {
            Console.WriteLine($"ชื่อ: {Name}, รหัสนักศึกษา: {StudentId}");
            Console.WriteLine("วิชาที่ลงทะเบียน:");
            foreach (var course in RegisteredCourses)
            {
                Console.WriteLine($"- {course.Name}");
            }
        }
    }
}
