using Microsoft.EntityFrameworkCore;
using SurveyApp.Data;
using SurveyApp.Services.Abstract;
using SurveyApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Services
{
    public class GroupService : IGroupService
    {
        private readonly SurveyContext _dbContext;

        public GroupService(SurveyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            var groups = (await _dbContext.Group.ToListAsync()).Select(group => new Group() { GroupId = group.GroupId });
            return groups;
        }

    }
}
