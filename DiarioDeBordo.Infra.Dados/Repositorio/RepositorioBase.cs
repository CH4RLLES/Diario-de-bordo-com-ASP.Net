using DiarioDeBordo.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DiarioDeBordo.Infra.Dados.Repositorio
{
    public class RepositorioBase<T> where T : class
    {
        #region Property
        public DiarioContext Contexto { get; private set; }
        public DbSet<T> Entity { get; private set; }
        #endregion Property

        #region Constructs
        public RepositorioBase()
        {
            this.Contexto = new DiarioContext();
            this.Contexto.Database.OpenConnection();
            this.Entity = this.Contexto.Set<T>();
        }

        public RepositorioBase(DiarioContext _contexto)
        {
            this.Contexto = _contexto;
            this.Entity = this.Contexto.Set<T>();
        }

        #endregion Constructs

        #region Inserir

        public void Inserir(T Entity)
        {
            try
            {
                this.Entity.Add(Entity);
                this.Save();
                Dispose();
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }

        }
        public void InserirLista(IList<T> Entities)
        {
            if (Entities != null && Entities.Count > 0)
            {
                this.Entity.AddRange(Entities);
                //foreach (T Entity in Entities)
                //{
                //    this.Entity.Add(Entity);
                //}
                this.Save();
                Dispose();
            }
        }
        #endregion Inserir

        #region Editar
        public void Editar(T Entity)
        {
            this.Contexto.Entry(Entity).State = EntityState.Modified;
            this.Save();
            Dispose();
        }

        public void EditarLista(IList<T> Entities)
        {
            if (Entities != null && Entities.Count > 0)
            {
                foreach (T Entity in Entities)
                {
                    this.Contexto.Entry(Entity).State = EntityState.Modified;
                }
                this.Save();
                Dispose();
            }
        }
        #endregion Editar

        #region Delete
        public bool Delete(params object[] id)
        {

            T Entity = Obter(id);
            this.Contexto.Entry(Entity).State = EntityState.Deleted;
            this.Save();

            bool _delete = true;

            return _delete;
        }
        public void Delete(IList<T> Entities)
        {
            if (Entities != null && Entities.Count > 0)
            {
                foreach (T Entity in Entities)
                {
                    this.Contexto.Entry(Entity).State = EntityState.Deleted;
                }
                this.Save();
            }
        }

        public void Delete(Expression<Func<T, bool>> Where)
        {
            var itens = this.Entity.Where(Where);
            foreach (var item in itens)
            {
                this.Entity.Remove(item);
            }

            this.Save();
        }
        #endregion Delete

        #region Obter
        public T Obter(params object[] id)
        {
            var ret = this.Entity.Find(id);
            Dispose();
            return ret;
        }

        public T Obter(Expression<Func<T, bool>> Where)
        {
            var result = this.Entity.AsNoTracking().SingleOrDefault(Where);
            Dispose();
            return result;
        }

        public T ObterIncludes(Expression<Func<T, bool>> Where, string includes)
        {
            var itens = includes.Split(',');
            IQueryable<T> query = null;

            query = Entity;
            foreach (var param in itens)
            {
                query = query.Include(param);
            }
            var result = query.AsNoTracking().SingleOrDefault(Where);
            Dispose();
            return result;
        }
        #endregion Obter

        #region Listar
        public IList<T> ListarTodos()
        {
            var result = this.Entity.AsNoTracking().ToList();
            Dispose();
            return result;
        }

        public IList<T> ListarTodosInclude(string includes)
        {
            var itens = includes.Split(',');
            IQueryable<T> query = null;

            query = Entity;
            foreach (var param in itens)
            {
                query = query.Include(param);
            }
            var result = query.AsNoTracking().ToList();
            Dispose();
            return result;
        }

        public IList<T> Listar(Expression<Func<T, bool>> Where)
        {
            var result = this.Entity.Where(Where).AsNoTracking().AsQueryable().ToList();
            Dispose();
            return result;
        }

        public IList<T> ListarInclude(Expression<Func<T, bool>> Where, string includes)
        {
            var itens = includes.Split(',');
            IQueryable<T> query = null;

            query = Entity;
            foreach (var param in itens)
            {
                query = query.Include(param);
            }
            var result = query.Where(Where).AsNoTracking().AsQueryable().ToList();
            Dispose();
            return result;
        }
        #endregion Listar

        #region Save
        public int Save()
        {
            return this.Contexto.SaveChanges();
        }
        #endregion Save

        public bool VerExiste(Expression<Func<T, bool>> Where)
        {
            return this.Entity.AsNoTracking().Any(Where);
        }

        public int Quantidade(Expression<Func<T, bool>> Where)
        {
            return this.Entity.AsNoTracking().Count(Where);
        }

        #region Dispose
        public void Dispose()
        {
            this.Entity = null;
            this.Contexto.Database.CloseConnection();
            this.Contexto.Dispose();
            this.Contexto = null;
            GC.Collect();
            GC.SuppressFinalize(this);
        }
        #endregion Dispose

    }
}
