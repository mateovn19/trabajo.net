using ProyectoMaquina.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMaquina.Control
{
    internal class Controller
    {

        private static Controller _instance;


        public List<iproduct> ListaProductos { get; set; }

        private Controller()
        {
            ListaProductos = new List<iproduct>(); 

            ListaProductos.Add(new Consumable("Margaritas",4500,15,30));
            ListaProductos.Add(new Consumable("Chocorramo",2500,8,10));
            ListaProductos.Add(new Consumable("Aceite",5000,20,20));
            ListaProductos.Add(new Consumable("Salchichon", 1500, 4, 10));
            ListaProductos.Add(new Consumable("Arroz", 3000, 10, 15));

        }

        public static Controller GetInstance()
        {
            if(_instance == null)
            {

                _instance = new Controller();

            }
            return _instance;
        }

        public string DisplayProductList()
        {
            string value = string.Empty;
            foreach (iproduct product in ListaProductos)
            {
                value += product.DisplayProduct() + '\n';

            }
            return value;
        }

        public bool ProductExists(string product_name)
        {
            bool product_exists = false;
            foreach (iproduct product in ListaProductos)
            {
                if (product.Name == product_name && product.Quantity > 0)
                {
                    product_exists = true;

                }
            }
            return product_exists;
        }

        public bool ProductHasInventory(string product_name)
        {
            return ListaProductos.Any(product => product.Name == product_name && product.Quantity > 0);
        }

        public void AddProduct(string name, int price, int inicialQuantity, int inventory)
        {
            ListaProductos.Add(new Consumable(name, price, inicialQuantity, inventory));

        }
        public void RestockProduct(string name, int quantity)
        {
            var product = ListaProductos.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                product.Inventory += quantity;
            }

        }


    }
}
