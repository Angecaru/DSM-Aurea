
using System;
using System.Collections.Generic;
using System.Text;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
public abstract class GenericUnitOfWorkRepository
{
protected IProductoRepository productorepository;
protected IPedidoRepository pedidorepository;
protected IDevolucionRepository devolucionrepository;
protected IDeTemporadaRepository detemporadarepository;
protected IUsuarioRepository usuariorepository;
protected IAdministradorRepository administradorrepository;
protected IMetodoPagoRepository metodopagorepository;
protected IDireccionEnvioRepository direccionenviorepository;
protected IFavoritoRepository favoritorepository;
protected IProductoCarritoRepository productocarritorepository;
protected IDetallePedidoRepository detallepedidorepository;
protected ICategoriaRepository categoriarepository;


public abstract IProductoRepository ProductoRepository {
        get;
}
public abstract IPedidoRepository PedidoRepository {
        get;
}
public abstract IDevolucionRepository DevolucionRepository {
        get;
}
public abstract IDeTemporadaRepository DeTemporadaRepository {
        get;
}
public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract IAdministradorRepository AdministradorRepository {
        get;
}
public abstract IMetodoPagoRepository MetodoPagoRepository {
        get;
}
public abstract IDireccionEnvioRepository DireccionEnvioRepository {
        get;
}
public abstract IFavoritoRepository FavoritoRepository {
        get;
}
public abstract IProductoCarritoRepository ProductoCarritoRepository {
        get;
}
public abstract IDetallePedidoRepository DetallePedidoRepository {
        get;
}
public abstract ICategoriaRepository CategoriaRepository {
        get;
}
}
}
