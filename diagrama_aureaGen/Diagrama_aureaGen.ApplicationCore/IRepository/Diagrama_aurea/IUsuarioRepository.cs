
using System;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
public partial interface IUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioEN ReadOIDDefault (int idUsuario
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



int CrearUsuario (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ConsultarUsuario (int first, int size);


void ModificarUsuario (UsuarioEN usuario);


void EliminarUsuario (int idUsuario
                      );
}
}
