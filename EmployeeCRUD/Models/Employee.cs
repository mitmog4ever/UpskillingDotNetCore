using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string CIN { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public int Tele { get; set; }
        [Required]
        public string Fonction { get; set; }
        [Required]
        public string Sexe { get; set; }
 
        [Required]
        public string Departement { get; set; }
        [Required]
        public Decimal Salaire{ get; set; }

    }
}
