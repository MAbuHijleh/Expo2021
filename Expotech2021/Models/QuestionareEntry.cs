using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expotech2021.models;

namespace Expotech2021.Models
{
    public class QuestionareEntry : IModelBase
    {
        public int Id { get; set; }

        public DateTime timeCreated { get; set; }

        public IEnumerable<QuestionAnswerModel> questions { get; set; }

    }
}
