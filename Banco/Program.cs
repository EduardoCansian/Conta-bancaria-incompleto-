using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Banco
{
    internal class Program
    {
        private static List<Pessoa> contas = new List<Pessoa>();
        static Pessoa novaconta;
        static void Main(string[] args)
        {
            int op2 = char.MinValue;
            int op3 = char.MinValue;

            while (op2 != 1)
            {
                Console.Clear();
                Console.WriteLine("Olá, seja bem vindo(a) ao nosso aplicativo de conta bancária.");
                Console.WriteLine("\n1) Criar uma nova conta. \n2) Já possuo uma conta.");
                Console.Write("\nSelecione uma das opções acima:");
                op3 = int.Parse(Console.ReadLine()!);

                switch (op3)
                {
                    case 1:
                        Console.Clear();
                        if(contas.Count < 3)
                        {
                            CriarConta();
                            Menu();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Desculpe, só é possível criar no máximo 3 contas bancárias.");
                            Console.WriteLine("Pressione qualquer tecla para voltar à tela de login");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        if(contas.Count > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Insira a senha de uma conta existente para acessá-la.");
                            int verificacao = int.Parse(Console.ReadLine()!);

                            if(contas.Exists(senha => senha.Senha == verificacao))
                            {
                                Menu();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Senha incorreta.");
                                Console.WriteLine("Presione qualquer tecla para voltar à tela de login.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Não há nehuma conta cadastrada no sistema");
                            Console.WriteLine("Presione qualquer tecla para voltar à tela de login.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida, tente novamente.");
                        Console.WriteLine("Presione qualquer tecla para voltar à tela de login.");
                        Console.ReadKey();
                        break;
                }

                static void CriarConta()
                {
                    novaconta = new Pessoa();

                    Console.WriteLine("Olá, primeiramente vamos começar o seu cadastro.\n");
                    Console.WriteLine("Digite seu nome:");
                    novaconta.Nome = Console.ReadLine()!;

                    Console.WriteLine("\nDigite seu sobrenome:");
                    novaconta.Sobrenome = Console.ReadLine()!;

                    Console.WriteLine("\nDigite seu CPF:");
                    novaconta.Cpf = long.Parse(Console.ReadLine()!);

                    Console.WriteLine("\nDigite sua data de nascimento (dd/MM/yyy):");
                    novaconta.DataNascimento = DateOnly.Parse(Console.ReadLine()!);

                    Console.WriteLine("\nDigite seu telefone:");
                    novaconta.Telefone = int.Parse(Console.ReadLine()!);

                    Console.WriteLine("\nDigite seu email:");
                    novaconta.Email = Console.ReadLine()!;

                    Console.WriteLine("\nAgora insira sua senha que deverá conter 4 dígitos:");
                    novaconta.Senha = int.Parse(Console.ReadLine()!);

                    contas.Add(novaconta);

                    Console.Clear();
                    Console.WriteLine("Sua conta bancária foi criada com sucesso.");
                    Console.WriteLine("Presione qualquer tecla para ser direcionado ao Menu principal.");
                    Console.ReadKey();
                }
                static void Menu()
                {
                    int op = char.MinValue;
                    while (op != 4)
                    {
                        Console.Clear();
                        Console.WriteLine($"Olá, {novaconta.Nome} {novaconta.Sobrenome}.");
                        Console.WriteLine($"\nSaldo disponível: R$ {novaconta.Saldo:F2}");
                        Console.WriteLine("\n>>>>> MENU PRINCIPAL <<<<< \n1) Depositar dinheiro \n2) Sacar dinheiro \n3) Acessar meus dados pessoais \n4) Sair");
                        Console.Write("Selecione uma das opções acima:");
                        op = int.Parse(Console.ReadLine()!);

                        switch (op)
                        {
                            case 1:
                                Console.Clear();
                                Depositar();
                                break;
                            case 2:
                                Console.Clear();
                                Sacar();
                                break;
                            case 3:
                                Console.Clear();
                                AcessarDados();
                                break;
                            case 4:
                                Console.Clear();
                                Sair();
                                break;
                            default:
                                Console.WriteLine("Opção inválida, tente novamente");
                                break;
                        }
                    }
                }

                static void Depositar()
                {
                    Console.Clear();
                    Console.WriteLine("----> Por motivos de segurança insira sua senha <----");
                    int acesso = int.Parse(Console.ReadLine()!);
                    if (acesso == novaconta.Senha)
                    {
                        Console.Clear();
                        Console.WriteLine($"Saldo disponível: R$ {novaconta.Saldo:F2}");
                        Console.WriteLine("\nDigite a quantidade que deseja depositar em sua conta:");
                        double valor = double.Parse(Console.ReadLine()!);
                        novaconta.Saldo += valor;
                        Console.Clear();
                        Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso");
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu inicial.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\nSenha incorreta.");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
                        Console.ReadKey();
                    }
                }

                static void Sacar()
                {
                    Console.Clear();
                    Console.WriteLine("----> Por motivos de segurança insira sua senha <----");
                    int acesso = int.Parse(Console.ReadLine()!);
                    if (acesso == novaconta.Senha)
                    {
                        Console.Clear();
                        Console.WriteLine($"Saldo disponível: R$ {novaconta.Saldo:F2}");
                        Console.WriteLine("\nDigite o valor que deseja sacar:");
                        double valor = double.Parse(Console.ReadLine()!);
                        if (valor < novaconta.Saldo)
                        {
                            novaconta.Saldo -= valor;
                            Console.Clear();
                            Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso");
                            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu inicial.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Saldo insuficiente para saque.");
                            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu inicial.");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Senha incorreta.");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
                        Console.ReadKey();
                    }
                }

                static void AcessarDados()
                {
                    Console.Clear();
                    Console.WriteLine("----> Por motivos de segurança insira sua senha <----");
                    int acesso = int.Parse(Console.ReadLine()!);
                    if (acesso == novaconta.Senha)
                    {
                        Console.Clear();
                        Console.WriteLine("Seus dados pessoais:");
                        Console.WriteLine($"{novaconta.ObterDados()}");
                        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu inicial.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Senha incorreta.");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu inicial.");
                        Console.ReadKey();
                    }
                }

                static void Sair()
                {
                    int op2 = char.MinValue;
                    while (op2 != 2 && op2 != 1)
                    {
                        inicio:
                        Console.Clear();
                        Console.WriteLine("1) Sair do programa \n2) Sair da conta \n3) Contas disponíveis");
                        Console.WriteLine("Selecione uma das opções:");
                        op2 = int.Parse(Console.ReadLine()!);

                        switch (op2)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Obrigado por usar nosso programa e até mais.");
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("----> Por motivos de segurança insira sua senha para sair da conta <----");
                                int acesso = int.Parse(Console.ReadLine()!);
                                if (acesso == novaconta.Senha)
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Uma pena que você vai embora, {novaconta.Nome}. Até mais");
                                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
                                    Console.ReadKey();

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Senha incorreta.");
                                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                                    Console.ReadKey();
                                    goto inicio;
                                }
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Contas:");
                                foreach (var c in contas)
                                {
                                    Console.WriteLine(c.Resumo());
                                }
                                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
                                Console.ReadKey();
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Opção inválida, tente novamente");
                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                                Console.ReadKey();
                                break;
                        }
                    }
                }

            }
        }
    }
}