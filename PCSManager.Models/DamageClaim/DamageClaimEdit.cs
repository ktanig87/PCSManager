using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Models.DamageClaim
{
    public class DamageClaimEdit
    {
        public int ClaimId { get; set; }
        public string Description { get; set; }
        [Display(Name = "Claim Submitted?")]
        public bool ClaimSubmitted { get; set; }
        [Display(Name = "Claim Resolved?")]
        public bool ClaimResolved { get; set; }

        [Display(Name = "Inventory Item ID")]
        public int InventoryId { get; set; }
        [Display(Name = "Claim Notes")]
        public string ClaimNotes { get; set; }
    }
}
