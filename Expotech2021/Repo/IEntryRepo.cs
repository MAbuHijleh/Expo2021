using System.Collections.Generic;
using System.Threading.Tasks;
using Expotech2021.Models;
using Microsoft.EntityFrameworkCore;

namespace Expotech2021.Repo
{
    public interface IEntryRepo : IGenRepo<QuestionareEntry>
    {
        Task<List<QuestionareEntry>> GetWithQuestions();
    }


    public class EntryRepo : GenRepo<QuestionareEntry>, IEntryRepo
    {
        private readonly ApplicationBDContext _context;

        public EntryRepo(ApplicationBDContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<QuestionareEntry>> GetWithQuestions()
        {
            return await _context.Set<QuestionareEntry>().Include(u => u.questions).ToListAsync();
        }
    }
}
