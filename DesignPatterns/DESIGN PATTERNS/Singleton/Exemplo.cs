namespace DesignPatterns.Singleton
{
    public class DB
    {
        public bool Insert(string nome)
        {
            return default;
        }
    }

    public class CodigosErro
    {
        public string ObterDescricaoErro(int codigo)
        {
            return default;
        }
    }

    public class Global
    {
        private static Global _instance;
        public static Global Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Global();
                }
                return _instance;
            }
        }

        static DB _dataBase;
        public DB DataBase
        {
            get
            {
                if (_dataBase == null)
                {
                    _dataBase = new DB();
                }
                return _dataBase;
            }
        }
        static CodigosErro _erros;
        public CodigosErro Erros
        {
            get
            {
                if (_erros == null)
                {
                    _erros = new CodigosErro();
                }
                return _erros;
            }
        }
    }

    public class App
    {
        void SalvarConta()
        {
            try
            {
                var nome = "NuBank";
                Global.Instance.DataBase.Insert(nome);
            }
            catch (System.Exception)
            {
                throw new System.Exception(Global.Instance.Erros.ObterDescricaoErro(123));
            }
        }
    }
}