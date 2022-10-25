using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransferEconomic.Data
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public float Price { get; set; }
        public int FromIdPlace { get; set; }
        public int ToIdPlace { get; set; }
    }
}
