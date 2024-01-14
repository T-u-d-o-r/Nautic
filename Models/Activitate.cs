using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcNautic.Models
{
    public class NauticZq
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NauticZqName { get; set; }
        public string Address { get; set; }
        public string Coordinates { get; set; }
        public string NauticZqDetails
        { get { return NauticZqName + " " + Address; } }

        [OneToMany]
        public List<NauticPlan> NauticPlans { get; set; }
    }
        
}
