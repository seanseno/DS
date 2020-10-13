using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public DateTime InsertTime { get; set; }
        public int LedgerId { get; set; }
        public int IsSenior { get; set; }
        public int IsPwd { get; set; }
        public decimal Discounted { get; set; }
        public string Remarks { get; set; }
        public DateTime UpdateTime { get; set; }
    }

    public class SalesProfit
    {
        public string Fullname { get; set; }
        public string PrincipalName { get; set; }
        public string CategoryName { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int SoldQuantity { get; set; }
        public decimal SupplierPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal TotalSales { get; set; }
        public decimal Profit { get; set; }
        public DateTime InsertTime { get; set; }
    }

    public class ReportTotalSales
    {
        public string Fullname { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? TotalQty { get; set; }
    }
   
}
