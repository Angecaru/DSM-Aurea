using System;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Exceptions;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /*
     * Clase MetodoPagoCEN
     * Implementa las operaciones CRUD: crear, consultar, modificar, eliminar.
     */
    public partial class MetodoPagoCEN
    {
        private IMetodoPagoRepository _IMetodoPagoRepository;

        public MetodoPagoCEN(IMetodoPagoRepository repo)
        {
            this._IMetodoPagoRepository = repo;
        }

        public IMetodoPagoRepository get_IMetodoPagoRepository()
        {
            return this._IMetodoPagoRepository;
        }

        // ================================================================
        // CREATE
        // ================================================================
        public int crearMetodoPago(int idMetodo, string tipo, bool esPredeterminado, int idUsuario = -1)
        {
            MetodoPagoEN metodo = new MetodoPagoEN();
            metodo.IdMetodo = idMetodo;
            metodo.Tipo = tipo;
            metodo.EsPredeterminado = esPredeterminado;

            // Relación con Usuario (opcional)
            if (idUsuario != -1)
            {
                metodo.Usuario = new UsuarioEN();
                metodo.Usuario.IdUsuario = idUsuario;
            }

            int oid = _IMetodoPagoRepository.CrearMetodoPago(metodo);
            return oid;
        }

        // ================================================================
        // READ (consultar uno)
        // ================================================================
        public MetodoPagoEN consultarMetodoPago(int idMetodo)
        {
            return _IMetodoPagoRepository.ReadOIDDefault(idMetodo);
        }

        // ================================================================
        // READ (consultar todos)
        // ================================================================
        public IList<MetodoPagoEN> consultarMetodoPagoTodos(int first, int size)
        {
            return _IMetodoPagoRepository.ReadAllDefault(first, size);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        public void modificarMetodoPago(int idMetodo, string nuevoTipo, bool esPredeterminado)
        {
            MetodoPagoEN metodo = _IMetodoPagoRepository.ReadOIDDefault(idMetodo);
            if (metodo == null)
                throw new ModelException("Método de pago no encontrado");

            metodo.Tipo = nuevoTipo;
            metodo.EsPredeterminado = esPredeterminado;

            _IMetodoPagoRepository.ModificarMetodoPago(metodo);
        }

        // ================================================================
        // DELETE
        // ================================================================
        public void eliminarMetodoPago(int idMetodo)
        {
            MetodoPagoEN metodo = _IMetodoPagoRepository.ReadOIDDefault(idMetodo);
            if (metodo == null)
                throw new ModelException("No existe el método de pago");

            _IMetodoPagoRepository.EliminarMetodoPago(idMetodo);
        }
    }
}
