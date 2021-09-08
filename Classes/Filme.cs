using System;
namespace DIO.Series
{
    public class Filme : EntidadeBase
    {
        private float Duracao { get; set; }

        public Filme(int id, Genero genero, string titulo, string descricao, int ano, float duracao)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Duracao = duracao;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Duração: " + this.Duracao + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }
    }
}