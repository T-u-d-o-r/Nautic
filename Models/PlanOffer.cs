using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ParcNautic.Models
{
    public class PlanOffer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(NauticPlan))]
        public int NauticPlanId { get; set; }
        public int OfferId { get; set; }

    }
}
