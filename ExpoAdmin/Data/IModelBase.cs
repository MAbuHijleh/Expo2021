using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpoAdmin.Data
{
    public interface IModelBase
    {
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; }

    }
}
