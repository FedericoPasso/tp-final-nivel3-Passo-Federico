using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class ManejoError
    {
        public string MensajeError(Exception error)
        {
            return error.ToString();
        }
    }
}
