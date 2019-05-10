using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Validators;

namespace Services.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public List<ValidatorResult> Errors { get; set; }
    }
}