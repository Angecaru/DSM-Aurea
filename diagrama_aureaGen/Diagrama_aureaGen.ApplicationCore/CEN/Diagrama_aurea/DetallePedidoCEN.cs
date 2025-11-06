using System;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Exceptions;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /*
     * Clase DetallePedidoCEN
     * Implementa las operaciones CRUD: crear, consultar, modificar, eliminar.
     */
    public partial class DetallePedidoCEN
    {
        private IDetallePedidoRepository _IDetallePedidoRepository;

        public DetallePedidoCEN(IDetallePedidoRepository repo)
        {
            this._IDetallePedidoRepository = repo;
        }

        public IDetallePedidoRepository get_IDetallePedidoRepository()
        {
            return this._IDetallePedidoRepository;
        }

        // ================================================================
        // CREATE
        // ================================================================
        public int crearDetallePedido(int idDetalle, int idProducto, PedidoEN pedido, int cantidad, float precioUnitario, float subtotal)
        {
            DetallePedidoEN detalle = new DetallePedidoEN();
            detalle.IdDetalle = idDetalle;
            detalle.Cantidad = cantidad;
            detalle.PrecioUnitario = precioUnitario;
            detalle.Subtotal = subtotal;

            // Relación con Producto
            if (idProducto != -1)
            {
                detalle.Incluido_en = new ProductoEN();
                detalle.Incluido_en.IdProducto = idProducto;
            }

            // Relación con Pedido
            detalle.Pedido = pedido;

            int oid = _IDetallePedidoRepository.CrearDetallePedido(detalle);
            return oid;
        }

        // ================================================================
        // READ (consultar uno)
        // ================================================================
        public DetallePedidoEN readOID(int idDetalle)
        {
            return _IDetallePedidoRepository.ReadOID(idDetalle);
        }

        // ================================================================
        // READ (consultar todos)
        // ================================================================
        public IList<DetallePedidoEN> readAll(int first, int size)
        {
            return _IDetallePedidoRepository.ReadAll(first, size);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        public void modificarDetallePedido(int idDetalle, int cantidad, float precioUnitario, float subtotal)
        {
            DetallePedidoEN detalle = _IDetallePedidoRepository.ReadOID(idDetalle);
            if (detalle == null)
                throw new ModelException("Detalle de pedido no encontrado");

            detalle.Cantidad = cantidad;
            detalle.PrecioUnitario = precioUnitario;
            detalle.Subtotal = subtotal;

            _IDetallePedidoRepository.ModificarDetallePedido(detalle);
        }

        // ================================================================
        // DELETE
        // ================================================================
        public void eliminarDetallePedido(int idDetalle)
        {
            DetallePedidoEN detalle = _IDetallePedidoRepository.ReadOID(idDetalle);
            if (detalle == null)
                throw new ModelException("No existe el detalle de pedido");

            _IDetallePedidoRepository.EliminarDetallePedido(idDetalle);
        }
    }
}
