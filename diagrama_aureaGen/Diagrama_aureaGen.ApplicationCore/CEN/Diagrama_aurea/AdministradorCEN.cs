using System;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Exceptions;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /*
     * Clase AdministradorCEN
     * Implementa las operaciones CRUD: crear, consultar, modificar, eliminar.
     */
    public partial class AdministradorCEN
    {
        private IAdministradorRepository _IAdministradorRepository;

        public AdministradorCEN(IAdministradorRepository repo)
        {
            this._IAdministradorRepository = repo;
        }

        public IAdministradorRepository get_IAdministradorRepository()
        {
            return this._IAdministradorRepository;
        }

        // ================================================================
        // CREATE
        // ================================================================
        public string crearAdministrador(string p_codigoEmpresa)
        {
            AdministradorEN administradorEN = new AdministradorEN();
            administradorEN.CodigoEmpresa = p_codigoEmpresa;

            string oid = _IAdministradorRepository.CrearAdministrador(administradorEN);
            return oid;
        }

        // ================================================================
        // READ (consultar uno)
        // ================================================================
        public AdministradorEN consultarAdministrador(string codigoEmpresa)
        {
            return _IAdministradorRepository.ReadOIDDefault(codigoEmpresa);
        }

        // ================================================================
        // READ (consultar todos)
        // ================================================================
        public IList<AdministradorEN> consultarAdministradorTodos(int first, int size)
        {
            return _IAdministradorRepository.ReadAllDefault(first, size);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        public void modificarAdministrador(string p_codigoEmpresa, string nuevoCodigo)
        {
            AdministradorEN admin = _IAdministradorRepository.ReadOIDDefault(p_codigoEmpresa);
            if (admin == null)
                throw new ModelException("Administrador no encontrado");

            // Como la PK no puede cambiarse, creamos uno nuevo con el nuevo código
            AdministradorEN nuevo = new AdministradorEN();
            nuevo.CodigoEmpresa = nuevoCodigo;
            _IAdministradorRepository.CrearAdministrador(nuevo);

            // Y eliminamos el anterior
            _IAdministradorRepository.EliminarAdministrador(p_codigoEmpresa);
        }


        // ================================================================
        // DELETE
        // ================================================================
        public void eliminarAdministrador(string codigoEmpresa)
        {
            AdministradorEN admin = _IAdministradorRepository.ReadOIDDefault(codigoEmpresa);
            if (admin == null)
                throw new ModelException("No existe el administrador");

            _IAdministradorRepository.EliminarAdministrador(codigoEmpresa);
        }
    }
}
