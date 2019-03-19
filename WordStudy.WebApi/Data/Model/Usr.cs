using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WordStudy.Data.Model
{
    [Table("Usr", Schema = "EWSDB")]
    public class Usr : BaseEntity
    {
        [Required]
        [MinLength(2), MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MinLength(2), MaxLength(100)]
        public string SurName { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }
    }
}
