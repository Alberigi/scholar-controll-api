using System.ComponentModel.DataAnnotations.Schema;

namespace School.Entity
{
    [Table("school")]
     public class SchoolEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string cnpj { get; set; }
    }
}
