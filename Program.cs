using System;

namespace CadastroPessoas
{
    class Program
    {
        static void Main(string[] args)
        {   
            PessoaFisica person = new PessoaFisica();

            PessoaFisica pessoaAleatoria = new PessoaFisica();
            Endereco end = new Endereco();

            end.logradouro = "Y";
            end.numero = 100;
            end.complemento = "Proximo a Padaria Z";
            end.enderecoComercial = false;

            pessoaAleatoria.endereco = end;
            pessoaAleatoria.cpf = "0123456789";
            pessoaAleatoria.nome = "Pessoa Fisica";
            pessoaAleatoria.dataNascimento = new DateTime(2001, 01, 01);

            Console.WriteLine($@"Rua: {pessoaAleatoria.endereco.logradouro}, {pessoaAleatoria.endereco.numero}, {pessoaAleatoria.endereco.complemento}");

            bool idadeValida = person.ValidarDataNascimento(pessoaAleatoria.dataNascimento);

            if (idadeValida == true)
            {
                Console.WriteLine($"Cadastro Aprovado!");

            }else
            {
                Console.WriteLine($"Cadastro não autorizado! Não é permitido cadastrar menores de 18 anos.");
            }
                
                              
        }
    }
}   