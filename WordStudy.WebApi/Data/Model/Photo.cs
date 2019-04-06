using System;

namespace WordStudy.Data.Model
{
    public class Photo: BaseEntity
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public int IsMain { get; set; }
    }
}