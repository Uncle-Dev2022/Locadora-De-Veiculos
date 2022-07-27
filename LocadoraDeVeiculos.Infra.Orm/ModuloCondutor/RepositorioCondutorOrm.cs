﻿using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorOrm : RepositorioBaseOrm<Condutor, MapeadorCondutorOrm>
    {
        public RepositorioCondutorOrm(LocadoraDeVeiculosDbContext db) : base(db)
        {
            Dados = db.Set<Condutor>();
        }
    }
}
