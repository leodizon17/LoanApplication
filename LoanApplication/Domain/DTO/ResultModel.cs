using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public partial class ResultModel
    {
        public string decision { get; set; }
        public List<ValidationResult> validationResult { get; set; } = new List<ValidationResult> { };
    }

    public class ValidationResult
    {
        public string rule { get; set; }
        public string message { get; set; }
        public string decision { get; set; }
    }
}
