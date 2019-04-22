using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Exceptions
{
    public class NumerosInteiroInvalidoExceptions : Exception
    {
        public NumerosInteiroInvalidoExceptions()
            : base("Número inteiro inválido!")
        { }
    }
}
