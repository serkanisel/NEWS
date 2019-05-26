using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WordStudy.Data.Model;

namespace WordStudy.Data.Model
{
    [Table("Sentences", Schema = "EWSDB")]
    public class Sentence : BaseEntity
    {
        public string Body { get; set; }
        public string Mean { get; set; }
    }
}
