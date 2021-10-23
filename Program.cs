using System;

namespace CadastroPessoas
{
    class Program
    {
        static void Main(string[] args)
        {   
            // PessoaFisica Pessoa01 = new PessoaFisica();

            // PessoaFisica Pessoa02 = new PessoaFisica();
            // Endereco end = new Endereco();

            // end.logradouro = "Y";
            // end.numero = 100;
            // end.complemento = "Proximo a Padaria Z";
            // end.enderecoComercial = false;

            // Pessoa02.endereco = end;
            // Pessoa02.cpf = "0123456789";
            // Pessoa02.nome = "Pessoa Fisica";
            // Pessoa02.dataNascimento = new DateTime(2001, 01, 01);

            // Console.WriteLine($@"Rua: {Pessoa02.endereco.logradouro}, {Pessoa02.endereco.numero}, {Pessoa02.endereco.complemento}");

            // bool idadeValida = Pessoa01.ValidarDataNascimento(Pessoa02.dataNascimento);

            // if (idadeValida == true)
            // {
            //     Console.WriteLine($"Cadastro Aprovado!");

            // }else
            // {
            //     Console.WriteLine($"Cadastro não autorizado! Não é permitido cadastrar menores de 18 anos.");
            // }

            PessoaJuridica pJuri = new PessoaJuridica();
            PessoaJuridica novaPJuri = new PessoaJuridica();
            Endereco end = new Endereco();

            end.logradouro = "Y";
            end.numero = 100;
            end.complemento = "Proximo a Padaria Z";
            end.enderecoComercial = true;

            novaPJuri.endereco = end;
            novaPJuri.cnpj = "1234567800001";
            novaPJuri.razaoSocial = "Pessoa Juridica";

            if (pJuri.ValidarCNPJ(novaPJuri.cnpj))
            {
                Console.WriteLine("CNPJ Válido");
            }else
            {
               Console.WriteLine($"CNPJ Inválido");
            }
                                                     
        }
    }
}   