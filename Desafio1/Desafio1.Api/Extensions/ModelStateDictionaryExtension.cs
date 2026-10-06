using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Desafio1.Extensions;

public static class ModelStateDictionaryExtension
{
    public static List<string> GetErrors(this ModelStateDictionary modelState)
    {
        var errors = new List<string>();
        foreach (var values in modelState.Values)
        {
            foreach (var error in values.Errors)
            {
                errors.Add(error.ErrorMessage);
            }
        }
        return errors;
    }
}