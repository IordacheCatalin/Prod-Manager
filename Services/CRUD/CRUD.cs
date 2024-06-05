using Microsoft.EntityFrameworkCore;
using Prod_Manger.Data;
using Prod_Manger.Models.Domain;
using Prod_Manger.ViewModel;


namespace Prod_Manger.Services.CRUD
{
    public class CRUD<T> : ICRUD<T> where T : class
    {
        private readonly ProdManagerDbContext _prodManagerDbContext;
        private readonly DbSet<T> _dbSet;

        public CRUD(ProdManagerDbContext prodManagerDbContext)
        {
            _prodManagerDbContext = prodManagerDbContext ?? throw new ArgumentNullException(nameof(prodManagerDbContext));
            _dbSet = _prodManagerDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderByDescending(entity => EF.Property<int>(entity, "Id"));
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _prodManagerDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _prodManagerDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _prodManagerDbContext.SaveChanges();
            }
        }
    }
}

