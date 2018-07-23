using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CoreTestWebApp.Models
{
    [Table("Customer")]
    public class Customer
    {
        private DbContext dbContext;

        public Customer(DbContext context)
        {
            dbContext = context;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CustomerId")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Number { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public virtual User CreatedByUser { get; set; }

        public IDictionary<string, object> Properties => dbContext.Entry(this).Properties
            .Where(e => e.Metadata.IsShadowProperty)
            .ToDictionary(k => k.Metadata.Name, v => v.CurrentValue);

        //public object LinqProperties => _shadowProperties.ToDictionary(k => k, v => EF.Property<object>(this, v));
    }
}