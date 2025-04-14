using Domain.Entities;
using Domain.Interfaces;
using System.Text.RegularExpressions;

namespace Application.Services;

// Caso de uso: crear un nuevo cliente
public class CrearClienteService {

    private readonly IClienteRepository _repository;

    // Constructor con el repositorio para acceder a la BD
    public CrearClienteService( IClienteRepository repository ){
        _repository = repository;
    }

    public async Task<Cliente> EjecutarAsync(Cliente cliente){
        // Llamada al repositorio para guardar el cliente
        var resultado = await _repository.CrearAsync(cliente);
        if (resultado == null)
            throw new InvalidOperationException("No se pudo crear el cliente.");

        return resultado;
    }

}
