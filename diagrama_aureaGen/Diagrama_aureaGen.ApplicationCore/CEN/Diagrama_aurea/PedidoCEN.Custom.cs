using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Diagrama_aureaGen.ApplicationCore.Exceptions;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Enumerated.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /// <summary>
    /// Extensión customizada de PedidoCEN
    /// </summary>
    public partial class PedidoCEN
    {
        /// <summary>
        /// Eliminar pedido con validaciones de dependencias
        /// </summary>
        public void EliminarPedidoCustom(int idPedido)
        {
            //  INICIO
            DateTime tiempoInicio = DateTime.Now;

            try
            {
                Console.WriteLine($"\n[CUSTOM DELETE] Eliminando pedido ID: {idPedido}");

                // Usar ReadOIDDefault para obtener el pedido
                PedidoEN pedido = _IPedidoRepository.ReadOIDDefault(idPedido);

                if (pedido == null)
                {
                    throw new ArgumentException($"No existe un pedido con ID: {idPedido}");
                }

                Console.WriteLine($"[CUSTOM DELETE] Estado del pedido: {pedido.Estado}");
                Console.WriteLine($"[CUSTOM DELETE] Total del pedido: {pedido.Total:F2}€");

                //  VALIDACIÓN 1: No eliminar pedidos entregados (equivalente a completado)
                if (pedido.Estado == EstadoPedidoEnum.Entregado)
                {
                    throw new InvalidOperationException("No se puede eliminar un pedido que ya ha sido entregado");
                }

                //  VALIDACIÓN 2: No eliminar pedidos en proceso de envío
                if (pedido.Estado == EstadoPedidoEnum.Enviado)
                {
                    throw new InvalidOperationException("No se puede eliminar un pedido que ya ha sido enviado");
                }

                //  VALIDACIÓN 3: No eliminar pedidos en proceso
                if (pedido.Estado == EstadoPedidoEnum.EnProceso)
                {
                    throw new InvalidOperationException("No se puede eliminar un pedido que está en proceso de preparación");
                }

                //  Información sobre detalles
                if (pedido.DetallePedido != null && pedido.DetallePedido.Count > 0)
                {
                    Console.WriteLine($"[CUSTOM DELETE] El pedido tiene {pedido.DetallePedido.Count} detalles asociados");
                    Console.WriteLine($"[CUSTOM DELETE] Se eliminarán automáticamente por CASCADE");
                }

                // Eliminar el pedido (solo si está en: EnCarrito, Pendiente o Cancelado)
                EliminarPedido(idPedido);

                //  FIN
                TimeSpan duracion = DateTime.Now - tiempoInicio;
                Console.WriteLine($"[CUSTOM DELETE] Pedido eliminado exitosamente");
                Console.WriteLine($"[TIEMPO] EliminarPedidoCustom: {duracion.TotalMilliseconds}ms\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] EliminarPedidoCustom: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Calcular el total de un pedido basado en sus detalles
        /// </summary>
        public float CalcularTotalPedido(int idPedido)
        {
            //  INICIO
            DateTime tiempoInicio = DateTime.Now;

            try
            {
                Console.WriteLine($"\n[CUSTOM] CalcularTotalPedido - ID: {idPedido}");

                // Usar ReadOIDDefault para obtener el pedido
                PedidoEN pedido = _IPedidoRepository.ReadOIDDefault(idPedido);

                if (pedido == null)
                {
                    throw new ArgumentException($"No existe un pedido con ID: {idPedido}");
                }

                float total = 0;

                if (pedido.DetallePedido != null && pedido.DetallePedido.Count > 0)
                {
                    Console.WriteLine($"[CUSTOM] Calculando total de {pedido.DetallePedido.Count} productos...");

                    foreach (var detalle in pedido.DetallePedido)
                    {
                        float subtotal = detalle.Cantidad * detalle.PrecioUnitario;
                        total += subtotal;
                        Console.WriteLine($"[CUSTOM] - {detalle.Cantidad} x {detalle.PrecioUnitario:F2}€ = {subtotal:F2}€");
                    }
                }
                else
                {
                    Console.WriteLine($"[CUSTOM] El pedido no tiene detalles asociados");
                }

                Console.WriteLine($"[CUSTOM] Total calculado: {total:F2}€");

                //  FIN
                TimeSpan duracion = DateTime.Now - tiempoInicio;
                Console.WriteLine($"[TIEMPO] CalcularTotalPedido: {duracion.TotalMilliseconds}ms\n");

                return total;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] CalcularTotalPedido: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Cambiar estado del pedido con validaciones
        /// </summary>
        public void CambiarEstadoPedidoCustom(int idPedido, EstadoPedidoEnum nuevoEstado)
        {
            DateTime tiempoInicio = DateTime.Now;

            try
            {
                Console.WriteLine($"\n[CUSTOM] CambiarEstadoPedido - ID: {idPedido}");

                PedidoEN pedido = _IPedidoRepository.ReadOIDDefault(idPedido);

                if (pedido == null)
                {
                    throw new ArgumentException($"No existe un pedido con ID: {idPedido}");
                }

                EstadoPedidoEnum estadoActual = pedido.Estado;
                Console.WriteLine($"[CUSTOM] Estado actual: {estadoActual} -> Nuevo estado: {nuevoEstado}");

                //  VALIDACIONES DE TRANSICIÓN DE ESTADOS
                if (estadoActual == EstadoPedidoEnum.Cancelado)
                {
                    throw new InvalidOperationException("No se puede cambiar el estado de un pedido cancelado");
                }

                if (estadoActual == EstadoPedidoEnum.Entregado)
                {
                    throw new InvalidOperationException("No se puede cambiar el estado de un pedido ya entregado");
                }

                // No se puede retroceder en el flujo (excepto a Cancelado)
                if (nuevoEstado != EstadoPedidoEnum.Cancelado && nuevoEstado < estadoActual)
                {
                    throw new InvalidOperationException($"No se puede retroceder de {estadoActual} a {nuevoEstado}");
                }

                // Modificar el pedido con el nuevo estado
                ModificarPedido(idPedido, pedido.Fecha, nuevoEstado, pedido.Total);

                TimeSpan duracion = DateTime.Now - tiempoInicio;
                Console.WriteLine($"[CUSTOM] Estado cambiado exitosamente");
                Console.WriteLine($"[TIEMPO] CambiarEstadoPedidoCustom: {duracion.TotalMilliseconds}ms\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] CambiarEstadoPedidoCustom: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtener pedidos por estado
        /// </summary>
        public IList<PedidoEN> ObtenerPedidosPorEstadoCustom(EstadoPedidoEnum estado)
        {
            DateTime tiempoInicio = DateTime.Now;

            try
            {
                Console.WriteLine($"\n[CUSTOM] ObtenerPedidosPorEstado - Estado: {estado}");

                IList<PedidoEN> todosPedidos = _IPedidoRepository.ReadAllDefault(0, -1);

                var pedidosFiltrados = todosPedidos
                    .Where(p => p.Estado == estado)
                    .OrderByDescending(p => p.Fecha)
                    .ToList();

                Console.WriteLine($"[CUSTOM] Encontrados {pedidosFiltrados.Count} pedidos con estado {estado}");

                TimeSpan duracion = DateTime.Now - tiempoInicio;
                Console.WriteLine($"[TIEMPO] ObtenerPedidosPorEstadoCustom: {duracion.TotalMilliseconds}ms\n");

                return pedidosFiltrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] ObtenerPedidosPorEstadoCustom: {ex.Message}");
                throw;
            }
        }
    }
}