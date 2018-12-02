namespace StringReverseService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("svc.StringReverse")]
    public partial class StringReverse
    {
        public int ID { get; set; }

        public string TextValue { get; set; }

        public bool? IsReversed { get; set; }
    }
}
