
using System;
// Definición clase UsuarioEN
namespace Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea
{
public partial class UsuarioEN
{
/**
 *	Atributo idUsuario
 */
private int idUsuario;



/**
 *	Atributo pedido
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN pedido;



/**
 *	Atributo tiene
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DireccionEnvioEN> tiene;



/**
 *	Atributo guarda
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.FavoritoEN> guarda;



/**
 *	Atributo posee
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.MetodoPagoEN> posee;



/**
 *	Atributo nombreUsuario
 */
private string nombreUsuario;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo dni
 */
private string dni;



/**
 *	Atributo fechaNacimiento
 */
private Nullable<DateTime> fechaNacimiento;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo contraseña
 */
private string contraseña;



/**
 *	Atributo fechaRegistro
 */
private Nullable<DateTime> fechaRegistro;






public virtual int IdUsuario {
        get { return idUsuario; } set { idUsuario = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DireccionEnvioEN> Tiene {
        get { return tiene; } set { tiene = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.FavoritoEN> Guarda {
        get { return guarda; } set { guarda = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.MetodoPagoEN> Posee {
        get { return posee; } set { posee = value;  }
}



public virtual string NombreUsuario {
        get { return nombreUsuario; } set { nombreUsuario = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Dni {
        get { return dni; } set { dni = value;  }
}



public virtual Nullable<DateTime> FechaNacimiento {
        get { return fechaNacimiento; } set { fechaNacimiento = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Contraseña {
        get { return contraseña; } set { contraseña = value;  }
}



public virtual Nullable<DateTime> FechaRegistro {
        get { return fechaRegistro; } set { fechaRegistro = value;  }
}





public UsuarioEN()
{
        tiene = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DireccionEnvioEN>();
        guarda = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.FavoritoEN>();
        posee = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.MetodoPagoEN>();
}



public UsuarioEN(int idUsuario, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN pedido, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DireccionEnvioEN> tiene, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.FavoritoEN> guarda, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.MetodoPagoEN> posee, string nombreUsuario, string apellidos, string dni, Nullable<DateTime> fechaNacimiento, string email, string contraseña, Nullable<DateTime> fechaRegistro
                 )
{
        this.init (IdUsuario, pedido, tiene, guarda, posee, nombreUsuario, apellidos, dni, fechaNacimiento, email, contraseña, fechaRegistro);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.IdUsuario, usuario.Pedido, usuario.Tiene, usuario.Guarda, usuario.Posee, usuario.NombreUsuario, usuario.Apellidos, usuario.Dni, usuario.FechaNacimiento, usuario.Email, usuario.Contraseña, usuario.FechaRegistro);
}

private void init (int idUsuario
                   , Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN pedido, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DireccionEnvioEN> tiene, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.FavoritoEN> guarda, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.MetodoPagoEN> posee, string nombreUsuario, string apellidos, string dni, Nullable<DateTime> fechaNacimiento, string email, string contraseña, Nullable<DateTime> fechaRegistro)
{
        this.IdUsuario = idUsuario;


        this.Pedido = pedido;

        this.Tiene = tiene;

        this.Guarda = guarda;

        this.Posee = posee;

        this.NombreUsuario = nombreUsuario;

        this.Apellidos = apellidos;

        this.Dni = dni;

        this.FechaNacimiento = fechaNacimiento;

        this.Email = email;

        this.Contraseña = contraseña;

        this.FechaRegistro = fechaRegistro;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (IdUsuario.Equals (t.IdUsuario))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdUsuario.GetHashCode ();
        return hash;
}
}
}
