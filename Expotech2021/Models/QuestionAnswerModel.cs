using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Expotech2021.models;

namespace Expotech2021.Models
{
    public class QuestionAnswerModel: IModelBase
    {
        public int Id { get; set; }
        public string QuestionString { get; set; }
        public string Answer { get; set; }
        public int EntryId { get; set; }
        [ForeignKey(nameof(EntryId))]
        public QuestionareEntry Entry { get; set; }
    }
}
