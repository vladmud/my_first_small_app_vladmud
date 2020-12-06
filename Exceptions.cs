using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENDRYU_TROELSEN_PRACTIC_1
{
    public class BalanceLowerThanZeroException : Exception
    {
        public override string Message => "Balance become lower than zero";
        public BalanceLowerThanZeroException(string Message = "Your balance ccant be lower than 0") : base(Message)
        {

        }
    }
    public class AmountLessThanZero : Exception
    {
        public override string Message => "Amount become lower than zero";
        public AmountLessThanZero(string Message = "Amount cant be lower than 0") : base(Message)
        {

        }
    }
}
