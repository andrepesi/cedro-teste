using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Credo.Domain.Validation
{
    public class ValidationResult
    {
        public bool IsValid { get { return !(Errors?.Any()).GetValueOrDefault(); } }
        public IList<string> Errors { get; set; }
        public ValidationResult()
        {
            this.Errors = new List<string>();
        }
        public void AddMessage(string message) => this.Errors.Add(message);
    }
}
