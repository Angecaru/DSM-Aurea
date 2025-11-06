
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
public partial class UsuarioCP : GenericBasicCP
{
public UsuarioCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public UsuarioCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
