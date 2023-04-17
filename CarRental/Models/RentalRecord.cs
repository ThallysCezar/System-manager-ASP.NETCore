﻿using CarRental.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class RentalRecord
    {

        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Amount { get; set; }
        public RentalStatus Status { get; set; }
        public Seller Seller { get; set; }

        public RentalRecord()
        {
        }

        public RentalRecord(int id, DateTime date, double amount, RentalStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
