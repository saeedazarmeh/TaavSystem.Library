using Library.InfraStuctureLayer.Persistent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.InfraStuctureLayer.UnitOfWork
{
    public class EfUnitOfWork : CommonLayer.UnitOfWork.UnitOfWork
    {
        private readonly EFDbContext _dbContext;

        public EfUnitOfWork(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Begin()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task RoleBack()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
