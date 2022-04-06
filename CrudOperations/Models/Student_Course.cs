using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperations.Models
{
    public class Student_Course
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public int? Degree { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
