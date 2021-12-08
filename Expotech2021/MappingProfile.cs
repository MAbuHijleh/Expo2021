using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Expotech2021.Models;
using Expotech2021.viewModels;

namespace Expotech2021
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<QuestionareEntry, EntryVM>();
            CreateMap<EntryVM, QuestionareEntry>();
            CreateMap<QuestionAnswerModel, QuestionVM>();
            CreateMap<QuestionVM, QuestionAnswerModel>();
        }
    }
}
