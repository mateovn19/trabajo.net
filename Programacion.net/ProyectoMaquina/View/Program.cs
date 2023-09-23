using ProyectoMaquina.Control;
using ProyectoMaquina.Model;
using System;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ProyectoMaquina.View
{
    internal class View
    {
        static void Main(string[] args)
        {
            //aca empieza nustro programa

            Controller controller = Controller.GetInstance();

            Console.WriteLine("Bienvenido a la maquina expendedora escoja un tipo de cliente :");
            string input_cliente = "";

            while (true)
            {
                
                do
                {
                    Console.WriteLine("Cliente [c] o [p] ");
                    input_cliente = Console.ReadLine();

                } while (input_cliente != "c" && input_cliente != "p");


                Console.WriteLine("La lista de productos es: ");

                Console.WriteLine(controller.DisplayProductList());


                if (input_cliente == "c")
                {
                        Console.WriteLine("Escoja un producto de la lista...");
                        bool validar_product = false;
                        iproduct selectProduct = null;
                    do
                    {
                        string input_producto = Console.ReadLine();
                        validar_product = controller.ProductExists(input_producto) && controller.ProductHasInventory(input_producto);

                        if (validar_product)
                        {
                            selectProduct = controller.ListaProductos.FirstOrDefault(p => p.Name == input_producto);
                        }
                        else
                        {
                            Console.WriteLine("Escoja un producto válido");
                        }
                    } while (!validar_product);

                    int precio_total = selectProduct.Price;

                    int dinero_total = 0;

                    Console.WriteLine($"El precio del producto es: {precio_total}");


                    while (dinero_total < precio_total)
                    {
                        try
                        {
                            Console.WriteLine("Ingrese una moneda: [50],[100],[200],[500]:");
                            int validar_moneda = int.Parse(Console.ReadLine());

                            if (validar_moneda != 500 && validar_moneda != 200 && validar_moneda != 100 && validar_moneda!= 50)
                            {
                                throw new ArgumentException("La moneda que selecciono no es valida");
                            }

                            dinero_total += precio_total;
                            Console.WriteLine($"Esto es el total que usted ingreso: {precio_total}");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Por favor ingrese un valor tipo numerico");
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Por favor ingrese una de estas moneda: [50],[100],[200],[500] ");
                        }
                    }

                    if (dinero_total > precio_total)
                    {
                        int change = dinero_total - precio_total;

                        Console.WriteLine($"Gracias por su compra, aqui tienes tu producto y el cambio: {change}");

                        selectProduct.Quantity--;
                    }
                    else if (dinero_total == precio_total )
                    {
                        
                        Console.WriteLine("Gracias por su compra, aqui tienes tu producto. ");
                       
                        selectProduct.Quantity--;
                    }
                    else
                    {
                        
                        Console.WriteLine("Se a cancelado su compra, el dinero que tiene no es suficiente");
                    }

                }

                else if (input_cliente == "p")
                {
                    Console.WriteLine("Bienvenido proveedor");
                    Console.WriteLine("Que de quiere hacer en la maquina,agregar un nuevo producto con: [AGREGAR] o rellenar un producto con [RELLENAR]");
                    string input_proveedor = Console.ReadLine();

                    if (input_proveedor == "AGREGAR")
                    {
                        Console.WriteLine("Ingrese el nombre,precio,la cantidad del inventario del nuevo producto que quiere agregar");
                        Console.WriteLine("Nombre:");
                        string newProductName = Console.ReadLine();
                        Console.WriteLine("Price:");
                        int newProductPrice = int.Parse(Console.ReadLine());
                        Console.WriteLine("Cantidad:");
                        int newProductInitialQuantity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Cantidad del inventario:");
                        int newProductInventory = int.Parse(Console.ReadLine());

                        controller.AddProduct(newProductName, newProductPrice, newProductInitialQuantity, newProductInventory);
                        Console.WriteLine($"el producto '{newProductName}: precio:{newProductPrice} cantidad:{newProductInitialQuantity} inventario:{newProductInventory}.' a sido agregado con exito.");
                    }
                    else if (input_proveedor == "RELLENAR")
                    {
                        Console.WriteLine("Ingrese el nombre del producto para rellenar el inventario del productoen la maquina expenderora");
                        string productNameToRestock = Console.ReadLine();

                        Console.WriteLine("cuanto quiete rellenar la maquina expendedora");
                        int restockQuantity = int.Parse(Console.ReadLine());

                        controller.RestockProduct(productNameToRestock, restockQuantity);
                        Console.WriteLine($"El inventario de:'{productNameToRestock} con una cantidad de: {restockQuantity}.' a sido rellenado con exito");
                    }
                    else
                    {
                        Console.WriteLine("Opción no apta para los proveedores");
                    }






                }










            }







        }
    }
}
