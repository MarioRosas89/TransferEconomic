using System.ComponentModel.DataAnnotations;

namespace TransferEconomic.Data
{
    public class Places
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
