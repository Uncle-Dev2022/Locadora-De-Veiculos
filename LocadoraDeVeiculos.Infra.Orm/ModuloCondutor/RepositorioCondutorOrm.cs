using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using System.Linq;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorOrm : RepositorioBaseOrm<Condutor, MapeadorCondutorOrm>, IRepositorioCondutor
    {
        public RepositorioCondutorOrm(LocadoraDeVeiculosDbContext db) : base(db)
        {
            Dados = db.Set<Condutor>();
        }

        public Condutor SelecionarCondutorPorNome(string nome)
        {
            return Dados.FirstOrDefault(x => x.Nome == nome);
        }

        public Condutor SelecionarCondutorPorCPF(string CPF)
        {
            return Dados.FirstOrDefault(x => x.CPF == CPF);
        }

        public Condutor SelecionarCondutorPorCNH(string CNH)
        {
            return Dados.FirstOrDefault(x => x.CNH == CNH);
        }
    }
}
