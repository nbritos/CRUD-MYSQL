using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CECliente
    {
        public static int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public CECliente ()
        {
            ID++;
        }
    }
}
