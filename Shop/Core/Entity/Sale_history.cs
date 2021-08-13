namespace Shop.Core.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sale_history
    {
        public int ID { get; set; }

        public int SaleID { get; set; }

        public int StatusID { get; set; }

        public decimal SaleSum { get; set; }

        public DateTime ActiveFrom { get; set; }

        public DateTime ActiveTo { get; set; }

        public virtual Status Status { get; set; }
    }
}
