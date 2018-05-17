namespace CursoOnline.Dominio.Cursos
{
    public class CursoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; }
        public double Valor { get; set; }
        public int Id { get; set; }
    }
}