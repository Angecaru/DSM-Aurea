
using System;
// Definición clase FavoritoEN
namespace Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea
{
public partial class FavoritoEN
{
/**
 *	Atributo idFavorito
 */
private int idFavorito;



/**
 *	Atributo producto
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> producto;



/**
 *	Atributo usuario
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN usuario;






public virtual int IdFavorito {
        get { return idFavorito; } set { idFavorito = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> Producto {
        get { return producto; } set { producto = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public FavoritoEN()
{
        producto = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN>();
}



public FavoritoEN(int idFavorito, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> producto, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN usuario
                  )
{
        this.init (IdFavorito, producto, usuario);
}


public FavoritoEN(FavoritoEN favorito)
{
        this.init (favorito.IdFavorito, favorito.Producto, favorito.Usuario);
}

private void init (int idFavorito
                   , System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN> producto, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN usuario)
{
        this.IdFavorito = idFavorito;


        this.Producto = producto;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FavoritoEN t = obj as FavoritoEN;
        if (t == null)
                return false;
        if (IdFavorito.Equals (t.IdFavorito))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdFavorito.GetHashCode ();
        return hash;
}
}
}
