using System;
using System.Collections.Generic;
using System.Threading;

namespace CadastroPessoas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PessoaFisica> listaPf = new List<PessoaFisica>();

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
|                     Pessoa Física                      |
|               1 - Cadastrar Pessoa Física              |
|               2 - Listar Pessoa Física                 |
|               3 - Remover Pessoa Física                |
|                                                        |
|                    Pessoa Jurídica                     |
|               4 - Cadastrar Pessoa Jurídica            |
|               5 - Listar Pessoa Jurídica               |
|               6 - Remover Pessoa Jurídica              |
|                                                        |
|               0 - Sair                                 |
|________________________________________________________|
");
                opcao = Console.ReadLine();
                
                switch (opcao)
                {
                    case "1":
                        PessoaFisica Pessoa01 = new PessoaFisica();
                        PessoaFisica Pessoa02 = new PessoaFisica();
                        Endereco end = new Endereco();

                        Console.WriteLine($"Digite seu logradouro");
                        end.logradouro = Console.ReadLine();
                        
                        Console.WriteLine($"Digite o numero");
                        end.numero = int.Parse(Console.ReadLine());
                        
                        Console.WriteLine($"Digite o complemento (Aperte Enter se não houver");
                        end.complemento = Console.ReadLine();

                        Console.WriteLine($"Endereço comercial? S/N");
                        string enderecoComercial = Console.ReadLine().ToUpper();

                        if (enderecoComercial == "S")
                        {
                            end.enderecoComercial = true;
                        }else
                        {
                            end.enderecoComercial = false;
                        }

                        Pessoa02.endereco = end;

                        Console.WriteLine($"Digite seu CPF (somente numeros)");
                        Pessoa02.cpf = Console.ReadLine();

                        Console.WriteLine($"Digite seu nome");
                        Pessoa02.nome = Console.ReadLine();
                        
                        Console.WriteLine($"Digite seu rendimento mensal");                      
                        Pessoa02.rendimento = float.Parse(Console.ReadLine());
                        
                        Console.WriteLine($"Digite sua data de nascimento ex:AAAA/MM/DD");
                        Pessoa02.dataNascimento = DateTime.Parse(Console.ReadLine());                      

                        bool idadeValida = Pessoa01.ValidarDataNascimento(Pessoa02.dataNascimento);

                        if (idadeValida == true)
                        {
                            Console.WriteLine($"Cadastro Aprovado!");
                            listaPf.Add(Pessoa02);                        
                            Console.WriteLine(Pessoa01.PagarImposto(Pessoa02.rendimento));
                        }
                        else
                        {
                            Console.WriteLine($"Cadastro não autorizado!");
                        }
                                              
                        break;

                    case "2":
                            foreach (var item in listaPf)
                            {
                                Console.WriteLine($"{item.nome}, {item.cpf}, {item.endereco.logradouro}");                               
                            }
                        break;

                    case "3":
                            Console.WriteLine($"Digite o CPF que deseja remover");
                            string cpfProcurado = Console.ReadLine();
                            
                            PessoaFisica pessoaEncontrada = listaPf.Find(item => item.cpf == cpfProcurado);
                            if (pessoaEncontrada != null)
                            {
                                listaPf.Remove(pessoaEncontrada);
                                Console.WriteLine($"Cadastro Removido");                                    
                            }else
                            {
                                Console.WriteLine($"CPF não encontrado");
                                
                            }

                        break;

                    case "4":
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
                        novaPJuri.rendimento = 10000;

                        if (pJuri.ValidarCNPJ(novaPJuri.cnpj))
                        {
                            Console.WriteLine("CNPJ Válido");
                        }else
                        {
                           Console.WriteLine($"CNPJ Inválido");
                        }

                        Console.WriteLine(pJuri.PagarImposto(novaPJuri.rendimento));
                        
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