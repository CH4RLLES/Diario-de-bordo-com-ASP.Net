using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DiarioDeBordo.Dominio.Interfaces
{
    public interface IServico<T> where T : class
    {
        T Inserir(T obj);

        T Editar(T obj);

        void Delete(Guid id);

        T Obter(Guid id);

        T Obter(Expression<Func<T, bool>> Where);

        T ObterIncludes(Expression<Func<T, bool>> Where, string includes);

        IList<T> ListarTodos();

        IList<T> Listar(Expression<Func<T, bool>> Where);

        bool VerExiste(Expression<Func<T, bool>> Where);

        bool InserirLista(List<T> obj);

        IList<T> ListarInclude(Expression<Func<T, bool>> Where, string includes);

        IList<T> ListarTodosInclude(string includes);
    }
}
