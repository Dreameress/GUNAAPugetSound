using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Internal;

namespace GUNAAPugetSound.Utilities
{
    public static class Validation
    {
        public interface IValidatable { }

        public static void EnforceValidity(this IValidatable obj)
        {
            var results = obj.Validate().ToArray();
            if (results.Any())
                throw new ValidationException(message: results.Select(v => v.ErrorMessage).Join(Environment.NewLine));
        }

        public static bool IsValid(this IValidatable obj, ValidationContext validationContext = null)
        {
            return !obj.Validate(validationContext).Any();
        }

        public static IEnumerable<ValidationResult> Validate(this IValidatable obj, ValidationContext validationContext = null)
        {
            var results = new List<ValidationResult>();
            validationContext = validationContext ?? new ValidationContext(obj);
            Validator.TryValidateObject(obj, validationContext, results, validateAllProperties: true);
            return results.Except(new[] { ValidationResult.Success });
        }

        public static ModelStateDictionary ToHttpModelStateDictionary(this IEnumerable<ValidationResult> errors)
        {
            return errors.Aggregate(new ModelStateDictionary(), (d, res) => {
                d.AddModelError(String.Join(", ", res.MemberNames), res.ErrorMessage);
                return d;
            });
        }
    }
}