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

        public async Task<IEnumerable<TextEntry>> GetAllAsync(int variantId)
        {
            var variant = await _dbContext.Variant.SingleAsync(variant => variant.VariantId == variantId);
            var variantTexts = new List<int> { variant.Text1Id, variant.Text2Id, variant.Text3Id, variant.Text4Id, variant.Text5Id, variant.Text6Id, variant.Text7Id, variant.Text8Id };
            var texts = (await _dbContext.TextEntry.Where(text => variantTexts.Contains(text.TextId)).ToListAsync()).Select(text => new TextEntry() { TextId = text.TextId, Text = text.Text });
            return texts;
        }

    }
}
