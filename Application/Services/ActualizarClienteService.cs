using Domain.Entities;
using Domain.Interfaces;
using System.Text.RegularExpressions;

namespace Application.Services;

// Caso de uso: actualizar un cliente existente.
public class ActualizarClienteService {

    private readonly IClienteRepository _repository;

    // Constructor con el repositorio para acceder a la BD
    public ActualizarClienteService(IClienteRepository repository) {
        _repository = repository;
    }

    public async Task<bool> EjecutarAsync(Cliente cliente) {
        // Obtener el cliente existente
        var clienteExistente = await _repository.ObtenerPorIdAsync(cliente.Id);
        if (clienteExistente == null)
            return false;

        // Actualizar el cliente con los nuevos datos
        clienteExistente.Nombre = cliente.Nombre;
        clienteExistente.CorreoElectronico = cliente.CorreoElectronico;
        clienteExistente.Telefono = cliente.Telefono;

        // Guardar los cambios
        return await _repository.ActualizarAsync(clienteExistente);
    }

}
