using System;
using MonlithDS.DAL.Models;
using MonolithDS.Domain;

namespace MonlithDS.DAL.Repositories
{
    public class BaseRepository
    {
        private readonly DSEntities _context;

        protected DSEntities Context
        {
            get
            {
                return _context;
            }
        }

        public BaseRepository(IUnitOfWork context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            _context = context as DSEntities;
        }
    }
}
