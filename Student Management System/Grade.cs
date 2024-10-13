using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    class Grade : IDisplayable
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public double Score { get; set; }

        public Grade(Student student, Course course, double score)
        {
            Student = student;
            Course = course;
            Score = score;
        }

        public string GetLetterGrade()
        {
            if (Score >= 80) return "A";
            else if (Score >= 70) return "B";
            else if (Score >= 60) return "C";
            else if (Score >= 50) return "D";
            else return "F";
        }

        public void Display()
        {
            Console.WriteLine($"วิชา: {Course.Name}, คะแนน: {Score}, เกรด: {GetLetterGrade()}");
        }
    }
}
