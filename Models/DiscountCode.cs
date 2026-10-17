using System.ComponentModel.DataAnnotations;

namespace TvRepairWebsite.Models
{
    public class DiscountCode
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime CreateDate  { get; set; }
        public bool IsShown { get; set; }

        //Navigation Property
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
