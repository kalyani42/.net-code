using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetECINo.Models
{
    public class ErrorResponse
    {
        public string ErrorMessage { get; set; }
       // public string ErrorMessage {get;
        public int StatusCode { get; set; }
    }
}
