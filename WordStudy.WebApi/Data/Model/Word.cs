using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WordStudy.Data.Model
{
    [Table("Word", Schema = "EWSDB")]
    public class Word : BaseEntity
    {
        [Required]
        [MinLength(2), MaxLength(1024)]
        public string Body { get; set; }

        [Required]
        [MinLength(2), MaxLength(1024)]
        public string Mean { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int AddType { get; set; }

        public ICollection<WordOfList> WordOfLists { get; set; }

        [NotMapped]
        public string BodyMean
        {
            get { return Body + " & " + Mean; }
        }
    }
}
