using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperations.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [StringLength(30)]
        public string CourseName { get; set; }

        public Course()
        {
            // initializing collections

            //Students = new HashSet<Student>();
            CourseStudents = new HashSet<Student_Course>();
            Departments = new HashSet<Department>();    
        }
        //public virtual ICollection<Student> Students { get; set; }

        public ICollection<Student_Course> CourseStudents { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
