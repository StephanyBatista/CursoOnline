using CursoOnline.Dominio._Base;

namespace CursoOnline.Dominio.Cursos
{
    public class Curso : Entidade
    {
        private Curso() { }

        public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            ValidadorDeRegra.Novo()
                .Quando(string.IsNullOrEmpty(nome), "Nome inválido")
                .Quando(cargaHoraria < 1, "Carga horária inválida")
                .Quando(valor < 1, "Valor inválido")
                .DispararExcecaoSeExistir();

            Nome = nome;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
    }
}