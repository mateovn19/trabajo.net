using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMaquina.Model
{
    interface iproduct
    {

        string Name { get; set; }

        int Price {  get; set; }

        int Quantity { get; set; }

        int Inventory { get; set; }
        string DisplayProduct();

    }
}
