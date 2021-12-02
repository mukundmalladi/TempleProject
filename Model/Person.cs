﻿using System.ComponentModel.DataAnnotations.Schema;

namespace TempleProject.Model
{
    public class Person
    {
        public long Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
        public Guid PaymentGuid { get; set; }
        public string SmsSubmission { get; set; } = string.Empty;
        public string TypeOfSeva { get; set; } = string.Empty;

        public string UpdatedBy { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        [NotMapped]
        public bool SmsSent { get => !string.IsNullOrEmpty(SmsSubmission); }

        public double AmountPaid { get; set; }

        public string Ghortram { get; set; } = string.Empty ;

        public string OtherNames { get; set; } = string.Empty ;
    }
}
