using System;
using DesignPatterns.StrategyEx;

namespace DesignPatterns.StrategyEx
{
    public enum TipoOperacao
    {
        Somar = 1,
        Dividir = 2,
        Multiplicar = 3,
        Subtratir = 4
    }

    internal abstract class OperacaoStrategy
    {
        internal abstract double Executar(double n1, double n2);
    }

    public class CalculadoraContextStrategy
    {
        public CalculadoraContextStrategy(TipoOperacao tipoOperacao)
        {
            switch (tipoOperacao)
            {
                case TipoOperacao.Dividir:
                    Operacao = new DividirStrategy();
                    break;
                case TipoOperacao.Multiplicar:
                    Operacao = new MultiplicarStrategy();
                    break;
                case TipoOperacao.Somar:
                    Operacao = new SomarStrategy();
                    break;
                case TipoOperacao.Subtratir:
                    Operacao = new SubtratirStrategy();
                    break;
            }
        }

        OperacaoStrategy Operacao { get; set; }

        public double VrOperacao { get; set; }

        public void CalcularOperacao(double v1, double v2)
        {
            VrOperacao = Operacao.Executar(v1, v2);
        }
    }

    internal class SomarStrategy : OperacaoStrategy
    {
        internal override double Executar(double n1, double n2)
        {
            return n1 + n2;
        }
    }

    internal class SubtratirStrategy : OperacaoStrategy
    {
        internal override double Executar(double n1, double n2)
        {
            if (n2 > n1)
            {
                throw new InvalidOperationException();
            }
            return n1 - n2;
        }
    }

    internal class MultiplicarStrategy : OperacaoStrategy
    {
        internal override double Executar(double n1, double n2)
        {
            return n1 * n2;
        }
    }

    internal class DividirStrategy : OperacaoStrategy
    {
        internal override double Executar(double n1, double n2)
        {
            if (n2 == 0)
            {
                throw new InvalidOperationException();
            }

            return n1 / n2;
        }
    }
}

namespace DesignPatterns.Strategy.App
{
    public class StrategyExemplo
    {

        CalculadoraContextStrategy calculadora;

        public TipoOperacao TipoOperacaoSelecionada { get; set; }

        public double Valor1 { get; set; }

        public double Valor2 { get; set; }


        void BtnRealizarCalculo_Click()
        {
            calculadora = new CalculadoraContextStrategy(TipoOperacaoSelecionada);

            calculadora.CalcularOperacao(Valor1, Valor2);

            Console.WriteLine(calculadora.VrOperacao);
        }

    }
}