using HepsiWebAPI.Application.Interfaces.Repositories;
using HepsiWebAPI.Application.Interfaces.UnitOfWorks;
using HepsiWebAPI.Persistence.Context;
using HepsiWebAPI.Persistence.Repositories;

namespace HepsiWebAPI.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async ValueTask DisposeAsync() => await appDbContext.DisposeAsync();
        public int Save() => appDbContext.SaveChanges();
        public async Task<int> SaveAsync() => await appDbContext.SaveChangesAsync();
        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(appDbContext);
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(appDbContext);
    }
}
