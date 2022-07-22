using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction.Domain.Models
{
    public class Auction
    {
        [Key]
        public int AuctionId { get; set; }
        public int ProductId { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public int Price { get; set; }
        public bool ShippingStatus { get; set; }
        public bool ReceiveStatus { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;

        #region Relatons
        [ForeignKey(nameof(BuyerId))]
        public User Buyer { get; set; }
        [ForeignKey(nameof(SellerId))]
        public User Seller { get; set; }

        public Product Product { get; set; }
        #endregion

    }
}