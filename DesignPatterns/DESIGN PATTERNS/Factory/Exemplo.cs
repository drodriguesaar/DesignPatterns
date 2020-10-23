namespace DesignPatterns.Factory
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


    public class TesteFactory
    {
        IAluno aluno;

        public void Executar() 
        { 
             aluno = AlunoFactory.CriarAluno(TipoAlunoEnum.Graduacao);
        }
    }

}