

using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea;
using Diagrama_aureaGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diagrama_aureaGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IProductoRepository ProductoRepository {
        get
        {
                this.productorepository = new ProductoRepository ();
                this.productorepository.setSessionCP (session);
                return this.productorepository;
        }
}

public override IPedidoRepository PedidoRepository {
        get
        {
                this.pedidorepository = new PedidoRepository ();
                this.pedidorepository.setSessionCP (session);
                return this.pedidorepository;
        }
}

public override IDevolucionRepository DevolucionRepository {
        get
        {
                this.devolucionrepository = new DevolucionRepository ();
                this.devolucionrepository.setSessionCP (session);
                return this.devolucionrepository;
        }
}

public override IDeTemporadaRepository DeTemporadaRepository {
        get
        {
                this.detemporadarepository = new DeTemporadaRepository ();
                this.detemporadarepository.setSessionCP (session);
                return this.detemporadarepository;
        }
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IAdministradorRepository AdministradorRepository {
        get
        {
                this.administradorrepository = new AdministradorRepository ();
                this.administradorrepository.setSessionCP (session);
                return this.administradorrepository;
        }
}

public override IMetodoPagoRepository MetodoPagoRepository {
        get
        {
                this.metodopagorepository = new MetodoPagoRepository ();
                this.metodopagorepository.setSessionCP (session);
                return this.metodopagorepository;
        }
}

public override IDireccionEnvioRepository DireccionEnvioRepository {
        get
        {
                this.direccionenviorepository = new DireccionEnvioRepository ();
                this.direccionenviorepository.setSessionCP (session);
                return this.direccionenviorepository;
        }
}

public override IFavoritoRepository FavoritoRepository {
        get
        {
                this.favoritorepository = new FavoritoRepository ();
                this.favoritorepository.setSessionCP (session);
                return this.favoritorepository;
        }
}

public override IProductoCarritoRepository ProductoCarritoRepository {
        get
        {
                this.productocarritorepository = new ProductoCarritoRepository ();
                this.productocarritorepository.setSessionCP (session);
                return this.productocarritorepository;
        }
}

public override IDetallePedidoRepository DetallePedidoRepository {
        get
        {
                this.detallepedidorepository = new DetallePedidoRepository ();
                this.detallepedidorepository.setSessionCP (session);
                return this.detallepedidorepository;
        }
}

public override ICategoriaRepository CategoriaRepository {
        get
        {
                this.categoriarepository = new CategoriaRepository ();
                this.categoriarepository.setSessionCP (session);
                return this.categoriarepository;
        }
}
}
}

