
using System;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
public partial interface IDeTemporadaRepository
{
void setSessionCP (GenericSessionCP session);

DeTemporadaEN ReadOIDDefault (int idTemporada
                              );

void ModifyDefault (DeTemporadaEN deTemporada);

System.Collections.Generic.IList<DeTemporadaEN> ReadAllDefault (int first, int size);



int CrearDeTemporada (DeTemporadaEN deTemporada);

void ModificarDeTemporada (DeTemporadaEN deTemporada);


void EliminarDeTemporada (int idTemporada
                          );


System.Collections.Generic.IList<DeTemporadaEN> ConsultarDeTemporada (int first, int size);
}
}
