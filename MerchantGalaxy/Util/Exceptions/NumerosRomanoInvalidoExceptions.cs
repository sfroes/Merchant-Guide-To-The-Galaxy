using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Exceptions
{
    public class NumerosRomanoInvalidoExceptions : Exception
    {
        public NumerosRomanoInvalidoExceptions()
            : base("Número romano inválido!")
        { }
    }
}
