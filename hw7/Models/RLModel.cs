namespace hw7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RLModel")]
    public partial class RLModel
    {
        public int ID { get; set; }

        public DateTime? TimeNow { get; set; }

        [Required]
        public string Request { get; set; }

        [Required]
        public string IP { get; set; }

        [Required]
        public string BrowserType { get; set; }
    }
}
