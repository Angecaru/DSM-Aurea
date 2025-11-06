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
 * Clase Pedido:
 *
 */

namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
public partial class PedidoRepository : BasicRepository, IPedidoRepository
{
public PedidoRepository() : base ()
{
}


public PedidoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


        public PedidoEN ReadOIDDefault(int idPedido)
        {
            PedidoEN pedidoEN = null;

            try
            {
                SessionInitializeTransaction();
                pedidoEN = (PedidoEN)session.Get(typeof(PedidoNH), idPedido);

                if (pedidoEN != null)
                {
                    // Forzar la carga de la colección antes de cerrar la sesión
                    NHibernateUtil.Initialize(pedidoEN.DetallePedido);
                }

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException(
                    "Error in ReadOIDDefault (PedidoRepository).", ex);
            }
            finally
            {
                SessionClose();
            }

            return pedidoEN;
        }


        public PedidoEN ReadOID(int idPedido)
        {
            PedidoEN pedidoEN = null;

            try
            {
                SessionInitializeTransaction();

                // Cargar pedido y detalles en una sola consulta (JOIN FETCH)
                pedidoEN = session.CreateCriteria(typeof(PedidoNH))
                                  .Add(Restrictions.Eq("IdPedido", idPedido))
                                  .SetFetchMode("DetallePedido", FetchMode.Join)
                                  .UniqueResult<PedidoEN>();

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException(
                    "Error en ReadOID de PedidoRepository.", ex);
            }
            finally
            {
                SessionClose();
            }

            return pedidoEN;
        }


        public System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size)
{
    System.Collections.Generic.IList<PedidoEN> result = null;
    try
    {
        SessionInitializeTransaction();
        if (size > 0)
            result = session.CreateCriteria(typeof(PedidoNH))
                            .SetFirstResult(first).SetMaxResults(size)
                            .List<PedidoEN>();
        else
            result = session.CreateCriteria(typeof(PedidoNH)).List<PedidoEN>();
        SessionCommit();
    }
    catch (Exception ex)
    {
        SessionRollBack();
        if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
            throw;
        else
            throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException("Error in PedidoRepository.", ex);
    }
    finally
    {
        SessionClose();
    }
    return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), pedido.IdPedido);





                pedidoNH.Fecha = pedido.Fecha;


                pedidoNH.Estado = pedido.Estado;


                pedidoNH.Total = pedido.Total;


                session.Update (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearPedido (PedidoEN pedido)
{
        PedidoNH pedidoNH = new PedidoNH (pedido);

        try
        {
                SessionInitializeTransaction ();
                if (pedido.Realizado_por != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .Realizado_por = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN), pedido.Realizado_por.IdUsuario);

                        pedidoNH.Realizado_por.Pedido
                                = pedidoNH;
                }
                if (pedido.Usa != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .Usa = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.MetodoPagoEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.MetodoPagoEN), pedido.Usa.IdMetodo);

                        pedidoNH.Usa.Pedido
                        .Add (pedidoNH);
                }
                if (pedido.Envia_a != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .Envia_a = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DireccionEnvioEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DireccionEnvioEN), pedido.Envia_a.IdDireccion);

                        pedidoNH.Envia_a.Pedido
                        .Add (pedidoNH);
                }
                if (pedido.DetallePedido != null) {
                        foreach (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DetallePedidoEN item in pedido.DetallePedido) {
                                item.Pedido = pedido;
                                DetallePedidoNH itemNH = new DetallePedidoNH (item);
                                session.Save (itemNH);
                        }
                }
                if (pedido.Relacionado_con != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .Relacionado_con = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DevolucionEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DevolucionEN), pedido.Relacionado_con.IdDevolucion);

                        pedidoNH.Relacionado_con.Pedido
                                = pedidoNH;
                }

                session.Save (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoNH.IdPedido;
}

public System.Collections.Generic.IList<PedidoEN> ConsultarPedido (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PedidoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                else
                        result = session.CreateCriteria (typeof(PedidoNH)).List<PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void ModificarPedido (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), pedido.IdPedido);

                pedidoNH.Fecha = pedido.Fecha;


                pedidoNH.Estado = pedido.Estado;


                pedidoNH.Total = pedido.Total;

                session.Update (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarPedido (int idPedido
                            )
{
        try
        {
                SessionInitializeTransaction ();
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), idPedido);
                session.Delete (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
