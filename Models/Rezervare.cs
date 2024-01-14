using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcNautic.Models
{
    public class NauticPlan

    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string NumberOfPeople { get; set; }
        public string Activity { get; set; }

        [ForeignKey("NauticZq")] 
        public int NauticZqId { get; set; }

    }
}
