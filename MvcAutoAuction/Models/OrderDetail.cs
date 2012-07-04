namespace MvcAutoAuction.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int CarId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public virtual Car Car { get; set; }
        public virtual Order Order { get; set; }
    }
}
