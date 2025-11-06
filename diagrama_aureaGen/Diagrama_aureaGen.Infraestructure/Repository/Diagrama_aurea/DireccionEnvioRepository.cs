
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
 * Clase DireccionEnvio:
 *
 */

namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
public partial class DireccionEnvioRepository : BasicRepository, IDireccionEnvioRepository
{
public DireccionEnvioRepository() : base ()
{
}


public DireccionEnvioRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public DireccionEnvioEN ReadOIDDefault (int idDireccion
                                        )
{
        DireccionEnvioEN direccionEnvioEN = null;

        try
        {
                SessionInitializeTransaction ();
                direccionEnvioEN = (DireccionEnvioEN)session.Get (typeof(DireccionEnvioNH), idDireccion);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return direccionEnvioEN;
}

public System.Collections.Generic.IList<DireccionEnvioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DireccionEnvioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DireccionEnvioNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<DireccionEnvioEN>();
                        else
                                result = session.CreateCriteria (typeof(DireccionEnvioNH)).List<DireccionEnvioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionEnvioRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DireccionEnvioEN direccionEnvio)
{
        try
        {
                SessionInitializeTransaction ();
                DireccionEnvioNH direccionEnvioNH = (DireccionEnvioNH)session.Load (typeof(DireccionEnvioNH), direccionEnvio.IdDireccion);



                direccionEnvioNH.Calle = direccionEnvio.Calle;


                direccionEnvioNH.Ciudad = direccionEnvio.Ciudad;


                direccionEnvioNH.CodigoPostal = direccionEnvio.CodigoPostal;


                direccionEnvioNH.Pais = direccionEnvio.Pais;


                direccionEnvioNH.EsPredeterminada = direccionEnvio.EsPredeterminada;

                session.Update (direccionEnvioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public System.Collections.Generic.IList<DireccionEnvioEN> ConsultarDireccion (int first, int size)
{
        System.Collections.Generic.IList<DireccionEnvioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(DireccionEnvioNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<DireccionEnvioEN>();
                else
                        result = session.CreateCriteria (typeof(DireccionEnvioNH)).List<DireccionEnvioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int CrearDireccion (DireccionEnvioEN direccionEnvio)
{
        DireccionEnvioNH direccionEnvioNH = new DireccionEnvioNH (direccionEnvio);

        try
        {
                SessionInitializeTransaction ();
                if (direccionEnvio.Usuario != null) {
                        // Argumento OID y no colección.
                        direccionEnvioNH
                        .Usuario = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN), direccionEnvio.Usuario.IdUsuario);

                        direccionEnvioNH.Usuario.Tiene
                        .Add (direccionEnvioNH);
                }

                session.Save (direccionEnvioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return direccionEnvioNH.IdDireccion;
}

public void ModificarDireccion (DireccionEnvioEN direccionEnvio)
{
        try
        {
                SessionInitializeTransaction ();
                DireccionEnvioNH direccionEnvioNH = (DireccionEnvioNH)session.Load (typeof(DireccionEnvioNH), direccionEnvio.IdDireccion);

                direccionEnvioNH.Calle = direccionEnvio.Calle;


                direccionEnvioNH.Ciudad = direccionEnvio.Ciudad;


                direccionEnvioNH.CodigoPostal = direccionEnvio.CodigoPostal;


                direccionEnvioNH.Pais = direccionEnvio.Pais;


                direccionEnvioNH.EsPredeterminada = direccionEnvio.EsPredeterminada;

                session.Update (direccionEnvioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarDireccion (int idDireccion
                               )
{
        try
        {
                SessionInitializeTransaction ();
                DireccionEnvioNH direccionEnvioNH = (DireccionEnvioNH)session.Load (typeof(DireccionEnvioNH), idDireccion);
                session.Delete (direccionEnvioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
