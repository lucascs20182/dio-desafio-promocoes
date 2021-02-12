using System; 
using System.Collections.Generic;

namespace Teste
{
  class minhaClasse
  {
    static void Main(string[] args)
    {
      string[] valores = Console.ReadLine().Split();
      int n = Convert.ToInt32(valores[0]);
      int m = Convert.ToInt32(valores[1]);
      int resultado = 0;
      var promocoes = new List<Promocao>();
      Promocao menorQtd;
      Promocao melhorCustoBeneficio;
      


      // lendo os inputs
      string input;
      while (!string.IsNullOrEmpty(input = Console.ReadLine())){
          string[] qtdBebidasEPreco = input.Split();
          string q = qtdBebidasEPreco[0];
          string v = qtdBebidasEPreco[1];

          Promocao p = new Promocao(q, v);
          promocoes.Add(p);
      }

      

      menorQtd = menorQtdLatasPorPromocao(promocoes);

      while(m >= Convert.ToInt32(menorQtd.qtdBebidas))
      {
        melhorCustoBeneficio = maiorQuantiaPossivelDeArrecadar(promocoes);

        while(m >= Convert.ToInt32(melhorCustoBeneficio.qtdBebidas))
        {
          m = m - Convert.ToInt32(melhorCustoBeneficio.qtdBebidas);
          resultado += Convert.ToInt32(melhorCustoBeneficio.preco);
        }

        promocoes.RemoveAt(promocoes.FindIndex (
            e => e.precoPorLata == melhorCustoBeneficio.precoPorLata
          )
        );
      }

      Console.WriteLine(resultado);
    }



    struct Promocao
    {
        public string qtdBebidas { get; }
        public string preco { get; }
        public double precoPorLata { get; }

        public Promocao(string qtdBebidas, string preco)
        {
          this.qtdBebidas = qtdBebidas;
          this.preco = preco;

          precoPorLata = Convert.ToDouble(preco) / Convert.ToDouble(qtdBebidas);
        }
    }



    static Promocao maiorQuantiaPossivelDeArrecadar(List<Promocao> promocoes)
    {
      Promocao promocaoComMaiorPrecoPorLata = promocoes[0];

      foreach(Promocao p in promocoes)
      {
        if(p.precoPorLata > promocaoComMaiorPrecoPorLata.precoPorLata)
        {
          promocaoComMaiorPrecoPorLata = p;
        }
      }

      return promocaoComMaiorPrecoPorLata;
    }



    static Promocao menorQtdLatasPorPromocao(List<Promocao> promocoes)
    {
      Promocao promocaoComMenorQtdDeLatas = promocoes[0];

      foreach(Promocao p in promocoes)
      {
        if(Convert.ToInt32(p.qtdBebidas) < Convert.ToInt32(promocaoComMenorQtdDeLatas.qtdBebidas))
        {
          promocaoComMenorQtdDeLatas = p;
        }
      }

      return promocaoComMenorQtdDeLatas;
    }
  }
}
