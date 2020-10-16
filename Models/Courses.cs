using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ar306514_MIS4200.Models
{
    public class Courses
    {
        
        [Key]
        public int courseId { get; set; }
        public int title { get; set; }
        public string description { get; set; }

        // add any other fields as appropriate
        //Product is on the "one" side of a one-to-many relationship with OrderDetail
        //we indicate that with an ICollection
        public ICollection<Enrollments> Enrollments { get; set; }

    }
}