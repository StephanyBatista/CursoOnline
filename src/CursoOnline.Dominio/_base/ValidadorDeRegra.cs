using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoOnline.Dominio._base
{
    public class ValidadorDeRegra<T> : Exception
    {
        public IList<string> MensagensDeErro { get; private set; }

        public static ValidadorDeRegra<T> Criar()
        {
            var validador = new ValidadorDeRegra<T> { MensagensDeErro = new List<string>() };
            return validador;
        }

        public ValidadorDeRegra<T> Validar(bool regraInvalida, string mensagem)
        {
            if(regraInvalida)
                MensagensDeErro.Add(mensagem);

            return this;
        }

        public void LancarExcecao()
        {
            if (MensagensDeErro.Any())
                throw this;
        }
    }
}
