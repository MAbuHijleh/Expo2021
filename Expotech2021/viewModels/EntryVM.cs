using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Expotech2021.viewModels
{
    public class EntryVM
    {
        public int Id { get; set; }
        public DateTime timeCreated { get; set; }

        public IEnumerable<QuestionVM> questions { get; set; }
    }
}
