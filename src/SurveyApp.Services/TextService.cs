using System;
using System.Collections.Generic;
using System.Text;
using SurveyApp.Services.Dtos;
using System.Threading.Tasks;
using SurveyApp.Services.Abstract;
using SurveyApp.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SurveyApp.Services
{
    public class TextService : ITextService
    {
        private readonly SurveyContext _dbContext;

        public TextService(SurveyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TextEntry>> GetAllAsync()
        {
            var texts = (await _dbContext.TextEntry.ToListAsync()).Select(text => new TextEntry() { TextId = text.TextId, Text = text.Text });
            return texts;
        }

    }
}
