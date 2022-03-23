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
    public  class TelaCadastroAmigo
    {
        public Amigo[] amigos;
        public int numeroAmigo;
        public Notificador notificador;
        public RepositorioAmigo repositorioAmigo;

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirNovoAmigo()
        {
            MostrarTitulo("Inserindo nova Caixa");

            Amigo amigo = ObterAmigo();

            repositorioAmigo.Inserir(amigo);

            notificador.ApresentarMensagem("amigo inserida com sucesso!", "Sucesso");
        }

        private Amigo ObterAmigo()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsavel: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo();

            amigo.endereco = endereco;
            amigo.nome = nome;
            amigo.nomeRepsonsavel = nomeResponsavel;
            amigo.telefone = telefone;

            return amigo;
        }

        public void EditarAmigo()
        {
            MostrarTitulo("Editando Amigo");


            bool temAmigosCadastrados = VisualizarAmigos("Pesquisando");

            if (temAmigosCadastrados == false)
            {
                notificador.ApresentarMensagem("Nenhumo amigo cadastrada para poder editar", "Atencao");
                return;
            }
            string nome = ObterNomeAmigo();

            Amigo amigo = ObterAmigo();

            repositorioAmigo.Editar(nome, amigo);

            notificador.ApresentarMensagem("amigo editada com sucesso", "Sucesso");
        }

        private string ObterNomeAmigo()
        {
            bool nomeAmigoEncontrado;
            string nome;
            do
            {
                Console.Write("Digite o nome do amigo que deseja editar: ");
                nome = Console.ReadLine();

                nomeAmigoEncontrado = repositorioAmigo.VerificarNomeAmigoExiste(nome);
                if (nomeAmigoEncontrado == false)
                    notificador.ApresentarMensagem("nome do amigo não encontrado, digite novamente", "Atencao");

            } while (nomeAmigoEncontrado == false);
            return nome;
        }

        public void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }

        public void ExcluirAmigo()
        {
            MostrarTitulo("Excluindo Amigo");

            bool temAmigosCadastradas = VisualizarAmigos("Pesquisando");

            if (temAmigosCadastradas == false)
            {
                notificador.ApresentarMensagem(
                    "Nenhuma caixa cadastrada para poder excluir", "Atencao");
                return;
            }
            string nomeAmigo = ObterNomeAmigo();

            repositorioAmigo.Excluir(nomeAmigo);

            notificador.ApresentarMensagem("Amigo excluído com sucesso", "Sucesso");
        }

        public bool VisualizarAmigos(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de amigos");

            Amigo[] amigos = repositorioAmigo.SelecionarTodos();


            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    continue;

                Amigo a = amigos[i];

                Console.WriteLine("nome: " + a.nome);
                Console.WriteLine("nome do Responsavel: " + a.nomeRepsonsavel);
                Console.WriteLine("telefone: " + a.telefone);
                Console.WriteLine("endereco: " + a.endereco);

                Console.WriteLine();
            }
            return true;
        }

        public int ObterPosicaoVazia()
        {
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null)
                    return i;
            }

            return -1;
        }
    }
}

    

    


