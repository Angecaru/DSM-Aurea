
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
 * Clase Favorito:
 *
 */

namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
public partial class FavoritoRepository : BasicRepository, IFavoritoRepository
{
public FavoritoRepository() : base ()
{
}


public FavoritoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public FavoritoEN ReadOIDDefault (int idFavorito
                                  )
{
        FavoritoEN favoritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritoEN = (FavoritoEN)session.Get (typeof(FavoritoNH), idFavorito);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritoEN;
}

public System.Collections.Generic.IList<FavoritoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FavoritoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FavoritoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<FavoritoEN>();
                        else
                                result = session.CreateCriteria (typeof(FavoritoNH)).List<FavoritoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FavoritoEN favorito)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoNH favoritoNH = (FavoritoNH)session.Load (typeof(FavoritoNH), favorito.IdFavorito);


                session.Update (favoritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearFavorito (FavoritoEN favorito)
{
        FavoritoNH favoritoNH = new FavoritoNH (favorito);

        try
        {
                SessionInitializeTransaction ();
                if (favorito.Usuario != null) {
                        // Argumento OID y no colección.
                        favoritoNH
                        .Usuario = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN), favorito.Usuario.IdUsuario);

                        favoritoNH.Usuario.Guarda
                        .Add (favoritoNH);
                }

                session.Save (favoritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritoNH.IdFavorito;
}

public System.Collections.Generic.IList<FavoritoEN> ConsultarFavorito (int first, int size)
{
        System.Collections.Generic.IList<FavoritoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(FavoritoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<FavoritoEN>();
                else
                        result = session.CreateCriteria (typeof(FavoritoNH)).List<FavoritoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void EliminarFavorito (int idFavorito
                              )
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoNH favoritoNH = (FavoritoNH)session.Load (typeof(FavoritoNH), idFavorito);
                session.Delete (favoritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void ModificarFavorito(FavoritoEN favorito)
{
    try
    {
        SessionInitializeTransaction();

        FavoritoNH favoritoNH = (FavoritoNH)session.Load(typeof(FavoritoNH), favorito.IdFavorito);

        // Si quisieras actualizar relaciones con Usuario:
        if (favorito.Usuario != null)
        {
            favoritoNH.Usuario = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN)
                session.Load(typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN), favorito.Usuario.IdUsuario);
        }

        // En este caso no hay más atributos que modificar (solo relaciones)
        session.Update(favoritoNH);
        SessionCommit();
    }
    catch (Exception ex)
    {
        SessionRollBack();
        if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
            throw;
        else
            throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException("Error in FavoritoRepository.", ex);
    }
    finally
    {
        SessionClose();
    }
}

 }

}
