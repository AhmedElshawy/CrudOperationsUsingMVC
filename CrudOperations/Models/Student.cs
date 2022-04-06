using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperations.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(30,MinimumLength =3)]
        public string StudentName { get; set; }
        [Required]
        public byte Age { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public virtual Department Department { get; set; } // navigation prperty

        public Student()
        {
            // initializing collections
            //Courses = new HashSet<Course>();
            StudentCourses = new HashSet<Student_Course>();
        }
        //public virtual ICollection<Course> Courses { get; set; }

        public ICollection<Student_Course> StudentCourses { get; set; }
    }
}
