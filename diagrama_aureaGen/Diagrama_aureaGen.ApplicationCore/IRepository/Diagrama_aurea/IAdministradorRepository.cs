
using System;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
public partial interface IAdministradorRepository
{
void setSessionCP (GenericSessionCP session);

AdministradorEN ReadOIDDefault (string codigoEmpresa
                                );

void ModifyDefault (AdministradorEN administrador);

System.Collections.Generic.IList<AdministradorEN> ReadAllDefault (int first, int size);



string CrearAdministrador (AdministradorEN administrador);

System.Collections.Generic.IList<AdministradorEN> ConsultarAdministrador (int first, int size);


void ModificarAdministrador (AdministradorEN administrador);


void EliminarAdministrador (string codigoEmpresa
                            );
}
}
