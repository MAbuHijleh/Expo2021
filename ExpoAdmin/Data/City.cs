using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpoAdmin.Data
{
    public class City : IModelBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
