using System;

namespace dio.series {
    public class Serie : EntidadeBase {
        // atributos da serie
       public int Id { get; protected set; }
       private Genero Genero { get; set; }
       private string Titulo { get; set; }
       private string Descricao { get; set; }
       private int Ano { get; set; }
       private bool Excluido { get; set; }
       // metodos implementados
       public Serie(int id, Genero genero, string titulo, string descricao, int ano) {
           this.Id = id;
           this.Genero = genero;
           this.Titulo = titulo;
           this.Descricao = descricao;
           this.Ano = ano;
           this.Excluido = false;
       }

        public override string ToString() {
            // retorno da chamada 
            string retorno = "";
            retorno += "Genero: " + this.Genero + Environment.NewLine; 
            retorno += "Titulo: " + this.Titulo + Environment.NewLine; 
            retorno += "Descrição: " + this.Descricao + Environment.NewLine; 
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine; 
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }
        public string retornaTitulo() {
            return this.Titulo;
        }
        public int retornaId() {
            return this.Id;
        }
        // marcar o registro como excluido
        public void Excluir() {
            this.Excluido = true;
        }
        public bool RetornaExcluido() {
            return this.Excluido;
        }        
    }
  
}