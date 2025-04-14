using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

// Caso de uso: obtener un cliente 
public class ObtenerClientePorIdService {

    private readonly IClienteRepository _repository;

    // Constructor con el repositorio para acceder a la BD
    public ObtenerClientePorIdService(IClienteRepository repository){
        _repository = repository;
    }

    // Obtener cliente por su ID
    public async Task<Cliente> EjecutarAsync(int id) {
        // Obtener el cliente del repositorio por su ID
        var cliente = await _repository.ObtenerPorIdAsync(id);
        if (cliente == null)
            throw new ArgumentException("Cliente no encontrado.");

        return cliente;
    }
}
