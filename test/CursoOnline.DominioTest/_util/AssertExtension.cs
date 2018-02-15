using CursoOnline.Dominio._base;
using Xunit;

namespace CursoOnline.DominioTest._util
{
    public static class AssertExtension
    {
        public static void ComMensagem<T>(this ValidadorDeRegra<T> exception, string mensagem)
        {
            if (exception.MensagensDeErro.Contains(mensagem))
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem '{mensagem}'");
        }
    }
}
