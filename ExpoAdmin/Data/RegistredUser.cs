using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpoAdmin.Data
{
    public class RegistredUser : IModelBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public string FullName { get; set; }
        public string Organization { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
    }
}
