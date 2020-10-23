using System;
using System.Net.Mail;

namespace DesignPatterns.DIP.Implementacao
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
        public string Numero { get; set; }

        public bool Validar()
        {
            return Numero.Length == 11;
        }
    }
    public class Email
    {
        public string Endereco { get; set; }

        public bool Validar()
        {
            return Endereco.Contains("@");
        }
    }

    public interface IClienteRepository
    {
        void AdicionarCliente(Cliente cliente);
    }
    public interface IClienteServices
    {
        string AdicionarCliente(Cliente cliente);
    }
    public interface IEmailServices
    {
        void Enviar(string de, string para, string assunto, string mensagem);
    }

    public class ClienteRepository : IClienteRepository
    {
        public void AdicionarCliente(Cliente cliente)
        {

            using (var cn = new SqlConnection())
            {
                //OPERACAO DE INSERCAO NO BANCO
            }

        }
    }
    public class ClienteRepositoryMock : IClienteRepository
    {
        public void AdicionarCliente(Cliente cliente)
        {

            // Usar outra forma de ir até o BD

        }
    }
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmailServices _emailServices;

        public ClienteServices(
            IEmailServices emailServices,
            IClienteRepository clienteRepository)
        {
            _emailServices = emailServices;
            _clienteRepository = clienteRepository;
        }

        public string AdicionarCliente(Cliente cliente)
        {
            if (!cliente.Validar())
                return "Dados inválidos";

            _clienteRepository.AdicionarCliente(cliente);

            _emailServices.Enviar("empresa@empresa.com", cliente.Email.Endereco, "Bem Vindo", "Parabéns está Cadastrado");

            return "Cliente cadastrado com sucesso";
        }
    }
    public class EmailServices : IEmailServices
    {
        public void Enviar(string de, string para, string assunto, string mensagem)
        {
            var mail = new MailMessage(de, para);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = assunto;
            mail.Body = mensagem;
            client.Send(mail);
        }
    }

    public class TesteDip
    {
        IClienteServices _cliService;

        public TesteDip()
        {
            _cliService = new ClienteServices(new EmailServices(), new ClienteRepository());
        }
    }
}