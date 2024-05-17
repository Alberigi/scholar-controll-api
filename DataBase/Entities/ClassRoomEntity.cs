using School.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRoom.Entity
{
    [Table("class_room")]
     public class ClassRoomEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? id { get; set; }

        [Column("school_id")]
        [ForeignKey("School")]
        public Guid schoolId { get; set; }

        public SchoolEntity? School { get; set; }

        public string name { get; set; }

        public string shift { get; set; }
        
        public int grade { get; set; }

        [Column("academic_year")]
        public int academicYear { get; set; }

        [Column("student_limit")]
        public int studentLimit { get; set; }
    }
}
