using System;
using System.Collections.Generic;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Compartilhado
{
    public abstract class MapeadorBase<T> where T : EntidadeBase<T>
    {
        public abstract void ConfigurarParametros(T registro, SqlCommand comando);

        public abstract T ConverterRegistro(SqlDataReader leitorRegistro);
    }


}
