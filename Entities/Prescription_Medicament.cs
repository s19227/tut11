using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tut11.Entities
{
    public class Prescription_Medicament
    {
        public int? Dose { get; set; }
        public string Details { get; set; }
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }

        public Medicament Medicament { get; set; }
        public Prescription Prescription { get; set; }
    }
}
