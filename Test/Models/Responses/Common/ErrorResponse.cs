using Microsoft.ReportingServices.Diagnostics.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models.Responses.Common
{
    public class ErrorResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }

        public ErrorResponse(string message, string description, string code = "Unknow")
        {
            Message = message;
            Description = description;
            Code = code;
        }

        public ErrorResponse()
        {
            Message = string.Empty;
            Description = string.Empty;
            Code = "Unknow";
            
        }
    }
}
