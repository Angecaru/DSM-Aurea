
using System;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
public partial interface IMetodoPagoRepository
{
void setSessionCP (GenericSessionCP session);

MetodoPagoEN ReadOIDDefault (int idMetodo
                             );

void ModifyDefault (MetodoPagoEN metodoPago);

System.Collections.Generic.IList<MetodoPagoEN> ReadAllDefault (int first, int size);



int CrearMetodoPago (MetodoPagoEN metodoPago);

System.Collections.Generic.IList<MetodoPagoEN> ConsultarMetodoPago (int first, int size);


void ModificarMetodoPago (MetodoPagoEN metodoPago);


void EliminarMetodoPago (int idMetodo
                         );
}
}
