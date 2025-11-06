
using System;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
public partial interface IProductoRepository
{
void setSessionCP (GenericSessionCP session);

ProductoEN ReadOIDDefault (int idProducto
                           );

void ModifyDefault (ProductoEN producto);

System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size);



int CrearProducto (ProductoEN producto);

System.Collections.Generic.IList<ProductoEN> ConsultarProducto (int first, int size);


void ModificarProducto (ProductoEN producto);


void EliminarProducto (int idProducto
                       );
}
}
