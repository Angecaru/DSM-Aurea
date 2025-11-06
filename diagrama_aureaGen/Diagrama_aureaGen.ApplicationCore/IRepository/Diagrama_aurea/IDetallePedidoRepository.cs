
using System;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
public partial interface IDetallePedidoRepository
{
void setSessionCP (GenericSessionCP session);

DetallePedidoEN ReadOIDDefault (int idDetalle
                                );

void ModifyDefault (DetallePedidoEN detallePedido);

System.Collections.Generic.IList<DetallePedidoEN> ReadAllDefault (int first, int size);



int CrearDetallePedido (DetallePedidoEN detallePedido);

void ModificarDetallePedido (DetallePedidoEN detallePedido);


void EliminarDetallePedido (int idDetalle
                            );


DetallePedidoEN ReadOID (int idDetalle
                         );


System.Collections.Generic.IList<DetallePedidoEN> ReadAll (int first, int size);
}
}
