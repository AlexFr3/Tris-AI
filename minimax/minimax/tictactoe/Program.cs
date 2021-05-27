using System;
using System.Collections.Generic;
using minimax.core.adversarial;

namespace minimax.tictactoe2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Tris-AI");

            State s = new State();
            Console.WriteLine(s.GetBoardState(0, 0));

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.WriteLine($"row={row}, col={col}, value={s.GetBoardState(row, col)}");
                }
            }

            Action a = new Action(1, 2);
            Console.WriteLine($"Riga={a.Row}, Colonna={a.Col}");


            Game g = new Game();
            s = g.GetInitialState();
            List<Action> mosse = g.GetActions(s);
            foreach (Action mossa in mosse)
            {
                Console.WriteLine($"Riga={mossa.Row}, Colonna={mossa.Col}");
            }


            g = new Game();
            s = g.GetInitialState();
            State newS = g.GetResult(s, new Action(1, 2));
            //Stampare lo stato per verificare che sia corretto


            //Fare anche dei test simili a quelli sopra, partendo da metà partita


            //Chiedere all'utente il livello di difficoltà (quanti livelli di profondità?
            //                                             o quanto tempo di computazione?)

            //Loop -> until partita finita
            // Chiedere la mossa all'utente
            // Calcolare il nuovo stato
            // Stampare il nuovo stato
            // Chiedere la mossa al computer
            // Calcolare il nuovo stato
            // Stampare il nuovo stato

            Game game = new Game();
            State state = game.GetInitialState();

            AdversarialSearch<State, Action> adversarialSearch;

            //Minimax: ricerca completa, ma ci metterebbe anni
            //a completare alberi di gioco troppo grandi
            adversarialSearch = new MinimaxSearch<State, Action, Player>(game);

            //Minimax limitato in profondità
            adversarialSearch = new MinimaxSearchLimited<State, Action, Player>(game, 3);

            //Iterative deepening
            adversarialSearch = new IterativeDeepening<State, Action, Player>(game,
                IterativeDeepening<State, Action, Player>.Algorithm.Minimax, 300);

        }

    }
}
