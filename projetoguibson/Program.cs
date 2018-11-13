using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace projetoguibson
{
    //Integrantes da equipe:
    // Aluno : Vitor Manoel Carneiro dos Santos
    // Aluno : Carlos Henrique Dias Ribeiro
    // Aluno : Rebeka Ramos de Aguiar Silva
    // Aluno : Catarina Magalhães Rebouças

    class  Program
    {
          
        public static int[] arvore = new int[30];//o Vetor onde a arvore foi feita
        public static int numerosInseridos = 1; //Para saber quantos numeros já foram colocados na arvore
        
        static  void  Main(string[] args)
        {
      
            int procurar = 0; //Armazenar o numero a procurar na arvore
            int[] numeros = new int[10]; //Vetor com limite de 10 posições, sendo do 0 ao 9.
            
            
            Console.WriteLine("Digite os número aleatórios para ser organizados:");//Pedindo para o usuário preencher as posições.
            for(int i = 0; i < 10; i++) { numeros[i] = int.Parse(Console.ReadLine()); }// Laço for para agializar a coleta de dados

            Console.WriteLine("\nOs números organizados ficam da seguinte maneira:");//Exibindo os números organizados.
            CriarTree(numeros);//Criando Arvore Com o vetor bagunçado
            divisao(numeros);//Organizando o Vetor recebido
            foreach (int numero in numeros)//Utilizando o foreach para varrer o vetor.
            {
                Console.WriteLine(numero);
            }
            
            Console.WriteLine("Digite um numero para ser procurado na arvore:");
            procurar = int.Parse(Console.ReadLine());
            CompararNumeroArvore(1, procurar);          

        }

        public static void divisao(int[] VetorQuickSort, int esquerda = 0, int direita = 9)//Método do Quick sort, passando um vetor e duas variáveis inteiras como parâmetro. 
        {
            int i, j, k, l;//Variáveis que serão utilizadas dentro do escopo para manipular as informações cedidas no parâmetro.

            i = esquerda;//Atribuindo o valor da esquerda ao i.
            j = direita;//Atribuindo o valor da direita ao j.
            k = VetorQuickSort[(esquerda + direita) / 2];//Atribuindo o vetor que recebe como posição a esquerda + a direita / 2 ao k.

            while (i <= j)//While para mover os elementos da esquerda para a direita, enquanto forem menor que o pivô e menor que os elementos da direita.
            {
                while (VetorQuickSort[i] < k && i < direita)//Implementação do que foi citado na linha acima.
                {
                    i++;
                }
                while (VetorQuickSort[j] > k && j > esquerda)//A mesma coisa porém da direita para a esquerda.
                {
                    j--;
                }
                if (i <= j)//Aqui funciona o vetor auxiliar, que troca de lugar a esquerda e a direita assim que termina de executar a função acima, então é feita a checagem e então troca os dois de lugar. Sendo assim, o processo continua e ele só termina quando a esquerda for maior que a direita.
                {
                    l = VetorQuickSort[i];
                    VetorQuickSort[i] = VetorQuickSort[j];
                    VetorQuickSort[j] = l;
                    i++;
                    j--;
                }
            }

            if (j > esquerda)//O inicio recebe o último valor da direita, e a posição da direita, se torna o pivô.
            {
                divisao(VetorQuickSort, esquerda, j);
            }
            if (i < direita)
            {
                divisao(VetorQuickSort, i, direita);
            }
        }

        /*
         * Breve resumo da logica usada na arvore:
         * Usamos um vetor, onde cada "numero" possui 3 index
         * O primeiro [0] para salvar a filha da esquerda
         * O segundo [1] para salvar o valor 
         * O terceiro [2] para salvar a filha da direita
         * 
         * Na hora de organizar, nós verificamos os valores que tem em [0] e [1] para ver se possui filhos ou não
         * caso que não lá será salvo o valor da vez
         * Caso que tenha ele irá "entrar" nessa filha através da Index salva no [0] ou no [1]
         * E seguindo essa logica até o final.
         * 
        */

        //Nome do metodo feio do Jogo de mesmo nome, pois quand o primeiro jogo foi feito ele era a "Ultima esperança" da empresa não falir, e adivinha só, deu certo.
        public static void FinalFantasy(int valorAColocar, int index)//Metodo para colocar o valor na Arvore, saltando em 3 e 3
        {//ele recebe o valor a ser colado na árvore, e o index, para saber onde ele está e para onde deve ir comparar.

                
                if (valorAColocar > arvore[index])//Vai verificar se o valor da vez é maior que o valor do nó atual
                {
                    if (arvore[index+1] == 0)//Vai ver se a filha da direita está vazia ou não, se sim o valor será colocado lá
                    {
                        
                        arvore[1 + (numerosInseridos * 3)] = valorAColocar;// a posição 3 casas após do ultimo valor será preenchido
                        arvore[index + 1] = 1+(numerosInseridos * 3); // A filha maior do nó atual receberá o Index do novo nó colado
                        numerosInseridos++;// adicionando mais um aos numeros adicionados 
                        
                    }
                    else { FinalFantasy(valorAColocar, arvore[index + 1]);  }//caso não esteja vazio, ele irá repetir o método passando o Index da Filha maior

                }
                else
                {
                    if(valorAColocar < arvore[index])//vai verificar se o valor da vez é menor do que o do nó atual
                    {
                        if (arvore[index-1]==0 )// vai ver se a filha da esquerda está vazia, se sim irá por lá
                        {

                            arvore[1 + (numerosInseridos * 3)] = valorAColocar; // a posição 3 casas após do ultimo valor será preenchido
                            arvore[index - 1] = 1 + (numerosInseridos * 3); // A filha menor do nó atual receberá o Index do novo nó colado
                            numerosInseridos++;// adicionando mais um aos numeros adicionados 

                    }
                        else {  FinalFantasy(valorAColocar, arvore[index - 1]); }//caso não esteja vazio, ele irá repetir o método passando o Index da Filha menor
                }
                }
        }

        public static void CriarTree(int[] vet)//Metodo para criar uma arvore apartir de um vetor
        {
            foreach (int numero in vet)//para percorrer o vetor
            {             
                if (arvore[1] == 0)//Se a arvore estiver vazia esse numero será a Raiz
                {
                    arvore[1] = numero;                 
                }
                else//Caso não irá fazer a busca do lugar que esse numero pertence a àrvore
                {                 
                    FinalFantasy(numero, 1);//metodo já comentado anteriormente
                }    
            }      
        }

        public static void CompararNumeroArvore(int posicao,int comparar)// vai comparar o numero recebido com oque tem na árvore
        {//Recebendo a posicao (index), e o numero
            if (arvore[posicao] == comparar)//Verificando se é igual o valor dessa posição, se sim é porque ele pertence a árvore
            {
                Console.WriteLine("{0} Está na arvore", comparar);
            }
            else//Não é iguaal
            {
                if (comparar > arvore[posicao])// se o numero da vez for maior do que o do nó ele irá pegar o index do proximo maior que ele
                {
                    if (arvore[posicao+1] == 0 )//verificando se realmente tem alguem maior do que ele, se não tiver ele fala que não existe
                    {
                        Console.WriteLine("{0} Não está na arvore", comparar);
                    }
                    else { CompararNumeroArvore(arvore[posicao+1], comparar); }//caso tenha ele irá repetir o looping
                }
                if (comparar < arvore[posicao])// se o numero da vez for menor do que o do nó ele irá pegar o index do proximo menor do que ele
                {
                    if (arvore[posicao - 1] == 0)//verificando se realmente tem alguem menor do que ele, se não tiver ele fala que não existe
                    {
                        Console.WriteLine("{0} Não está na arvore", comparar);
                    }
                    else { CompararNumeroArvore(arvore[posicao -1], comparar); }//caso tenha ele irá repetir o looping

                }
            }
        }        
    }
}
