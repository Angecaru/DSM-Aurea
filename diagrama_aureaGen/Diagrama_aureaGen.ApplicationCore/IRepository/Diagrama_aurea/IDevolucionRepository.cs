
using System;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
public partial interface IDevolucionRepository
{
void setSessionCP (GenericSessionCP session);

DevolucionEN ReadOIDDefault (int idDevolucion
                             );

void ModifyDefault (DevolucionEN devolucion);

System.Collections.Generic.IList<DevolucionEN> ReadAllDefault (int first, int size);



int CrearDevolucion (DevolucionEN devolucion);

void ModificarDevolucion (DevolucionEN devolucion);


void EliminarDevolucion (int idDevolucion
                         );
}
}
