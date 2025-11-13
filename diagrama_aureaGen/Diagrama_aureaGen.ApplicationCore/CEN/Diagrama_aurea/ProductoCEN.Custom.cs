using System;
using System.Text;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.Exceptions;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /// <summary>
    /// Extensión customizada de ProductoCEN
    /// </summary>
    public partial class ProductoCEN
    {
        /// <summary>
        /// Crear producto con validaciones custom
        /// </summary>
        public int CrearProductoCustom(int p_idProducto, int p_categoria, string p_administrador,
            string p_nombre, string p_descripcion, float p_precio, int p_stock,
            string p_material, string p_imagen, string p_etiquetas, string p_emailCliente,
            Nullable<DateTime> p_fecha, string p_metodoPago, string p_datosTarjeta, string p_direccion)
        {
            //  INICIO
            DateTime tiempoInicio = DateTime.Now;

            try
            {
                Console.WriteLine($"\n[CUSTOM CREATE] Creando producto: {p_nombre}");

                //  VALIDACIÓN 1: Precio positivo
                if (p_precio <= 0)
                {
                    throw new ArgumentException("El precio debe ser mayor que 0");
                }

                //  VALIDACIÓN 2: Stock no negativo
                if (p_stock < 0)
                {
                    throw new ArgumentException("El stock no puede ser negativo");
                }

                //  VALIDACIÓN 3: Nombre no vacío
                if (string.IsNullOrWhiteSpace(p_nombre))
                {
                    throw new ArgumentException("El nombre del producto no puede estar vacío");
                }

                Console.WriteLine($"[CUSTOM CREATE] Precio: {p_precio:F2}€");
                Console.WriteLine($"[CUSTOM CREATE] Stock inicial: {p_stock}");

                // ALERTA: Stock bajo desde el inicio
                if (p_stock < 10)
                {
                    Console.WriteLine($"[ALERTA] Producto creado con stock bajo: {p_stock} unidades");
                }

                // Llamar al método original
                int oid = crearProducto(p_idProducto, p_categoria, p_administrador, p_nombre,
                    p_descripcion, p_precio, p_stock, p_material, p_imagen, p_etiquetas,
                    p_emailCliente, p_fecha ?? DateTime.Now, p_metodoPago, p_datosTarjeta, p_direccion);

                //  FIN
                TimeSpan duracion = DateTime.Now - tiempoInicio;
                Console.WriteLine($"[CUSTOM CREATE] Producto creado exitosamente. ID: {oid}");
                Console.WriteLine($"[TIEMPO] CrearProductoCustom: {duracion.TotalMilliseconds}ms\n");

                return oid;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] CrearProductoCustom: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Modificar producto con auditoría y validaciones
        /// </summary>
        public void ModificarProductoCustom(int p_Producto_OID, string p_nombre, string p_descripcion,
            float p_precio, int p_stock, string p_material, string p_imagen,
            string p_etiquetas, string p_emailCliente, Nullable<DateTime> p_fecha,
            string p_metodoPago, string p_datosTarjeta, string p_direccion)
        {
            //  INICIO
            DateTime tiempoInicio = DateTime.Now;

            try
            {
                Console.WriteLine($"\n[CUSTOM MODIFY] Modificando producto ID: {p_Producto_OID}");

                // Obtener producto actual usando ReadOIDDefault
                ProductoEN productoActual = _IProductoRepository.ReadOIDDefault(p_Producto_OID);

                if (productoActual == null)
                {
                    throw new ArgumentException($"No existe un producto con ID: {p_Producto_OID}");
                }

                Console.WriteLine($"[CUSTOM MODIFY] Producto: {productoActual.Nombre}");

                //  VALIDACIÓN 1: Precio positivo
                if (p_precio <= 0)
                {
                    throw new ArgumentException("El precio debe ser mayor que 0");
                }

                //  VALIDACIÓN 2: Stock no negativo
                if (p_stock < 0)
                {
                    throw new ArgumentException("El stock no puede ser negativo");
                }

                //  AUDITORÍA: Registrar cambios importantes
                if (productoActual.Precio != p_precio)
                {
                    Console.WriteLine($"[AUDIT] Cambio de precio: {productoActual.Precio:F2}€ → {p_precio:F2}€");
                    float diferencia = p_precio - productoActual.Precio;
                    float porcentaje = (diferencia / productoActual.Precio) * 100;
                    Console.WriteLine($"[AUDIT] Variación: {diferencia:F2}€ ({porcentaje:F1}%)");
                }

                if (productoActual.Stock != p_stock)
                {
                    Console.WriteLine($"[AUDIT] Cambio de stock: {productoActual.Stock} → {p_stock}");
                    int diferencia = p_stock - productoActual.Stock;
                    Console.WriteLine($"[AUDIT] Diferencia: {(diferencia > 0 ? "+" : "")}{diferencia} unidades");
                }

                //  ALERTA: Stock bajo
                if (p_stock < 10 && p_stock > 0)
                {
                    Console.WriteLine($"[ALERTA] Stock bajo detectado: {p_stock} unidades");
                }
                else if (p_stock == 0)
                {
                    Console.WriteLine($"[ALERTA] Producto sin stock");
                }

                // Llamar al método original
                modificarProducto(p_Producto_OID, p_nombre, p_descripcion, p_precio, p_stock,
                    p_material, p_imagen, p_etiquetas, p_emailCliente, p_fecha ?? DateTime.Now,
                    p_metodoPago, p_datosTarjeta, p_direccion);

                //  FIN
                TimeSpan duracion = DateTime.Now - tiempoInicio;
                Console.WriteLine($"[CUSTOM MODIFY] Producto modificado exitosamente");
                Console.WriteLine($"[TIEMPO] ModificarProductoCustom: {duracion.TotalMilliseconds}ms\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] ModificarProductoCustom: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Actualizar solo el stock de un producto (operación custom simple)
        /// </summary>
        public void ActualizarStock(int p_idProducto, int cantidadCambio)
        {
            //  INICIO
            DateTime tiempoInicio = DateTime.Now;

            try
            {
                Console.WriteLine($"\n[CUSTOM] ActualizarStock - Producto ID: {p_idProducto}");

                // Usar ReadOIDDefault para obtener el producto
                ProductoEN producto = _IProductoRepository.ReadOIDDefault(p_idProducto);

                if (producto == null)
                {
                    throw new ArgumentException($"No existe un producto con ID: {p_idProducto}");
                }

                int nuevoStock = producto.Stock + cantidadCambio;

                if (nuevoStock < 0)
                {
                    throw new InvalidOperationException($"Stock insuficiente. Stock actual: {producto.Stock}, cambio solicitado: {cantidadCambio}");
                }

                Console.WriteLine($"[CUSTOM] Stock actual: {producto.Stock}");
                Console.WriteLine($"[CUSTOM] Cambio: {(cantidadCambio > 0 ? "+" : "")}{cantidadCambio}");
                Console.WriteLine($"[CUSTOM] Nuevo stock: {nuevoStock}");

                modificarProducto(p_idProducto, producto.Nombre, producto.Descripcion,
                    producto.Precio, nuevoStock, producto.Material, producto.Imagen,
                    producto.Etiquetas, producto.EmailCliente, producto.Fecha ?? DateTime.Now,
                    producto.MetodoPago, producto.DatosTarjeta, producto.Direccion);

                //  FIN
                TimeSpan duracion = DateTime.Now - tiempoInicio;
                Console.WriteLine($"[CUSTOM] Stock actualizado exitosamente");
                Console.WriteLine($"[TIEMPO] ActualizarStock: {duracion.TotalMilliseconds}ms\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] ActualizarStock: {ex.Message}");
                throw;
            }
        }
    }
}