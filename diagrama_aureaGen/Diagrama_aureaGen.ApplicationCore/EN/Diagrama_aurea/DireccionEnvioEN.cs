
using System;
// Definición clase DireccionEnvioEN
namespace Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea
{
public partial class DireccionEnvioEN
{
/**
 *	Atributo idDireccion
 */
private int idDireccion;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN> pedido;



/**
 *	Atributo usuario
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN usuario;



/**
 *	Atributo calle
 */
private string calle;



/**
 *	Atributo ciudad
 */
private string ciudad;



/**
 *	Atributo codigoPostal
 */
private string codigoPostal;



/**
 *	Atributo pais
 */
private string pais;



/**
 *	Atributo esPredeterminada
 */
private bool esPredeterminada;






public virtual int IdDireccion {
        get { return idDireccion; } set { idDireccion = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual string Calle {
        get { return calle; } set { calle = value;  }
}



public virtual string Ciudad {
        get { return ciudad; } set { ciudad = value;  }
}



public virtual string CodigoPostal {
        get { return codigoPostal; } set { codigoPostal = value;  }
}



public virtual string Pais {
        get { return pais; } set { pais = value;  }
}



public virtual bool EsPredeterminada {
        get { return esPredeterminada; } set { esPredeterminada = value;  }
}





public DireccionEnvioEN()
{
        pedido = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN>();
}



public DireccionEnvioEN(int idDireccion, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN> pedido, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN usuario, string calle, string ciudad, string codigoPostal, string pais, bool esPredeterminada
                        )
{
        this.init (IdDireccion, pedido, usuario, calle, ciudad, codigoPostal, pais, esPredeterminada);
}


public DireccionEnvioEN(DireccionEnvioEN direccionEnvio)
{
        this.init (direccionEnvio.IdDireccion, direccionEnvio.Pedido, direccionEnvio.Usuario, direccionEnvio.Calle, direccionEnvio.Ciudad, direccionEnvio.CodigoPostal, direccionEnvio.Pais, direccionEnvio.EsPredeterminada);
}

private void init (int idDireccion
                   , System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN> pedido, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN usuario, string calle, string ciudad, string codigoPostal, string pais, bool esPredeterminada)
{
        this.IdDireccion = idDireccion;


        this.Pedido = pedido;

        this.Usuario = usuario;

        this.Calle = calle;

        this.Ciudad = ciudad;

        this.CodigoPostal = codigoPostal;

        this.Pais = pais;

        this.EsPredeterminada = esPredeterminada;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DireccionEnvioEN t = obj as DireccionEnvioEN;
        if (t == null)
                return false;
        if (IdDireccion.Equals (t.IdDireccion))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdDireccion.GetHashCode ();
        return hash;
}
}
}
