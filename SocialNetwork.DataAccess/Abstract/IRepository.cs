using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Abstract
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> GetAllQuery(); // Возвращает запрос на получение полного списка элементов
        ICollection<T> GetAll(); // Возвращает коллекцию элементов
        Task<ICollection<T>> GetAllAsync(); // Возвращает коллекцию элементов асинхронно
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate); // Метод получения запроса элементов по условию
        T Find(Expression<Func<T, bool>> match); // Поиск единственного элемента по условию
        Task<T> FindAsync(Expression<Func<T, bool>> match); // Поиск единственного элемента по условию (Асинхронно)
        bool Contains(Expression<Func<T, bool>> predicate); // Проверка наличия элемента в коллекции по условию       
        Task<T> FindByKeyAsync(params object[] keys); // Поиск элемента по идентификатору Асинхронно
        T FindByKey(params object[] keys); // Поиск элемента по идентификатору
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entity);
        void Delete(T entity);
        void RemoveRange(IEnumerable<T> entity);
        void Update(T entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
