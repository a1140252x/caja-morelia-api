using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Data;

namespace Infrastructure.Repositories;


// Adaptador de salida: implementación concreta del repositorio usando Entity Framework.
public class ClienteRepository : IClienteRepository {

    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> ObtenerTodosAsync() {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente?> ObtenerPorIdAsync(int id) {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<Cliente?> CrearAsync(Cliente cliente) {
        await _context.Clientes.AddAsync(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<bool> ActualizarAsync(Cliente cliente) {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EliminarAsync(int id) {
        var cliente = await _context.Clientes.FindAsync(id);
        if( cliente == null ){
            return false; // No se encontró el cliente
        }
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return true;
    }

}

