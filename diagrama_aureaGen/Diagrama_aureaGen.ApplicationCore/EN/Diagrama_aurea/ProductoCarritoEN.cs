
using System;
// Definición clase ProductoCarritoEN
namespace Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea
{
public partial class ProductoCarritoEN
{
/**
 *	Atributo idCarritoProducto
 */
private int idCarritoProducto;



/**
 *	Atributo añadido_a
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN añadido_a;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo subtotal
 */
private float subtotal;






public virtual int IdCarritoProducto {
        get { return idCarritoProducto; } set { idCarritoProducto = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN Añadido_a {
        get { return añadido_a; } set { añadido_a = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual float Subtotal {
        get { return subtotal; } set { subtotal = value;  }
}





public ProductoCarritoEN()
{
}



public ProductoCarritoEN(int idCarritoProducto, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN añadido_a, int cantidad, float subtotal
                         )
{
        this.init (IdCarritoProducto, añadido_a, cantidad, subtotal);
}


public ProductoCarritoEN(ProductoCarritoEN productoCarrito)
{
        this.init (productoCarrito.IdCarritoProducto, productoCarrito.Añadido_a, productoCarrito.Cantidad, productoCarrito.Subtotal);
}

private void init (int idCarritoProducto
                   , Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN añadido_a, int cantidad, float subtotal)
{
        this.IdCarritoProducto = idCarritoProducto;


        this.Añadido_a = añadido_a;

        this.Cantidad = cantidad;

        this.Subtotal = subtotal;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoCarritoEN t = obj as ProductoCarritoEN;
        if (t == null)
                return false;
        if (IdCarritoProducto.Equals (t.IdCarritoProducto))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdCarritoProducto.GetHashCode ();
        return hash;
}
}
}
