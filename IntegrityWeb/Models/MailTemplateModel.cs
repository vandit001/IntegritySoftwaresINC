namespace IntegrityWeb.Models
{
    public class MailTemplateModel
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerContactNo { get; set; }
        public string CustomerAddress { get; set; }
        public string Budget { get; set; }
        public int Ratingstar { get; set; }

        public string Message { get; set; }
        public string ReferralName { get; set; }
        public string ReferralEmail { get; set; }
        public string ReferralContactNo { get; set; }
        public string ReferralToName { get; set; }

        public string ReferralToEmail { get; set; }
        public string ReferralToContactNo { get; set; }
        public string CreatedDate { get; set; }


    }
}