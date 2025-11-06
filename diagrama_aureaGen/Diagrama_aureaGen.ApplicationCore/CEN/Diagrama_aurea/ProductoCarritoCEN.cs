using System;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Exceptions;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /*
     * Clase ProductoCarritoCEN
     * Implementa las operaciones CRUD: crear, consultar, modificar, eliminar.
     */
    public partial class ProductoCarritoCEN
    {
        private IProductoCarritoRepository _IProductoCarritoRepository;

        public ProductoCarritoCEN(IProductoCarritoRepository repo)
        {
            this._IProductoCarritoRepository = repo;
        }

        public IProductoCarritoRepository get_IProductoCarritoRepository()
        {
            return this._IProductoCarritoRepository;
        }

        // ================================================================
        // CREATE
        // ================================================================
        public int crearProductoCarrito(int idCarritoProducto, int idProducto, int cantidad, float subtotal)
        {
            ProductoCarritoEN productoCarrito = new ProductoCarritoEN();
            productoCarrito.IdCarritoProducto = idCarritoProducto;
            productoCarrito.Cantidad = cantidad;
            productoCarrito.Subtotal = subtotal;

            // Relación con Producto
            if (idProducto != -1)
            {
                productoCarrito.Añadido_a = new ProductoEN();
                productoCarrito.Añadido_a.IdProducto = idProducto;
            }

            int oid = _IProductoCarritoRepository.CrearProductoCarrito(productoCarrito);
            return oid;
        }

        // ================================================================
        // READ (consultar uno)
        // ================================================================
        public ProductoCarritoEN consultarProductoCarrito(int idCarritoProducto)
        {
            return _IProductoCarritoRepository.ReadOIDDefault(idCarritoProducto);
        }

        // ================================================================
        // READ (consultar todos)
        // ================================================================
        public IList<ProductoCarritoEN> consultarProductoCarritoTodos(int first, int size)
        {
            return _IProductoCarritoRepository.ReadAllDefault(first, size);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        public void modificarProductoCarrito(int idCarritoProducto, int cantidad, float subtotal)
        {
            ProductoCarritoEN productoCarrito = _IProductoCarritoRepository.ReadOIDDefault(idCarritoProducto);
            if (productoCarrito == null)
                throw new ModelException("Producto del carrito no encontrado");

            productoCarrito.Cantidad = cantidad;
            productoCarrito.Subtotal = subtotal;

            _IProductoCarritoRepository.ModificarProductoCarrito(productoCarrito);
        }

        // ================================================================
        // DELETE
        // ================================================================
        public void eliminarProductoCarrito(int idCarritoProducto)
        {
            ProductoCarritoEN productoCarrito = _IProductoCarritoRepository.ReadOIDDefault(idCarritoProducto);
            if (productoCarrito == null)
                throw new ModelException("No existe el producto en el carrito");

            _IProductoCarritoRepository.EliminarProductoCarrito(idCarritoProducto);
        }
    }
}
