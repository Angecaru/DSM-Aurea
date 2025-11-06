using System;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Exceptions;
using Diagrama_aureaGen.ApplicationCore.Enumerated.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /*
     * Clase DevolucionCEN
     * Implementa las operaciones CRUD: crear, consultar, modificar, eliminar.
     */
    public partial class DevolucionCEN
    {
        private IDevolucionRepository _IDevolucionRepository;

        public DevolucionCEN(IDevolucionRepository repo)
        {
            this._IDevolucionRepository = repo;
        }

        public IDevolucionRepository get_IDevolucionRepository()
        {
            return this._IDevolucionRepository;
        }

        // ================================================================
        // CREATE
        // ================================================================
        public int crearDevolucion(int idDevolucion, DateTime fechaDevolucion, EstadoDevolucionEnum estado, string motivo, int idPedido, int idProducto)
        {
            DevolucionEN devolucionEN = new DevolucionEN();
            devolucionEN.IdDevolucion = idDevolucion;
            devolucionEN.FechaDevolucion = fechaDevolucion;
            devolucionEN.Estado = estado;
            devolucionEN.Motivo = motivo;
            devolucionEN.IdPedido = idPedido;
            devolucionEN.IdProducto = idProducto;

            int oid = _IDevolucionRepository.CrearDevolucion(devolucionEN);
            return oid;
        }

        // ================================================================
        // READ (consultar uno)
        // ================================================================
        public DevolucionEN consultarDevolucion(int idDevolucion)
        {
            return _IDevolucionRepository.ReadOIDDefault(idDevolucion);
        }

        // ================================================================
        // READ (consultar todos)
        // ================================================================
        public IList<DevolucionEN> consultarDevolucionTodos(int first, int size)
        {
            return _IDevolucionRepository.ReadAllDefault(first, size);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        public void modificarDevolucion(int idDevolucion, DateTime nuevaFecha, EstadoDevolucionEnum nuevoEstado, string nuevoMotivo, int idPedido, int idProducto)
        {
            DevolucionEN devolucion = _IDevolucionRepository.ReadOIDDefault(idDevolucion);
            if (devolucion == null)
                throw new ModelException("Devolución no encontrada");

            devolucion.FechaDevolucion = nuevaFecha;
            devolucion.Estado = nuevoEstado;
            devolucion.Motivo = nuevoMotivo;
            devolucion.IdPedido = idPedido;
            devolucion.IdProducto = idProducto;

            _IDevolucionRepository.ModificarDevolucion(devolucion);
        }

        // ================================================================
        // DELETE
        // ================================================================
        public void eliminarDevolucion(int idDevolucion)
        {
            DevolucionEN devolucion = _IDevolucionRepository.ReadOIDDefault(idDevolucion);
            if (devolucion == null)
                throw new ModelException("No existe la devolución");

            _IDevolucionRepository.EliminarDevolucion(idDevolucion);
        }
    }
}
