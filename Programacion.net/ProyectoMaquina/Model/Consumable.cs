using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMaquina.Model
{

    public class Consumable : iproduct
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public int Inventory { get; set; }

        public Consumable(string name, int price, int quantity, int inventory)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Inventory = inventory; 
        }

        public string DisplayProduct()
        {

            return $"Nombre : {Name}  - Price: {Price} ({Quantity}) ";


        }

        

        

    }









}
 
