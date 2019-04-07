using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordStudy.Data.Model
{
    [Table("Photos", Schema = "EWSDB")]
    public class Photo: BaseEntity
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        
        public Usr Usr { get; set; }
    }
}