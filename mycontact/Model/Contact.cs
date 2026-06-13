using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mycontact.Models
{
    [Table("mycontact")]
    public class Contact
    {
        [Key]
        public int contactid { get; set; }

        public string name { get; set; }

        public string family { get; set; }

        public string mobile { get; set; }

        public string email { get; set; }

        public int age { get; set; }

        public string address { get; set; }
    }
}