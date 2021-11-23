using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Data
{
    public class DamageClaim
    {
        [Key]
        public int ClaimId { get; set; }
        public string Description { get; set; }
        public bool ClaimSubmitted { get; set; }
        public string ClaimNotes { get; set; }
        public bool ClaimResolved { get; set; }

        public virtual InventoryItem InventoryItem { get; set; }
        [ForeignKey(nameof(InventoryItem))]
        public int InventoryId { get; set; }
    }
}
