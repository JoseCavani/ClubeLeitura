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

namespace ClubeLeitura.ConsoleApp
{
  
        public class RepositorioAmigo
        {
            public Amigo[] amigos;
            public void Inserir(Amigo amigo)
            {
                int posicaoVazia = ObterPosicaoVazia();
                amigos[posicaoVazia] = amigo;
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

            public Amigo[] SelecionarTodos()
            {
                int quantidadeAmigos = ObterQtdAmigos();

                Amigo[] amigosInseridas = new Amigo[quantidadeAmigos];

                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i] != null)
                        amigosInseridas[i] = amigos[i];
                }

                return amigosInseridas;
            }
            public int ObterQtdAmigos()
            {
                int numeroAmigos = 0;

                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i] != null)
                        numeroAmigos++;
                }

                return numeroAmigos;
            }
            public bool VerificarNomeAmigoExiste(string nome)
            {
                bool nomeAmigoEncontrado = false;
                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i] != null && amigos[i].nome == nome)
                    {
                        nomeAmigoEncontrado = true;
                    }
                }
                return nomeAmigoEncontrado;
            }
            public void Editar(string nomeSelecionado, Amigo amigo)
            {
                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i].nome == nomeSelecionado)
                    {
                        amigo.nome = nomeSelecionado;
                        amigos[i] = amigo;

                        break;
                    }
                }
            }
            public void Excluir(string nomeSelecionado)
            {
                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i].nome == nomeSelecionado)
                    {
                        amigos[i] = null;
                        break;
                    }
                }
            }
        }
    }


    

    


