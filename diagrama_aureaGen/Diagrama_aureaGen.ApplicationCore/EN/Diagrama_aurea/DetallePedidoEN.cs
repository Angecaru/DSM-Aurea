
using System;
// Definición clase DetallePedidoEN
namespace Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea
{
public partial class DetallePedidoEN
{
/**
 *	Atributo idDetalle
 */
private int idDetalle;



/**
 *	Atributo incluido_en
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN incluido_en;



/**
 *	Atributo pedido
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN pedido;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo precioUnitario
 */
private float precioUnitario;



/**
 *	Atributo subtotal
 */
private float subtotal;






public virtual int IdDetalle {
        get { return idDetalle; } set { idDetalle = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN Incluido_en {
        get { return incluido_en; } set { incluido_en = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual float PrecioUnitario {
        get { return precioUnitario; } set { precioUnitario = value;  }
}



public virtual float Subtotal {
        get { return subtotal; } set { subtotal = value;  }
}





public DetallePedidoEN()
{
}



public DetallePedidoEN(int idDetalle, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN incluido_en, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN pedido, int cantidad, float precioUnitario, float subtotal
                       )
{
        this.init (IdDetalle, incluido_en, pedido, cantidad, precioUnitario, subtotal);
}


public DetallePedidoEN(DetallePedidoEN detallePedido)
{
        this.init (detallePedido.IdDetalle, detallePedido.Incluido_en, detallePedido.Pedido, detallePedido.Cantidad, detallePedido.PrecioUnitario, detallePedido.Subtotal);
}

private void init (int idDetalle
                   , Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN incluido_en, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN pedido, int cantidad, float precioUnitario, float subtotal)
{
        this.IdDetalle = idDetalle;


        this.Incluido_en = incluido_en;

        this.Pedido = pedido;

        this.Cantidad = cantidad;

        this.PrecioUnitario = precioUnitario;

        this.Subtotal = subtotal;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DetallePedidoEN t = obj as DetallePedidoEN;
        if (t == null)
                return false;
        if (IdDetalle.Equals (t.IdDetalle))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdDetalle.GetHashCode ();
        return hash;
}
}
}
