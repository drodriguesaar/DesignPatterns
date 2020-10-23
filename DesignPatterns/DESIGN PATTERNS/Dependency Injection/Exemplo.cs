
namespace DesignPatterns.DependencyInjection
{

    public enum TipoAlunoEnum
    {
        Graduacao = 1,
        PosGraduacao = 2,
        Mestrado = 3
    }
    public interface IAluno
    {
        string ObterNomeAluno(string RA);
    }


    public class AlunoGraduacao : IAluno
    {
        public string ObterNomeAluno(string RA)
        {
            throw new System.NotImplementedException();
        }
    }

    public class AlunoPosGraduacao : IAluno
    {
        public string ObterNomeAluno(string RA)
        {
            throw new System.NotImplementedException();
        }
    }

    public class AlunoMestrado : IAluno
    {
        public string ObterNomeAluno(string RA)
        {
            throw new System.NotImplementedException();
        }
    }

    public class AlunoNull : IAluno
    {
        public string ObterNomeAluno(string RA)
        {
            throw new System.NotImplementedException();
        }
    }

    public static class AlunoFactory
    {
        public static IAluno CriarAluno(TipoAlunoEnum tipoAluno)
        {
            switch (tipoAluno)
            {
                case TipoAlunoEnum.Graduacao:
                    return new AlunoGraduacao();
                case TipoAlunoEnum.PosGraduacao:
                    return new AlunoPosGraduacao();
                case TipoAlunoEnum.Mestrado:
                    return new AlunoMestrado();
                default:
                    return new AlunoNull();
            }

        }
    }


    public class TesteDependencyInjection
    {
        IAluno _aluno;

        public TesteDependencyInjection(IAluno aluno)
        {
            _aluno = aluno;
        }

        public void Executar()
        {
            _aluno.ObterNomeAluno("123456");
        }
    }

    public class ModuloConsultaAluno
    {
        TesteDependencyInjection testeDependencyInjection;

        public TipoAlunoEnum TipoAlunoSelecionado { get; set; }

        void BtnConsultarGerarNotas_Click()
        {
            testeDependencyInjection = new TesteDependencyInjection(AlunoFactory.CriarAluno(TipoAlunoSelecionado));
            testeDependencyInjection.Executar();
        }

    }
}