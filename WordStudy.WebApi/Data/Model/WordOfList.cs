using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WordStudy.Data.Model
{
    [Table("WordOfList", Schema = "EWSDB")]
    public class WordOfList : BaseEntity
    {
        public Word Word { get; set; }

        public WrdList WrdList { get; set; }

    }
}
