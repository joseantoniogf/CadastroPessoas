using System;
using System.Threading;

namespace CadastroPessoas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();    
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(@$"
 ________________________________________________________
|                                                        |
|            Bem-vindo ao sistema de cadastro            |
|           de Pessoa Física e Pessoa Jurídica.          |
|________________________________________________________|
");
            
            BarraCarregamento("Iniciando");

            string opcao;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(@$"
 ________________________________________________________
|                                                        |
|             Escolha uma das opções abaixo              |
|________________________________________________________|
|                                                        |
|                   1 - Pessoa Física                    |
|                   2 - Pessoa Jurídica                  |
|                                                        |
|                   0 - Sair                             |
|________________________________________________________|
");
                opcao = Console.ReadLine();
                
                switch (opcao)
                {
                    case "1":
                        PessoaFisica Pessoa01 = new PessoaFisica();

                        PessoaFisica Pessoa02 = new PessoaFisica();
                        Endereco end = new Endereco();

                        end.logradouro = "Y";
                        end.numero = 100;
                        end.complemento = "Proximo a Padaria Z";
                        end.enderecoComercial = false;

                        Pessoa02.endereco = end;
                        Pessoa02.cpf = "0123456789";
                        Pessoa02.nome = "Pessoa Fisica";
                        Pessoa02.dataNascimento = new DateTime(2001, 01, 01);

                        Console.WriteLine($@"Rua: {Pessoa02.endereco.logradouro}, {Pessoa02.endereco.numero}, {Pessoa02.endereco.complemento}");

                        bool idadeValida = Pessoa01.ValidarDataNascimento(Pessoa02.dataNascimento);

                        if (idadeValida == true)
                        {
                            Console.WriteLine($"Cadastro Aprovado!");

                        }else
                        {
                            Console.WriteLine($"Cadastro não autorizado! Não é permitido cadastrar menores de 18 anos.");
                        }
                        break;

                    case "2":
                        PessoaJuridica pJuri = new PessoaJuridica();
                        PessoaJuridica novaPJuri = new PessoaJuridica();
                        Endereco endJuri = new Endereco();

                        endJuri.logradouro = "Y";
                        endJuri.numero = 100;
                        endJuri.complemento = "Proximo a Padaria Z";
                        endJuri.enderecoComercial = true;

                        novaPJuri.endereco = endJuri;
                        novaPJuri.cnpj = "12345670000189";
                        novaPJuri.razaoSocial = "Pessoa Juridica";

                        if (pJuri.ValidarCNPJ(novaPJuri.cnpj))
                        {
                            Console.WriteLine("CNPJ Válido");
                        }else
                        {
                           Console.WriteLine($"CNPJ Inválido");
                        }
                        break;

                    case "0":
                        Console.WriteLine($"Obrigado por utilizar nosso sistema!");
                        BarraCarregamento("Finalizando");
                        
                        break;
                    default:
                        Console.WriteLine($"Opção inválida! Digite uma opção válida");
                        break;
                }
                
            } while (opcao != "0");    
                                                     
        }
    
        static void BarraCarregamento(string textoCarregamento){

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(textoCarregamento);
            Thread.Sleep(500);

            for (var contador = 0; contador < 10; contador++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.ResetColor();
        }
    }
}