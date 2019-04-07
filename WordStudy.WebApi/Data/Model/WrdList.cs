using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WordStudy.Data.Model
{
    [Table("WrdList", Schema = "EWSDB")]
    public class WrdList
    {
        public int ID{ get; set; }
        public string ListName { get; set; }

        public Usr Usr { get; set; }
    }
}
