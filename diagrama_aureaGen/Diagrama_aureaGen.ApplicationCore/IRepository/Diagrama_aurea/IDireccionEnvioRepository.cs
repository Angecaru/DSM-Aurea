
using System;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
public partial interface IDireccionEnvioRepository
{
void setSessionCP (GenericSessionCP session);

DireccionEnvioEN ReadOIDDefault (int idDireccion
                                 );

void ModifyDefault (DireccionEnvioEN direccionEnvio);

System.Collections.Generic.IList<DireccionEnvioEN> ReadAllDefault (int first, int size);



System.Collections.Generic.IList<DireccionEnvioEN> ConsultarDireccion (int first, int size);


int CrearDireccion (DireccionEnvioEN direccionEnvio);

void ModificarDireccion (DireccionEnvioEN direccionEnvio);


void EliminarDireccion (int idDireccion
                        );
}
}
