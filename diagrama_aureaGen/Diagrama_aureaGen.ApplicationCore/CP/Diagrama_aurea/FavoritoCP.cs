
using System;
using System.Text;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.Exceptions;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Utils;



namespace Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea
{
public partial class FavoritoCP : GenericBasicCP
{
public FavoritoCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public FavoritoCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
