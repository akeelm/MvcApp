using System;

namespace Repository.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string EmailAddress { get; set; }
        public string Telephone { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}
