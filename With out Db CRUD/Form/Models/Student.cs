using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Form.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }
    }

    public class StudentDetail

    {
        public List<Student> StudentsList { get; set; }

        public Student Studentmodel { get; set; }
    }
}
