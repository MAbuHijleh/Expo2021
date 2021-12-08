using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expotech2021.viewModels
{
    public class QuestionVM
    {
        public int Id { get; set; }
        public string QuestionString { get; set; }
        public string Answer { get; set; }
        public int EntryId { get; set; }
    }
}
