using MonolithDS.Domain;

namespace MonlithDS.DAL.Models
{
    // ReSharper disable once InconsistentNaming
    public partial class DSEntities : IUnitOfWork
    {
        public void Save()
        {
            SaveChanges();
        }
    }
}
