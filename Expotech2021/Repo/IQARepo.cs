using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expotech2021.Models;

namespace Expotech2021.Repo
{
    public interface IQARepo : IGenRepo<QuestionAnswerModel>
    {
    }


    public class QARepo : GenRepo<QuestionAnswerModel>, IQARepo
    {
        private readonly ApplicationBDContext _context;

        public QARepo(ApplicationBDContext context) : base(context)
        { 
            this._context = context;
        }
    }
}
