using System;

namespace DesignPatterns.SRP.Implementacao
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Cpf Cpf { get; set; }
        public DateTime DataCadastro { get; set; }

        public bool Validar()
        {
            return Email.Validar() && Cpf.Validar();
        }
    }

    public class Cpf
    {
        //PROPRIEDADES

        public bool Validar() { return true; }
    }

    public class Email
    {
        //PROPRIEDADES
        public string Endereco { get; set; }

        public bool Validar() { return true; }
    }

    public class ClienteRepository
    {
        public void AdicionarCliente(Cliente cliente)
        {
            using (var cn = new SqlConnection())
            {
                //OPERACAO DE INSERT
            }
        }
    }

    public class ClienteService
    {
        public string AdicionarCliente(Cliente cliente)
        {
            if (!cliente.Validar())
                return "Dados inválidos";

            var repo = new ClienteRepository();
            repo.AdicionarCliente(cliente);

            EmailServices.Enviar("empresa@empresa.com", cliente.Email.Endereco, "Bem Vindo", "Parabéns está Cadastrado");

            return "Cliente cadastrado com sucesso";
        }
    }

    public static class EmailServices
    {
        public static string Enviar(string origem, string destino, string titulo, string mensagem)
        {
            return string.Empty;
        }
    }
}