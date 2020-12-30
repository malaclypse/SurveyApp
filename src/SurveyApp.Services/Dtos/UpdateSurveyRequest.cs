using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Services.Dtos
{
	public class UpdateSurveyRequest
	{
		public bool? IsCompleted { get; set; }

		public bool? IsDeleted { get; set; }

	}
}
