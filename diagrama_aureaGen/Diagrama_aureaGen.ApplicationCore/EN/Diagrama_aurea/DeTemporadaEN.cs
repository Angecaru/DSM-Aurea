
using System;
// Definición clase DeTemporadaEN
namespace Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea
{
public partial class DeTemporadaEN
{
/**
 *	Atributo idTemporada
 */
private int idTemporada;



/**
 *	Atributo clasificado_en
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> clasificado_en;



/**
 *	Atributo administrador
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.AdministradorEN administrador;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo fechaInicio
 */
private Nullable<DateTime> fechaInicio;



/**
 *	Atributo fechaFin
 */
private Nullable<DateTime> fechaFin;






public virtual int IdTemporada {
        get { return idTemporada; } set { idTemporada = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> Clasificado_en {
        get { return clasificado_en; } set { clasificado_en = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.AdministradorEN Administrador {
        get { return administrador; } set { administrador = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual Nullable<DateTime> FechaInicio {
        get { return fechaInicio; } set { fechaInicio = value;  }
}



public virtual Nullable<DateTime> FechaFin {
        get { return fechaFin; } set { fechaFin = value;  }
}





public DeTemporadaEN()
{
        clasificado_en = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN>();
}



public DeTemporadaEN(int idTemporada, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> clasificado_en, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.AdministradorEN administrador, string nombre, Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin
                     )
{
        this.init (IdTemporada, clasificado_en, administrador, nombre, fechaInicio, fechaFin);
}


public DeTemporadaEN(DeTemporadaEN deTemporada)
{
        this.init (deTemporada.IdTemporada, deTemporada.Clasificado_en, deTemporada.Administrador, deTemporada.Nombre, deTemporada.FechaInicio, deTemporada.FechaFin);
}

private void init (int idTemporada
                   , System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> clasificado_en, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.AdministradorEN administrador, string nombre, Nullable<DateTime> fechaInicio, Nullable<DateTime> fechaFin)
{
        this.IdTemporada = idTemporada;


        this.Clasificado_en = clasificado_en;

        this.Administrador = administrador;

        this.Nombre = nombre;

        this.FechaInicio = fechaInicio;

        this.FechaFin = fechaFin;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DeTemporadaEN t = obj as DeTemporadaEN;
        if (t == null)
                return false;
        if (IdTemporada.Equals (t.IdTemporada))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdTemporada.GetHashCode ();
        return hash;
}
}
}
