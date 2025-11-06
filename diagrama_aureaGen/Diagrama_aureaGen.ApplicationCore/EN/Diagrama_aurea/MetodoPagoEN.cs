
using System;
// Definición clase MetodoPagoEN
namespace Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea
{
public partial class MetodoPagoEN
{
/**
 *	Atributo idMetodo
 */
private int idMetodo;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN> pedido;



/**
 *	Atributo usuario
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN usuario;



/**
 *	Atributo tipo
 */
private string tipo;



/**
 *	Atributo esPredeterminado
 */
private bool esPredeterminado;






public virtual int IdMetodo {
        get { return idMetodo; } set { idMetodo = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual string Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual bool EsPredeterminado {
        get { return esPredeterminado; } set { esPredeterminado = value;  }
}





public MetodoPagoEN()
{
        pedido = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN>();
}



public MetodoPagoEN(int idMetodo, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN> pedido, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN usuario, string tipo, bool esPredeterminado
                    )
{
        this.init (IdMetodo, pedido, usuario, tipo, esPredeterminado);
}


public MetodoPagoEN(MetodoPagoEN metodoPago)
{
        this.init (metodoPago.IdMetodo, metodoPago.Pedido, metodoPago.Usuario, metodoPago.Tipo, metodoPago.EsPredeterminado);
}

private void init (int idMetodo
                   , System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN> pedido, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN usuario, string tipo, bool esPredeterminado)
{
        this.IdMetodo = idMetodo;


        this.Pedido = pedido;

        this.Usuario = usuario;

        this.Tipo = tipo;

        this.EsPredeterminado = esPredeterminado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MetodoPagoEN t = obj as MetodoPagoEN;
        if (t == null)
                return false;
        if (IdMetodo.Equals (t.IdMetodo))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdMetodo.GetHashCode ();
        return hash;
}
}
}
