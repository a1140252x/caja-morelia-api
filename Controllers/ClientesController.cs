using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Services;
using Data;

namespace Controllers;

// Adaptador de entrada: controlador HTTP que expone la API REST para Clientes
// Recibe las solicitudes y ejecuta los casos de uso de la capa de Aplicación
[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase {

    private readonly CrearClienteService _crear;
    private readonly ObtenerClientesService _obtener;
    private readonly ActualizarClienteService _actualizar;
    private readonly ObtenerClientePorIdService _obtenerPorId;
    private readonly EliminarClienteService _eliminar;

    // Constructor con todos los servicios (casos de uso)
    public ClientesController(
        CrearClienteService crear,
        ObtenerClientesService obtener,
        ActualizarClienteService actualizar,
        ObtenerClientePorIdService obtenerPorId,
        EliminarClienteService eliminar
    ){
        _crear = crear;
        _obtener = obtener;
        _actualizar = actualizar;
        _obtenerPorId = obtenerPorId;
        _eliminar = eliminar;
    }

    // GET: api/clientes
    [HttpGet]
    public async Task<IActionResult> ObtenerTodos(){
        var clientes = await _obtener.EjecutarAsync();
        return Ok(clientes);
    }

    // GET: api/clientes/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenerPorId( int id ){
        var cliente = await _obtenerPorId.EjecutarAsync(id);
        if (cliente == null)
            return NotFound();

        return Ok(cliente);
    }

    // POST: api/clientes
    [HttpPost]
    public async Task<IActionResult> Crear([FromBody] Cliente cliente) {
        try {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var clienteCreado = await _crear.EjecutarAsync(cliente);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = clienteCreado.Id }, clienteCreado);
        }
        catch( ArgumentException ex ){
            // Manejamos los errores de validación personalizados
            return BadRequest(new { mensaje = ex.Message });
        }
    }

    // PUT: api/clientes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Actualizar(int id, [FromBody] Cliente cliente) {

        if (id != cliente.Id)
            return BadRequest("El ID no coincide");

        try {
            // Validar que el modelo recibido es válido
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var actualizado = await _actualizar.EjecutarAsync(cliente);

            if (!actualizado)
                return NotFound();

            return NoContent(); // 204 OK sin contenido
        }
        catch( ArgumentException ex ){
            // Si hay errores de validación del dominio
            return BadRequest(new { mensaje = ex.Message });
        }
        catch( Exception ) {
            // Error interno del servidor
            return StatusCode(500, "Ocurrió un error al actualizar el cliente.");
        }

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Eliminar(int id) {
        var eliminado = await _eliminar.EjecutarAsync(id);

        if( !eliminado )
            return NotFound(); // 404 si no existe

        return NoContent(); // 204 OK sin contenido
    }

}
