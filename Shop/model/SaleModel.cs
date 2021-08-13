using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.model
{
	class SaleModel
	{
        public int ID { get; set; }

        public int ClientID { get; set; }

        public int StatusID { get; set; }

        public decimal SaleSum { get; set; }

        public DateTime DAteCreated { get; set; }

        public DateTime DateUpdate { get; set; }
        public SaleModel saleModel (SaleModel saleModel)
        {
            ID = saleModel.ID;
            ClientID = saleModel.ClientID;
            StatusID = saleModel.StatusID;
            SaleSum = saleModel.SaleSum;
            DAteCreated = saleModel.DAteCreated;
            DateUpdate = saleModel.DateUpdate;
            return saleModel;
        }
    }
}
