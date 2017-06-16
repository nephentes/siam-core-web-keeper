using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePlugins
{

    public enum ResultCode
    {
        normal = 1, warning = 2, error = 3, fatal = 4
    }

    public class TestResult
    {

        public ResultCode Result { get; set; }

        public decimal? ResultDec1 { get; set; }

        public decimal? ResultDec2 { get; set; }

        public decimal? ResultDec3 { get; set; }

        public decimal? ResultDec4 { get; set; }

        public decimal? ResultDec5 { get; set; }

        public string Message { get; set; }

        public TestResult()
        {

        }

    }

}
