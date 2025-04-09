
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ASP_MVC.Handlers
{
	public static class FormValidationHandler
	{
		public static void MinMaxValidation(this ModelStateDictionary modelState,int minValue, int maxValue, string minFieldName, string maxFieldName)
		{
			if(minValue > maxValue)
			{
				modelState.AddModelError(minFieldName, "Minimum field can't be bigger than Maximum field!");
				modelState.AddModelError(maxFieldName, "Maximum field can't be lower than Minimum field!");
			}
		}
	}
}
