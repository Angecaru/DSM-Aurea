
using System;
// Definición clase AdministradorEN
namespace Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea
{
public partial class AdministradorEN
{
/**
 *	Atributo codigoEmpresa
 */
private string codigoEmpresa;



/**
 *	Atributo administra
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> administra;



/**
 *	Atributo gestiona
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DeTemporadaEN> gestiona;






public virtual string CodigoEmpresa {
        get { return codigoEmpresa; } set { codigoEmpresa = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> Administra {
        get { return administra; } set { administra = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DeTemporadaEN> Gestiona {
        get { return gestiona; } set { gestiona = value;  }
}





public AdministradorEN()
{
        administra = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN>();
        gestiona = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DeTemporadaEN>();
}



public AdministradorEN(string codigoEmpresa, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> administra, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DeTemporadaEN> gestiona
                       )
{
        this.init (CodigoEmpresa, administra, gestiona);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (administrador.CodigoEmpresa, administrador.Administra, administrador.Gestiona);
}

private void init (string codigoEmpresa
                   , System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> administra, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DeTemporadaEN> gestiona)
{
        this.CodigoEmpresa = codigoEmpresa;


        this.Administra = administra;

        this.Gestiona = gestiona;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
        if (t == null)
                return false;
        if (CodigoEmpresa.Equals (t.CodigoEmpresa))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.CodigoEmpresa.GetHashCode ();
        return hash;
}
}
}
