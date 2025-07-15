using Shop.Domain.Interfaces;
using Shop.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastracture.Presistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        private readonly Dictionary<Type, object> _repostotyes = new Dictionary<Type, object>();
        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repostotyes.ContainsKey(typeof(T)))
                return _repostotyes[typeof(T)] as IRepository<T>;

            var repository = new Repository<T>(_context);
            _repostotyes[typeof(T)] = repository;
            return repository;
        }
    }
}
