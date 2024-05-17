using ClassRoom.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.Entity
{
    [Table("student")]
     public class StudentEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? id { get; set; }

        [Column("class_room_id")]
        [ForeignKey("ClassRoom")]
        public Guid classRoomId { get; set; }

        public ClassRoomEntity? ClassRoom { get; set; }

        public string name { get; set; }

        public string phone { get; set; }
        
        public string guardian { get; set; }

        public string address { get; set; }

        public DateTime date { get; set; }
    }
}
