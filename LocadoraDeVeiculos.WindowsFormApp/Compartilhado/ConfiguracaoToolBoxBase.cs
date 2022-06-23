using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WindowsFormApp.Compartilhado
{
    public abstract class ConfiguracaoToolBoxBase
    {
        public abstract string TipoCadastro { get; }

        public abstract string TooltipInserir { get; }

        public abstract string TooltipEditar { get; }

        public abstract string TooltipExcluir { get; }

        public virtual string TooltipFiltrar { get; }

        public virtual string TooltipAgrupar { get; }

        public virtual string TooltipVisualizar { get; }


        public virtual bool InserirHabilitado { get { return true; } }

        public virtual bool EditarHabilitado { get { return true; } }

        public virtual bool ExcluirHabilitado { get { return true; } }

        public virtual bool FiltrarHabilitado { get { return false; } }

        public virtual bool AgruparHabilitado { get { return false; } }

        public virtual bool VisualizarHabilitado { get { return false; } }
    }
}
