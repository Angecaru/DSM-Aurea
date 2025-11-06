
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
 * Clase Categoria:
 *
 */

namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
public partial class CategoriaRepository : BasicRepository, ICategoriaRepository
{
public CategoriaRepository() : base ()
{
}


public CategoriaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public CategoriaEN ReadOIDDefault (int idCategoria
                                   )
{
        CategoriaEN categoriaEN = null;

        try
        {
                SessionInitializeTransaction ();
                categoriaEN = (CategoriaEN)session.Get (typeof(CategoriaNH), idCategoria);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return categoriaEN;
}

public System.Collections.Generic.IList<CategoriaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CategoriaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CategoriaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<CategoriaEN>();
                        else
                                result = session.CreateCriteria (typeof(CategoriaNH)).List<CategoriaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in CategoriaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CategoriaEN categoria)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaNH categoriaNH = (CategoriaNH)session.Load (typeof(CategoriaNH), categoria.IdCategoria);


                categoriaNH.NombreCategoria = categoria.NombreCategoria;


                categoriaNH.Descripcion = categoria.Descripcion;

                session.Update (categoriaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in CategoriaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public System.Collections.Generic.IList<CategoriaEN> ConsultarCategoria (int first, int size)
{
        System.Collections.Generic.IList<CategoriaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CategoriaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<CategoriaEN>();
                else
                        result = session.CreateCriteria (typeof(CategoriaNH)).List<CategoriaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in CategoriaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public int CrearCategoria (CategoriaEN categoria)
{
        CategoriaNH categoriaNH = new CategoriaNH (categoria);

        try
        {
                SessionInitializeTransaction ();

                session.Save (categoriaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in CategoriaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return categoriaNH.IdCategoria;
}

public void ModificarCategoria (CategoriaEN categoria)
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaNH categoriaNH = (CategoriaNH)session.Load (typeof(CategoriaNH), categoria.IdCategoria);

                categoriaNH.NombreCategoria = categoria.NombreCategoria;


                categoriaNH.Descripcion = categoria.Descripcion;

                session.Update (categoriaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in CategoriaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarCategoria (int idCategoria
                               )
{
        try
        {
                SessionInitializeTransaction ();
                CategoriaNH categoriaNH = (CategoriaNH)session.Load (typeof(CategoriaNH), idCategoria);
                session.Delete (categoriaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in CategoriaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
