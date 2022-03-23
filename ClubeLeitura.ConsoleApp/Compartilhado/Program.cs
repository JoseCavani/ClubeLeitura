/**
 * O sistema deve permirtir o usuário escolher qual opção ele deseja
 *  -Para acessar o cadastro de caixas, ele deve digitar "1"
 *  -Para acessar o cadastro de revistas, ele deve digitar "2"
 *  -Para acessar o cadastro de amigquinhos, ele deve digitar "3"
 *  
 *  -Para gerenciar emprestimos, ele deve digitar "4"
 *  
 *  -Para sair, usuário deve digitar "s"
 */
using System;

namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Notificador notificador = new Notificador();
            TelaMenuPrincipal menuPrincipal = new TelaMenuPrincipal();
            TelaCadastroCaixa telaCadastroCaixa = new TelaCadastroCaixa();
            telaCadastroCaixa.notificador = notificador;

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            repositorioCaixa.caixas = new Caixa[10];


            telaCadastroCaixa.repositorioCaixa = repositorioCaixa;

            TelaCadastroAmigo telaCadastroAmigo = new TelaCadastroAmigo();
            telaCadastroAmigo.notificador = notificador;


            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            repositorioAmigo.amigos = new Amigo[10];

            telaCadastroAmigo.repositorioAmigo = repositorioAmigo;

            while (true)
            {                
                string opcaoMenuPrincipal = menuPrincipal.MostrarOpcoes();

                if (opcaoMenuPrincipal == "1")
                {
                    string opcao = telaCadastroCaixa.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroCaixa.InserirNovaCaixa();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroCaixa.EditarCaixa();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroCaixa.ExcluirCaixa();
                    }
                    else if (opcao == "4")
                    {
                        bool temCaixaCadastrada = telaCadastroCaixa.VisualizarCaixas("Tela");

                        if (temCaixaCadastrada == false)
                        {
                            notificador.ApresentarMensagem("Nenhuma caixa cadastrada", "Atencao");
                        }
                        Console.ReadLine(); 
                    }
                }
                if (opcaoMenuPrincipal == "3")
                {
                    string opcao = telaCadastroAmigo.MostrarOpcoes();

                    if (opcao == "1")
                    {
                        telaCadastroAmigo.InserirNovoAmigo();
                    }
                    else if (opcao == "2")
                    {
                        telaCadastroAmigo.EditarAmigo();
                    }
                    else if (opcao == "3")
                    {
                        telaCadastroAmigo.ExcluirAmigo();
                    }
                    else if (opcao == "4")
                    {
                        telaCadastroAmigo.VisualizarAmigos("Tela");
                        Console.ReadLine();
                    }
                }
            }
        }       
    }
}
