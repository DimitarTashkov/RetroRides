using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroRides.Services.Interfaces
{
    public interface IValidateModel
    {
        public Task<(bool IsValid, List<ValidationResult> Errors)> ValidateModelAsync<TModel>(TModel model);

    }
}
