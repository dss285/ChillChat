using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aeon.DataModels;

namespace ChillChat.DataModels
{
    public class ChillChatDbRepository : DbRepository
    {
        public ChillChatDbRepository() : base(new ChillChatDbContext())
        {
        }
        public ChillChatDbRepository(BaseDbContext dbContext) : base(dbContext)
        {
        }
    }
    public class TransactionWrapper : IDisposable
    {
        private bool _ownsTransaction;
        private IDbContextTransaction _transaction;

        public TransactionWrapper(IDbContextTransaction transaction, bool ownsTransaction)
        {
            _transaction = transaction;
            _ownsTransaction = ownsTransaction;
        }

        public void Dispose()
        {
            if (_ownsTransaction)
                _transaction.Dispose();
        }
        public void Rollback()
        {
            if (_ownsTransaction)
                _transaction.Rollback();
        }
        public void Commit()
        {
            if (_ownsTransaction)
                _transaction.Commit();
        }
    }
}
