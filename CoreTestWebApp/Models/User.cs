using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreTestWebApp.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserId")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}