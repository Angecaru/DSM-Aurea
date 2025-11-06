
using System;
// Definición clase CategoriaEN
namespace Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea
{
public partial class CategoriaEN
{
/**
 *	Atributo idCategoria
 */
private int idCategoria;



/**
 *	Atributo pertenece
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> pertenece;



/**
 *	Atributo nombreCategoria
 */
private string nombreCategoria;



/**
 *	Atributo descripcion
 */
private string descripcion;






public virtual int IdCategoria {
        get { return idCategoria; } set { idCategoria = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> Pertenece {
        get { return pertenece; } set { pertenece = value;  }
}



public virtual string NombreCategoria {
        get { return nombreCategoria; } set { nombreCategoria = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}





public CategoriaEN()
{
        pertenece = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN>();
}



public CategoriaEN(int idCategoria, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> pertenece, string nombreCategoria, string descripcion
                   )
{
        this.init (IdCategoria, pertenece, nombreCategoria, descripcion);
}


public CategoriaEN(CategoriaEN categoria)
{
        this.init (categoria.IdCategoria, categoria.Pertenece, categoria.NombreCategoria, categoria.Descripcion);
}

private void init (int idCategoria
                   , System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> pertenece, string nombreCategoria, string descripcion)
{
        this.IdCategoria = idCategoria;


        this.Pertenece = pertenece;

        this.NombreCategoria = nombreCategoria;

        this.Descripcion = descripcion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CategoriaEN t = obj as CategoriaEN;
        if (t == null)
                return false;
        if (IdCategoria.Equals (t.IdCategoria))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdCategoria.GetHashCode ();
        return hash;
}
}
}
