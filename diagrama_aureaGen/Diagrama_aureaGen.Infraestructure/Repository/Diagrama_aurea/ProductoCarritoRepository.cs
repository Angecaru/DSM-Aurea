
using System;
using System.Text;
using Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Exceptions;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;
using Diagrama_aureaGen.Infraestructure.EN.Diagrama_aurea;


/*
 * Clase ProductoCarrito:
 *
 */

namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
public partial class ProductoCarritoRepository : BasicRepository, IProductoCarritoRepository
{
public ProductoCarritoRepository() : base ()
{
}


public ProductoCarritoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ProductoCarritoEN ReadOIDDefault (int idCarritoProducto
                                         )
{
        ProductoCarritoEN productoCarritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoCarritoEN = (ProductoCarritoEN)session.Get (typeof(ProductoCarritoNH), idCarritoProducto);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return productoCarritoEN;
}

public System.Collections.Generic.IList<ProductoCarritoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProductoCarritoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProductoCarritoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProductoCarritoEN>();
                        else
                                result = session.CreateCriteria (typeof(ProductoCarritoNH)).List<ProductoCarritoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoCarritoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProductoCarritoEN productoCarrito)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoCarritoNH productoCarritoNH = (ProductoCarritoNH)session.Load (typeof(ProductoCarritoNH), productoCarrito.IdCarritoProducto);


                productoCarritoNH.Cantidad = productoCarrito.Cantidad;


                productoCarritoNH.Subtotal = productoCarrito.Subtotal;

                session.Update (productoCarritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoCarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearProductoCarrito (ProductoCarritoEN productoCarrito)
{
        ProductoCarritoNH productoCarritoNH = new ProductoCarritoNH (productoCarrito);

        try
        {
                SessionInitializeTransaction ();
                if (productoCarrito.Añadido_a != null) {
                        // Argumento OID y no colección.
                        productoCarritoNH
                        .Añadido_a = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN), productoCarrito.Añadido_a.IdProducto);

                        productoCarritoNH.Añadido_a.ProductoCarrito
                        .Add (productoCarritoNH);
                }

                session.Save (productoCarritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoCarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoCarritoNH.IdCarritoProducto;
}

public void ModificarProductoCarrito (ProductoCarritoEN productoCarrito)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoCarritoNH productoCarritoNH = (ProductoCarritoNH)session.Load (typeof(ProductoCarritoNH), productoCarrito.IdCarritoProducto);

                productoCarritoNH.Cantidad = productoCarrito.Cantidad;


                productoCarritoNH.Subtotal = productoCarrito.Subtotal;

                session.Update (productoCarritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoCarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarProductoCarrito (int idCarritoProducto
                                     )
{
        try
        {
                SessionInitializeTransaction ();
                ProductoCarritoNH productoCarritoNH = (ProductoCarritoNH)session.Load (typeof(ProductoCarritoNH), idCarritoProducto);
                session.Delete (productoCarritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoCarritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
