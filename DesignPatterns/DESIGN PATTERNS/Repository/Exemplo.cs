using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Repository
{
    public class SecretariaModel
    {
        public List<Estudante> EstudantesEscola { get; set; }
    }

    public class Estudante
    {
        public int ID { get; set; }
        public string RA { get; set; }
    }

    public class EscolaContexto
    {
        public List<Estudante> Estudantes { get; set; }

        public void SaveChanges() { }
    }

    public interface IEstudanteRepositorio
    {
        List<Estudante> ObterEstudantes();
        Estudante ObterEstudantePorID(int ID);
        void InserirEstudante(Estudante estudante);
        void DeleteEstudantePorID(int ID);
        void Save();
    }

    public class EstudanteRepositorio : IEstudanteRepositorio
    {
        private EscolaContexto _Contexto;

        public EstudanteRepositorio(EscolaContexto contexto)
        {
            this._Contexto = contexto;
        }

        public void DeleteEstudantePorID(int ID)
        {
            var estudante = _Contexto.Estudantes.Find(e => e.ID == ID);
            _Contexto.Estudantes.Remove(estudante);
        }

        public void InserirEstudante(Estudante estudante)
        {
            _Contexto.Estudantes.Add(estudante);
        }

        public Estudante ObterEstudantePorID(int ID)
        {
            var estudante = _Contexto.Estudantes.SingleOrDefault(e => e.ID == ID);
            return estudante;
        }

        public List<Estudante> ObterEstudantes()
        {
            return _Contexto.Estudantes.ToList();
        }

        public void Save()
        {
            _Contexto.SaveChanges();
        }
    }

    public class EstudanteController
    {
        private IEstudanteRepositorio _EstudanteRepositorio;

        public EstudanteController()
        {
            _EstudanteRepositorio = new EstudanteRepositorio(new EscolaContexto());
        }

        public EstudanteController(IEstudanteRepositorio estudanteRepositorio)
        {
            this._EstudanteRepositorio = estudanteRepositorio;
        }

        public SecretariaModel GerarPainelSecretaria()
        {
            var estudantes = this._EstudanteRepositorio.ObterEstudantes();

            //Define regras de negocio do que será feito com os estudantes...

            var secretariaModel = new SecretariaModel 
            { 
                //Define dados do model...
            };

            return secretariaModel;

        }

    }
}