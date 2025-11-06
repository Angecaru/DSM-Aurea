using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Cfg;

using Diagrama_aureaGen.Infraestructure.EN.Diagrama_aurea;


namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
public static class NHibernateHelper
{
private static ISessionFactory _sessionFactory;

private static ISessionFactory SessionFactory
{
        get
        {
                if (_sessionFactory == null) {
                        var configuration = new Configuration ();
                        configuration.Configure ();
                        configuration.AddAssembly (typeof(ProductoNH).Assembly);
                        _sessionFactory = configuration.BuildSessionFactory ();
                }

                return _sessionFactory;
        }
}

public static ISession OpenSession ()
{
        return SessionFactory.OpenSession ();
}
}
}
