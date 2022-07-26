using LocadoraDeVeiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.Compartilhado
{
    public abstract class RepositorioBaseOrm<T, Mapeador> : IRepositorio<T>
        where T : EntidadeBase<T> where Mapeador : MapeadorBaseOrm<T>
    {
        protected LocadoraDeVeiculosDbContext db;
        protected DbSet<T> Dados;

        public void Editar(T registro)
        {
            
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
    }
}
