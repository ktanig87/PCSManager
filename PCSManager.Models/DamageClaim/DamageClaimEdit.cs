using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.DamageClaim
{
    public class DamageClaimEdit
    {
        public int ClaimId { get; set; }
        public string Description { get; set; }
        public bool ClaimSubmitted { get; set; }
        public string ClaimNotes { get; set; }
        public bool ClaimResolved { get; set; }
        public int InventoryId { get; set; }
    }
}
