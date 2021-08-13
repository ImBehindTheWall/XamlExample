namespace Shop.Core.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        public int ID { get; set; }

        public int ClientID { get; set; }

        public int StatusID { get; set; }

        public decimal SaleSum { get; set; }

        public DateTime DAteCreated { get; set; }

        public DateTime DateUpdate { get; set; }

        public virtual Client Client { get; set; }

        public virtual Status Status { get; set; }
    }
}
