using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ar306514_MIS4200.Models
{
    public class Enrollments
    {
        [Key]
        public int enrollmentId { get; set; }
        public string studentId { get; set; }
        public DateTime classId { get; set; }
        // add any other fields as appropriate
        //Order is on the "one" side of a one-to-many relationship with OrderDetail
        //and we indicate that with an ICollection
        //public ICollection<OrderDetail> OrderDetail { get; set; }
        //Order is on the Many side of the one-to-many relation between Customer
        //and Order and we represent that relationship like this
        public int studentID { get; set; }
        public virtual Students Students { get; set; }

        public int courseId { get; set; }
        public virtual Courses Courses { get; set; }

    }
}