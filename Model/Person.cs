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
        public string TypeOfSeva { get; set; } = string.Empty ;

        public string UpdatedBy { get; set; } = string.Empty ;

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
