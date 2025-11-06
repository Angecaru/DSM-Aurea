
using System;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
public partial interface IProductoCarritoRepository
{
void setSessionCP (GenericSessionCP session);

ProductoCarritoEN ReadOIDDefault (int idCarritoProducto
                                  );

void ModifyDefault (ProductoCarritoEN productoCarrito);

System.Collections.Generic.IList<ProductoCarritoEN> ReadAllDefault (int first, int size);



int CrearProductoCarrito (ProductoCarritoEN productoCarrito);

void ModificarProductoCarrito (ProductoCarritoEN productoCarrito);


void EliminarProductoCarrito (int idCarritoProducto
                              );
}
}
