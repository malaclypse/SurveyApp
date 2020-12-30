using System;
using System.Collections.Generic;
using System.Text;
using SurveyApp.Services.Dtos;
using System.Threading.Tasks;

namespace SurveyApp.Services.Abstract
{
	public interface IGroupService
	{
		Task<IEnumerable<Group>> GetAllAsync();
	}
}
