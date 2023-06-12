using Desafio2_Categorias.Dados;

class program
{
    static void Main(string[] args)
    {
        using (var contexto = new Contexto())
        {
            contexto.StartLogSqlToConsole();

            var categorias = contexto.Categorias
                .Include(c => c.Filmes)
                .ThenInclude(fc => fc.Filme);

            foreach (var c in categorias)
            {
                Console.WriteLine("");
                Console.WriteLine($"Filmes da categoria {c}:");
                foreach (var fc in c.Filmes)
                {
                    Console.WriteLine(fc.Filme);
                }
            }

        }
    }
}