using Domain.Entities;

namespace Domain.Interfaces;

// Puerto de salida: define los métodos que cualquier implementación de repositorio debe seguir.
public interface IClienteRepository {

    // Método para obtener todos los clientes. Devuelve una lista de clientes.
    Task<IEnumerable<Cliente>> ObtenerTodosAsync();

    // Método para obtener un cliente por su ID. Devuelve un cliente o null si no se encuentra.
    Task<Cliente?> ObtenerPorIdAsync(int id);

    // Método para crear un nuevo cliente. Acepta un objeto de tipo Cliente.
    Task<Cliente?> CrearAsync(Cliente cliente);

    // Método para actualizar un cliente existente. Acepta un objeto de tipo Cliente.
    Task<bool> ActualizarAsync(Cliente cliente);

    // Método para eliminar un cliente por su ID.
    Task<bool> EliminarAsync(int id);

}
