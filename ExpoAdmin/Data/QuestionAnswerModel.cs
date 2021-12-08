using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpoAdmin.Data
{
    public class QuestionAnswerModel: IModelBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public string QuestionString { get; set; }
        public string Answer { get; set; }
        public int EntryId { get; set; }
        [ForeignKey(nameof(EntryId))]
        public QuestionareEntry Entry { get; set; }
    }
}
