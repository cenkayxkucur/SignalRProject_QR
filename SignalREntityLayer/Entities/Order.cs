﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.EntityLayer.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderTableNumber { get; set; }
        public string OrderDescription { get; set; }
       

        [Column(TypeName = "Date")]
        public DateTime OrderDateOnly { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } 

        

    }
}
