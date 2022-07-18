using System.ComponentModel.DataAnnotations;

namespace react
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Student")]
    public class Student_Entity
    {
      
        
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Mobile { get; set; }
        
    }
}
