using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TempleProject.Model
{
    public class Person
    {
        public long Id { get; set; }

        [DataType(DataType.Text)]
        public string FirstName { get; set; } = string.Empty;
        [DataType(DataType.Text)]
        public string LastName { get; set; } = string.Empty;
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;
        public Guid PaymentGuid { get; set; }
        public string SmsSubmission { get; set; } = string.Empty;
        [DataType(DataType.Text)]
        public string TypeOfSeva { get; set; } = string.Empty;
        [DataType(DataType.Text)]
        public string UpdatedBy { get; set; } = string.Empty;
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdateDate { get; set; }

        [NotMapped]
        public bool SmsSent { get => !string.IsNullOrEmpty(SmsSubmission); }

        [DataType(DataType.Currency)]
        public double AmountPaid { get; set; }
        [DataType(DataType.Text)]
        public string Gothram { get; set; } = string.Empty ;
        [DataType(DataType.Text)]
        public string OtherNames { get; set; } = string.Empty ;
    }
}
