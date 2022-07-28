using System;
using System.Collections.Generic;

namespace LocadoraDeVeiculos.Dominio.Compartilhado
{
    public interface IRepositorio<T> where T : EntidadeBase<T>
    {
        void Inserir(T novoRegistro);

        void Editar(T registro);

        void Excluir(T registro);

        //pode dar pau
        void GravarDados();

        List<T> SelecionarTodos();

        T SelecionarPorId(Guid id);
        T SelecionarPorParametro(Func<T, bool> func);
    }
}
