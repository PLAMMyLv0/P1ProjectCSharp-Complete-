using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    class StudentManagementSystem
    {
        private List<Student> students;
        private List<Course> courses;
        private List<Grade> grades;

        public StudentManagementSystem()
        {
            students = new List<Student>();
            courses = new List<Course>();
            grades = new List<Grade>();
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            // เพิ่มข้อมูลตัวอย่าง
            courses.Add(new Course("วิทยาการคอมพิวเตอร์", 3, "อ.ธีรเดช"));
            courses.Add(new Course("คณิตศาสตร์", 3, "อ.สมศรี"));
            courses.Add(new Course("อังกฤษ", 3, "อ.สมหมาย"));
            courses.Add(new Course("จีน", 3, "อ.สมทรง"));
            courses.Add(new Course("ไทย", 3, "อ.สมศรี"));
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============== ระบบบริหารงานนักศึกษา ===============");
                Console.WriteLine("1. เข้าสู่ระบบเป็นนักศึกษา");
                Console.WriteLine("2. เข้าสู่ระบบเป็นอาจารย์");
                Console.WriteLine("3. บันทึกข้อมูลลงไฟล์");
                Console.WriteLine("4. โหลดข้อมูลจากไฟล์");
                Console.WriteLine("5. ออกจากระบบ");
                Console.Write("เลือกตัวเลือก: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        StudentMenu();
                        break;
                    case "2":
                        TeacherMenu();
                        break;
                    case "3":
                        SaveDataToFile();
                        break;
                    case "4":
                        LoadDataFromFile();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("ตัวเลือกไม่ถูกต้อง กรุณาลองใหม่");
                        Console.ReadKey();
                        break;
                }
            }
        }


        private void StudentMenu()
        {
            Console.Write("\nกรุณาป้อนชื่อ: ");
            string name = Console.ReadLine();
            Console.Write("กรุณาป้อนรหัสนักศึกษา: ");
            string studentId = Console.ReadLine();

            Student student = students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                student = new Student(name, studentId);
                students.Add(student);
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=============== ยินดีต้อนรับ {student.Name} ===============");
                Console.WriteLine("1. ลงทะเบียนเรียน");
                Console.WriteLine("2. ดูผลการเรียน");
                Console.WriteLine("3. ออกจากระบบ");
                Console.WriteLine("==========================================================");
                Console.Write("เลือกตัวเลือก: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RegisterCourse(student);
                        break;
                    case "2":
                        ViewGrades(student);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("\n[ตัวเลือกไม่ถูกต้อง กรุณาลองใหม่]");
                        Console.ReadKey();
                        break;
                }
            }
        }


        private void RegisterCourse(Student student)
        {
            Console.Clear();
            Console.WriteLine("=============== รายชื่อวิชาที่เปิดสอน ===============");
            for (int i = 0; i < courses.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {courses[i].Name} ");
            }
            Console.WriteLine("======================================================");

            Console.Write("เลือกหมายเลขวิชาที่ต้องการลงทะเบียน: ");
            if (int.TryParse(Console.ReadLine(), out int courseIndex) && courseIndex > 0 && courseIndex <= courses.Count)
            {
                Course selectedCourse = courses[courseIndex - 1];
                student.RegisterCourse(selectedCourse);
                Console.WriteLine($"\n[ลงทะเบียนวิชา {selectedCourse.Name} สำเร็จ!]");
            }
            else
            {
                Console.WriteLine("\n[หมายเลขวิชาไม่ถูกต้อง]");
            }
            Console.WriteLine("กดปุ่มใดๆ เพื่อดำเนินการต่อ...");
            Console.ReadKey();
        }


        private void ViewGrades(Student student)
        {
            Console.Clear();
            Console.WriteLine($"=============== ผลการเรียนของ {student.Name} ===============");

            bool hasGrades = false;
            foreach (var grade in grades)
            {
                if (grade.Student.StudentId == student.StudentId)
                {
                    grade.Display();
                    hasGrades = true;
                }
            }

            if (!hasGrades)
            {
                Console.WriteLine("[ยังไม่มีผลการเรียน]");
            }

            Console.WriteLine("========================================================");
            Console.WriteLine("กดปุ่มใดๆ เพื่อดำเนินการต่อ...");
            Console.ReadKey();
        }


        private void TeacherMenu()
        {
            Console.Write("\nกรุณาป้อนรหัสผ่านอาจารย์: ");
            string password = Console.ReadLine();

            if (password != "99")
            {
                Console.WriteLine("\n[รหัสผ่านไม่ถูกต้อง]");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============== เมนูอาจารย์ ===============");
                Console.WriteLine("1. บันทึกเกรด");
                Console.WriteLine("2. ออกจากระบบ");
                Console.WriteLine("===========================================");
                Console.Write("เลือกตัวเลือก: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RecordGrade();
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("\n[ตัวเลือกไม่ถูกต้อง กรุณาลองใหม่]");
                        Console.ReadKey();
                        break;
                }
            }
        }


        private void RecordGrade()
        {
            Console.Write("\nป้อนรหัสนักศึกษา: ");
            string studentId = Console.ReadLine();
            Student student = students.FirstOrDefault(s => s.StudentId == studentId);

            if (student == null)
            {
                Console.WriteLine("\n[ไม่พบข้อมูลนักศึกษา]");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=============== บันทึกเกรดสำหรับ {student.Name} ===============");
                Console.WriteLine("รายวิชาที่นักศึกษาลงทะเบียน:");

                // แสดงรายการวิชาทั้งหมดที่นักศึกษาลงทะเบียน
                for (int i = 0; i < student.RegisteredCourses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {student.RegisteredCourses[i].Name}");
                }
                Console.WriteLine("===========================================================");
                Console.WriteLine("หรือพิมพ์ '0' เพื่อออกจากการบันทึกเกรด");
                Console.Write("เลือกหมายเลขวิชาที่ต้องการบันทึกเกรด: ");

                // รับอินพุตหมายเลขวิชา
                if (int.TryParse(Console.ReadLine(), out int courseIndex))
                {
                    if (courseIndex == 0) return; // ออกจากฟังก์ชันหากเลือก '0'
                    if (courseIndex > 0 && courseIndex <= student.RegisteredCourses.Count)
                    {
                        Course selectedCourse = student.RegisteredCourses[courseIndex - 1];

                        // รับคะแนนและตรวจสอบความถูกต้อง
                        Console.Write($"ป้อนคะแนนสำหรับ {selectedCourse.Name} (0-100): ");
                        if (double.TryParse(Console.ReadLine(), out double score) && score >= 0 && score <= 100)
                        {
                            Grade grade = new Grade(student, selectedCourse, score);
                            grades.Add(grade);
                            Console.WriteLine("\n[บันทึกเกรดสำเร็จ]");
                        }
                        else
                        {
                            Console.WriteLine("\n[คะแนนไม่ถูกต้อง กรุณาลองใหม่]");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n[หมายเลขวิชาไม่ถูกต้อง กรุณาลองใหม่]");
                    }
                }
                else
                {
                    Console.WriteLine("\n[กรุณาใส่ตัวเลขที่ถูกต้อง]");
                }

                Console.WriteLine("\nกดปุ่มใดๆ เพื่อดำเนินการต่อ...");
                Console.ReadKey();
            }
        }



        // ตัวอย่างการใช้ array 1 มิติและ 2 มิติ
        private void DisplayStatistics()
        {
            string[] courseNames = courses.Select(c => c.Name).ToArray(); // array 1 มิติ
            double[,] gradeMatrix = new double[students.Count, courses.Count]; // array 2 มิติ

            for (int i = 0; i < students.Count; i++)
            {
                for (int j = 0; j < courses.Count; j++)
                {
                    var grade = grades.FirstOrDefault(g => g.Student == students[i] && g.Course == courses[j]);
                    gradeMatrix[i, j] = grade?.Score ?? 0;
                }
            }

            // แสดงสถิติ (ตัวอย่างการใช้ array)
        }

        // ตัวอย่างการใช้ text file
        private void SaveDataToFile()
        {
            using (StreamWriter writer = new StreamWriter("student_data.txt", append: true))
            {
                // บันทึกนักศึกษาและวิชาที่ลงทะเบียน
                foreach (var student in students)
                {
                    writer.WriteLine($"STUDENT|{student.Name}|{student.StudentId}");

                    foreach (var course in student.RegisteredCourses)
                    {
                        writer.WriteLine($"COURSE|{course.Name}");
                    }
                }

                // บันทึกเกรด
                foreach (var grade in grades)
                {
                    writer.WriteLine($"GRADE|{grade.Student.StudentId}|{grade.Course.Name}|{grade.Score}");
                }
            }
            Console.WriteLine("[บันทึกข้อมูลสำเร็จ]");
            Console.ReadKey();
        }

        private void LoadDataFromFile()
        {
            if (!File.Exists("student_data.txt"))
            {
                Console.WriteLine("[ไม่พบไฟล์ข้อมูล]");
                Console.ReadKey();
                return;
            }

            using (StreamReader reader = new StreamReader("student_data.txt"))
            {
                string line;
                Student currentStudent = null;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts[0] == "STUDENT")
                    {
                        if (!students.Any(s => s.StudentId == parts[2])) // ตรวจสอบไม่ให้ซ้ำ
                        {
                            currentStudent = new Student(parts[1], parts[2]);
                            students.Add(currentStudent);
                        }
                    }
                    else if (parts[0] == "COURSE" && currentStudent != null)
                    {
                        Course course = courses.FirstOrDefault(c => c.Name == parts[1]);
                        if (course != null && !currentStudent.RegisteredCourses.Contains(course))
                        {
                            currentStudent.RegisterCourse(course);
                        }
                    }
                    else if (parts[0] == "GRADE")
                    {
                        Student student = students.FirstOrDefault(s => s.StudentId == parts[1]);
                        Course course = courses.FirstOrDefault(c => c.Name == parts[2]);
                        if (student != null && course != null && double.TryParse(parts[3], out double score))
                        {
                            if (!grades.Any(g => g.Student == student && g.Course == course))
                            {
                                grades.Add(new Grade(student, course, score));
                            }
                        }
                    }
                }
            }

            Console.WriteLine("[โหลดข้อมูลสำเร็จ]");
            Console.ReadKey();
        }
    }
}