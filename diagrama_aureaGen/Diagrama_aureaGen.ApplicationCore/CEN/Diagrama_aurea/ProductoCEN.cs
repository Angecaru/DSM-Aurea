using System;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Exceptions;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /*
     * Clase ProductoCEN
     * Implementa las operaciones CRUD: crear, consultar, modificar, eliminar.
     */
    public partial class ProductoCEN
    {
        private IProductoRepository _IProductoRepository;

        public ProductoCEN(IProductoRepository repo)
        {
            this._IProductoRepository = repo;
        }

        public IProductoRepository get_IProductoRepository()
        {
            return this._IProductoRepository;
        }

        // ================================================================
        // CREATE
        // ================================================================
        public int crearProducto(int idProducto, int idCategoria, string codigoAdministrador,
                                 string nombre, string descripcion, float precio, int stock,
                                 string material, string imagen, string etiquetas,
                                 string emailCliente, DateTime fecha,
                                 string metodoPago, string datosTarjeta, string direccion)
        {
            ProductoEN producto = new ProductoEN
            {
                IdProducto = idProducto,
                Nombre = nombre,
                Descripcion = descripcion,
                Precio = precio,
                Stock = stock,
                Material = material,
                Imagen = imagen,
                Etiquetas = etiquetas,
                EmailCliente = emailCliente,
                Fecha = fecha,
                MetodoPago = metodoPago,
                DatosTarjeta = datosTarjeta,
                Direccion = direccion
            };

            // Relaciones opcionales
            if (idCategoria != -1)
            {
                producto.Categoria = new CategoriaEN { IdCategoria = idCategoria };
            }

            if (!string.IsNullOrEmpty(codigoAdministrador))
            {
                producto.Administrador = new AdministradorEN { CodigoEmpresa = codigoAdministrador };
            }

            int oid = _IProductoRepository.CrearProducto(producto);
            return oid;
        }

        // ================================================================
        // READ (consultar uno)
        // ================================================================
        public ProductoEN consultarProducto(int idProducto)
        {
            return _IProductoRepository.ReadOIDDefault(idProducto);
        }

        // ================================================================
        // READ (consultar todos)
        // ================================================================
        public IList<ProductoEN> consultarProductoTodos(int first, int size)
        {
            return _IProductoRepository.ReadAllDefault(first, size);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        public void modificarProducto(int idProducto, string nombre, string descripcion,
                                      float precio, int stock, string material, string imagen,
                                      string etiquetas, string emailCliente, DateTime fecha,
                                      string metodoPago, string datosTarjeta, string direccion)
        {
            ProductoEN producto = _IProductoRepository.ReadOIDDefault(idProducto);
            if (producto == null)
                throw new ModelException("Producto no encontrado");

            producto.Nombre = nombre;
            producto.Descripcion = descripcion;
            producto.Precio = precio;
            producto.Stock = stock;
            producto.Material = material;
            producto.Imagen = imagen;
            producto.Etiquetas = etiquetas;
            producto.EmailCliente = emailCliente;
            producto.Fecha = fecha;
            producto.MetodoPago = metodoPago;
            producto.DatosTarjeta = datosTarjeta;
            producto.Direccion = direccion;

            _IProductoRepository.ModificarProducto(producto);
        }

        // ================================================================
        // DELETE
        // ================================================================
        public void eliminarProducto(int idProducto)
        {
            ProductoEN producto = _IProductoRepository.ReadOIDDefault(idProducto);
            if (producto == null)
                throw new ModelException("No existe el producto");

            _IProductoRepository.EliminarProducto(idProducto);
        }
    }
}
