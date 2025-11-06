
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
 * Clase DetallePedido:
 *
 */

namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
public partial class DetallePedidoRepository : BasicRepository, IDetallePedidoRepository
{
public DetallePedidoRepository() : base ()
{
}


public DetallePedidoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public DetallePedidoEN ReadOIDDefault (int idDetalle
                                       )
{
        DetallePedidoEN detallePedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                detallePedidoEN = (DetallePedidoEN)session.Get (typeof(DetallePedidoNH), idDetalle);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return detallePedidoEN;
}

public System.Collections.Generic.IList<DetallePedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DetallePedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DetallePedidoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<DetallePedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(DetallePedidoNH)).List<DetallePedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DetallePedidoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DetallePedidoEN detallePedido)
{
        try
        {
                SessionInitializeTransaction ();
                DetallePedidoNH detallePedidoNH = (DetallePedidoNH)session.Load (typeof(DetallePedidoNH), detallePedido.IdDetalle);



                detallePedidoNH.Cantidad = detallePedido.Cantidad;


                detallePedidoNH.PrecioUnitario = detallePedido.PrecioUnitario;


                detallePedidoNH.Subtotal = detallePedido.Subtotal;

                session.Update (detallePedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DetallePedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearDetallePedido (DetallePedidoEN detallePedido)
{
        DetallePedidoNH detallePedidoNH = new DetallePedidoNH (detallePedido);

        try
        {
                SessionInitializeTransaction ();
                if (detallePedido.Incluido_en != null) {
                        // Argumento OID y no colección.
                        detallePedidoNH
                        .Incluido_en = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN), detallePedido.Incluido_en.IdProducto);

                        detallePedidoNH.Incluido_en.Incluido_en
                        .Add (detallePedidoNH);
                }
                if (detallePedido.Pedido != null) {
                        // p_pedido
                        detallePedido.Pedido.DetallePedido.Add (detallePedidoNH);
                        session.Save (detallePedidoNH.Pedido);
                }

                session.Save (detallePedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DetallePedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return detallePedidoNH.IdDetalle;
}

public void ModificarDetallePedido (DetallePedidoEN detallePedido)
{
        try
        {
                SessionInitializeTransaction ();
                DetallePedidoNH detallePedidoNH = (DetallePedidoNH)session.Load (typeof(DetallePedidoNH), detallePedido.IdDetalle);

                detallePedidoNH.Cantidad = detallePedido.Cantidad;


                detallePedidoNH.PrecioUnitario = detallePedido.PrecioUnitario;


                detallePedidoNH.Subtotal = detallePedido.Subtotal;

                session.Update (detallePedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DetallePedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarDetallePedido (int idDetalle
                                   )
{
        try
        {
                SessionInitializeTransaction ();
                DetallePedidoNH detallePedidoNH = (DetallePedidoNH)session.Load (typeof(DetallePedidoNH), idDetalle);
                session.Delete (detallePedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DetallePedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: DetallePedidoEN
public DetallePedidoEN ReadOID (int idDetalle
                                )
{
        DetallePedidoEN detallePedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                detallePedidoEN = (DetallePedidoEN)session.Get (typeof(DetallePedidoNH), idDetalle);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return detallePedidoEN;
}

public System.Collections.Generic.IList<DetallePedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<DetallePedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(DetallePedidoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<DetallePedidoEN>();
                else
                        result = session.CreateCriteria (typeof(DetallePedidoNH)).List<DetallePedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DetallePedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
