using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationApp.Models
{
    public class ResponseData
    {
        public int Status { get; set; }
        public string Text { get; set; }
        public bool IsError { get; set; }
    }
}
