using System;
using System.Collections.Generic;
using System.Text;
using minimax.core.adversarial;


namespace minimax.tictactoe
{
    class Program
    {
        public static void Main(string[] args)
        {
            

            while (true)
            {
                
                Console.WriteLine("   Tris-AI    ");

                //disegno campo
                disegnaCampo();
                Game game = new Game();

                List<Action> actions = new List<Action>();
                State state = game.GetInitialState();//statoiniziale


                AdversarialSearch<State, Action> adversarial;
                adversarial = new MinimaxSearchLimited<State, Action, Player>(game);

                while (!game.IsTerminal(state))
                {
                    //coordinate
                    Console.WriteLine("Scegli la coordinata della riga(0,1,2)");
                    int row = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Scegli la coordinata della colonna(0,1,2)");
                    int col = Convert.ToInt32(Console.ReadLine());

                    Action action = new Action(row, col);
                    actions = game.GetActions(state);

                    state = game.GetResult(state, action);
                    Tab(state);

                    if (!game.IsTerminal(state))
                    {
                        Action AzioneAI = adversarial.makeDecision(state);
                        state = game.GetResult(state, AzioneAI);
                        Tab(state);
                    }
                    
                    
                }
            }
        }
        public static void disegnaCampo()
        {
            Console.WriteLine("_____________");
            Console.WriteLine("|   |   |   |");
            Console.WriteLine("|   |   |   |");
            Console.WriteLine("|___|___|___|");
            Console.WriteLine("|   |   |   |");
            Console.WriteLine("|   |   |   |");
            Console.WriteLine("|___|___|___|");
            Console.WriteLine("|   |   |   |");
            Console.WriteLine("|   |   |   |");
            Console.WriteLine("|___|___|___|");
        }
        public static void Tab(State stato)
        {

            string[,] campoGioco = new string[3, 3];//viene riempito con  spazi, X, O, PER METTERLI NELLA Tab,USATO COME INDICE
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {
                    if (stato.campo[i, j] == -1)
                    {
                        campoGioco[i, j] = " ";  //se 0 = " "
                    }

                    else if (stato.campo[i, j] == 0)
                    {
                        campoGioco[i, j] = "X";  //se 1 = X
                    }
                    else
                    {
                        campoGioco[i, j] = "O";  //se 0 = O
                    }


                }
            }

            Console.WriteLine("_____________");
            Console.WriteLine("|   |   |   |");
            Console.WriteLine("| {0} | {1} | {2} |", campoGioco[0, 0], campoGioco[0, 1], campoGioco[0, 2]);
            Console.WriteLine("|___|___|___|");
            Console.WriteLine("|   |   |   |");
            Console.WriteLine("| {0} | {1} | {2} |", campoGioco[1, 0], campoGioco[1, 1], campoGioco[1, 2]);
            Console.WriteLine("|___|___|___|");
            Console.WriteLine("|   |   |   |");
            Console.WriteLine("| {0} | {1} | {2} |", campoGioco[2, 0], campoGioco[2, 1], campoGioco[2, 2]);
            Console.WriteLine("|___|___|___|");




        }
    }
}
