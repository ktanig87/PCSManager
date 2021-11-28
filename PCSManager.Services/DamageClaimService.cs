using PCSManager.Data;
using PCSManager.Models.DamageClaim;
using PCSManager.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSManager.Services
{
    public class DamageClaimService
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        private readonly Guid _userId;
        public DamageClaimService(Guid userId)
        { _userId = userId; }

        public bool CreateClaim(DamageClaimCreate model)
        {
            var entity =
                new DamageClaim()
                {
                    Description = model.Description,
                    ClaimSubmitted = model.ClaimSubmitted,
                    ClaimNotes = model.ClaimNotes,
                    ClaimResolved = model.ClaimResolved,
                    InventoryId = model.InventoryId
                };


            {
                ctx.DamageClaims.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DamageClaimListItem> GetClaims()
        {

            var query =
                ctx.DamageClaims.Select
                (
                    e =>
                    new DamageClaimListItem
                    {
                        ClaimId = e.ClaimId,
                        ClaimSubmitted = e.ClaimSubmitted,
                       ClaimResolved = e.ClaimResolved,
                        InventoryId = e.InventoryId
                    });
            return query.ToArray();
        }

        public IEnumerable<DamageClaimListItem> GetUnresolvedClaims()
        {
            var query =
                ctx.DamageClaims
                .Where(i => i.ClaimResolved == false)
                .Select
                (e =>
                new DamageClaimListItem
                {
                    InventoryId = e.InventoryId,
                    ClaimId = e.ClaimId
            
                }
                );
            return query.ToArray();
        }

        public DamageClaimDetail GetClaimById(int id)
        {
            var entity =
                ctx.DamageClaims.Single(e => e.ClaimId == id);
            return
                new DamageClaimDetail
                {
                    ClaimId = entity.ClaimId,
                    Description = entity.Description,
                    ClaimSubmitted = entity.ClaimSubmitted,
                    ClaimNotes = entity.ClaimNotes,
                    ClaimResolved = entity.ClaimResolved,
                    InventoryId = entity.InventoryId
                };
        }

        public bool UpdateClaim(DamageClaimEdit model)
        {
            var entity =
                ctx.DamageClaims.Single(e => e.ClaimId == model.ClaimId);
            entity.ClaimId = model.ClaimId;
            entity.Description = model.Description;
            entity.ClaimSubmitted = model.ClaimSubmitted;
            entity.ClaimNotes = model.ClaimNotes;
            entity.ClaimResolved = model.ClaimResolved;
            entity.InventoryId = model.InventoryId;
            return ctx.SaveChanges() == 1;
        }

        public bool DeleteClaim(int claimId)
        {
            var entity =
                ctx.DamageClaims.Single(e => e.ClaimId == claimId);
            ctx.DamageClaims.Remove(entity);
            return ctx.SaveChanges() == 1;
        }

    }
}
