using System.ComponentModel.DataAnnotations;

namespace GCPDev.FinalTask.Models
{
    public class WishModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
    }
}
