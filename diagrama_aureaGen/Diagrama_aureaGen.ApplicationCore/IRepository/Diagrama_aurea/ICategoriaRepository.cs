
using System;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
public partial interface ICategoriaRepository
{
void setSessionCP (GenericSessionCP session);

CategoriaEN ReadOIDDefault (int idCategoria
                            );

void ModifyDefault (CategoriaEN categoria);

System.Collections.Generic.IList<CategoriaEN> ReadAllDefault (int first, int size);



System.Collections.Generic.IList<CategoriaEN> ConsultarCategoria (int first, int size);


int CrearCategoria (CategoriaEN categoria);

void ModificarCategoria (CategoriaEN categoria);


void EliminarCategoria (int idCategoria
                        );
}
}
