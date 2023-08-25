using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingCruise.Models
{
    [Table("CruiseBooks")]
    public class CruiseBook
    {
        [Key]
        public int CruiseId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Arrival { get; set; }

        public string Destination { get; set; }

        public string Membership { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }= DateTime.Now;

        public int? amount { get; set; } 

    }
}
