using Domain.Interfaces;
using Infraestructure.Interfaces;
using Infraestructure.Models;

namespace Domain;

public class RepositoryGeneric<TEntity>(IRepository<TEntity> repository): IRepositoryGeneric<TEntity> where TEntity : class
{
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task Add(TEntity entity)
    {
        if (entity is Client client)
        {
            var clients = await repository.GetAllAsync();
            if (clients.Cast<Client>().Any(c => c.Email == client.Email))
            {
                throw new Exception("A client with the same email already exists.");
            }
            await repository.Add(entity);
        }

        if (entity is Deliver deliver)
        {
            var delivers = await repository.GetAllAsync();
            var clientDelivers = delivers.Cast<Deliver>().Count(d => d.ClientId == deliver.ClientId);
            if (clientDelivers >= 5)
            {
                throw new Exception("The client has already made 5 orders.");
            }
            await repository.Add(entity);
        }
        
    }

    public async Task Update(TEntity entity)
    {
        if (entity is Deliver deliver)
        {
            var originalDeliver = await repository.GetByIdAsync(deliver.Id) as Deliver;
            if (originalDeliver.ClientId != deliver.ClientId)
            {
                throw new Exception("Updating the ClientId of a Deliver is not allowed.");
            }
        }
        await repository.Update(entity);
    }

    public async Task Delete(int id)
    {
        await repository.Delete(id);
    }
}