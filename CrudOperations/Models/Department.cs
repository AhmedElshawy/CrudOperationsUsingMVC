using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperations.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string DeptName { get; set; }

        public Department()
        {
            // initializing collections
            DeptStudents = new HashSet<Student>();
            DeptCourses =new HashSet<Course>();
        }
        public virtual ICollection<Student> DeptStudents { get; set; }
        
        public virtual ICollection<Course> DeptCourses { get; set; }
    }
}
