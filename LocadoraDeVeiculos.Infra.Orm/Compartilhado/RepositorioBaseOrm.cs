    using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado
{
    public abstract class RepositorioBaseOrm<T, Mapeador> : IRepositorio<T>
        where T : EntidadeBase<T> where Mapeador : MapeadorBaseOrm<T>
    {
        LocadoraDeVeiculosDbContext db;
        protected DbSet<T> Dados;

        public RepositorioBaseOrm(LocadoraDeVeiculosDbContext db)
        {
            this.db = db;
            Dados = db.Set<T>();
        }

        public void Editar(T registro)
        {
            Dados.Update(registro);
        }
        public void Excluir(T registro)
        {
            Dados.Remove(registro);
        }
        public void Inserir(T novoRegistro)
        {
            Dados.Add(novoRegistro);
        }

        public T SelecionarPorId(Guid id)
        {
            return Dados.FirstOrDefault(x => x.Id == id);
        }
        public List<T> SelecionarTodos()
        {
            return Dados.ToList();
        }
        public void GravarDados()
        {
            db.GravarDados();
        }
        public T SelecionarPorParametro(Func<T, bool> func)
        {
            return Dados.FirstOrDefault(func);
        }
    }
}
