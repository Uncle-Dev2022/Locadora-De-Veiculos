using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public GrupoDeVeiculo GrupoDeVeiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string  Cor { get; set; }
        public string AnoModelo { get; set; }
        public string TipoCombustivel { get; set; }
        public string Placa { get; set; }
        public decimal Quilometragem { get; set; }
        public int CapacidadeTanque { get; set; }
        public byte[] Imagem { get; set; }

        public Bitmap _Imagem
        {

            get
            {
                if (Imagem != null)
                {
                    using (var stream = new MemoryStream(Imagem))
                    {
                        return new Bitmap(stream);
                    }

                }

                return null;
            }
        }

        public Veiculo()
        {
        }

        public Veiculo(string marca, string modelo, string cor, string anoModelo, string tipoCombustivel, string placa
            , decimal quilometragem, int capacidadeTanque,byte[] imagem)
        {
            
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
            AnoModelo = anoModelo;
            TipoCombustivel = tipoCombustivel;
            Placa = placa;
            Quilometragem = quilometragem;
            CapacidadeTanque = capacidadeTanque;
            Imagem = imagem;

        }

        public override bool Equals(object obj)
        {
            Veiculo veiculo = obj as Veiculo;

            if (veiculo == null)
                return false;

            return
                veiculo.Id.Equals(Id) &&
                veiculo.Marca.Equals(Marca) &&
                veiculo.Modelo.Equals(Modelo) &&
                veiculo.Cor.Equals(Cor) &&
                veiculo.AnoModelo.Equals(AnoModelo) &&
                veiculo.TipoCombustivel.Equals(TipoCombustivel) &&
                veiculo.Placa.Equals(Placa) &&
                veiculo.Quilometragem.Equals(Quilometragem) &&
                veiculo.CapacidadeTanque.Equals(CapacidadeTanque);

        }

        public Veiculo Clone()
        {
            return MemberwiseClone() as Veiculo;
        }

        public override string ToString()
        {
            return "Grupo de Veículo: " + GrupoDeVeiculo + " Marca: " + Marca + " Modelo: " + Modelo + "Cor: " + Cor +
            "Ano Modelo: " + AnoModelo + " Tipo Combustivel: " + TipoCombustivel + " Placa: " + Placa + "Quilometragem: " + Quilometragem +
            "Capacidade do Tanque: " + CapacidadeTanque;
        }




    }
}
