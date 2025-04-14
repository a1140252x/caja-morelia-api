using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

// Caso de uso: eliminar un cliente
public class EliminarClienteService {

    private readonly IClienteRepository _repository;

    // Constructor con el repositorio para acceder a la BD
    public EliminarClienteService(IClienteRepository repository) {
        _repository = repository;
    }

    // Método para la eliminación de un cliente
    public async Task<bool> EjecutarAsync(int id) {
        var eliminado = await _repository.EliminarAsync(id);
        return eliminado;
    }

}
