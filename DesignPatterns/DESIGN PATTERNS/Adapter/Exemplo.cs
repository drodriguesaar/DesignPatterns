namespace DesignPatterns.Adapter
{
    public interface ICacheFramework
    {
        string Guardar(string chave, string valor);
        string Recuperar(string chave);
    }

    public class CacheFrameworkFechadoMicrosoft : ICacheFramework
    {
        public string Guardar(string chave, string valor)
        {
            //Implementação utilizando os módulos e metodos do framework
            return string.Empty;
        }

        public string Recuperar(string chave)
        {
            //Implementação utilizando os módulos e metodos do framework
            return string.Empty;
        }
    }
    public class CacheFrameworkFechadoGoogle : ICacheFramework
    {
        public string Guardar(string chave, string valor)
        {
            //Implementação utilizando os módulos e metodos do framework
            return string.Empty;
        }

        public string Recuperar(string chave)
        {
            //Implementação utilizando os módulos e metodos do framework
            return string.Empty;
        }
    }

    public class TesteAdapter
    {
        ICacheFramework cacheFramework;
        public TesteAdapter()
        {
            cacheFramework = new CacheFrameworkFechadoGoogle();
        }

        void RealizarAcao()
        {
            cacheFramework.Guardar("chave", "valor");
            cacheFramework.Recuperar("chave");
        }
    }
}