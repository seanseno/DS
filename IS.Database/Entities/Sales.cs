using System;
using System.Collections.Generic;
using System.Text;

namespace IS.Database.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public int CashierId { get; set; }
        public int ItemId { get; set; }
        public string CustumerName { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public string AmountString { get { return String.Format("{0:n}", Amount); } }
        public DateTime InsertTime { get; set; } 

        public string CashierName { get; set; }
        public string ProductName { get; set; }
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
}
