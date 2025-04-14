using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

// Caso de uso: obtener lista de clientes
public class ObtenerClientesService {

    private readonly IClienteRepository _repository;

    // Constructor con el repositorio para acceder a la BD
    public ObtenerClientesService(IClienteRepository repository) {
        _repository = repository;
    }

    // Metodo para obtener todos los clientes
    public async Task<IEnumerable<Cliente>> EjecutarAsync() {
        return await _repository.ObtenerTodosAsync();
    }
}
