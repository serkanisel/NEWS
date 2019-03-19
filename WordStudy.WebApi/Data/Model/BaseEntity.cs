using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WordStudy.Data.Model
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            IsDeleted = false;
        }

        [Key]
        [Column("Id", TypeName = "Serial")]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
