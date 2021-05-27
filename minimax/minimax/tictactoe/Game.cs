using System;
using System.Collections.Generic;
using minimax.core.adversarial;

namespace minimax.tictactoe2
{
    public class Game : IGame<State, Action, Player>
    {
        //Media
        public List<Action> GetActions(State state)
        {
            throw new NotImplementedException();
        }

        //Facile
        public State GetInitialState()
        {
            throw new NotImplementedException();
        }

        //Facile
        public Player GetPlayer(State state)
        {
            throw new NotImplementedException();
        }

        //Facile
        public Player[] GetPlayers()
        {
            throw new NotImplementedException();
        }

        //Media+
        //CREARE UN NUOVO STATO, NON MODIFICARE LO STATO IN INGRESSO
        public State GetResult(State state, Action action)
        {
            //Creare un nuovo stato
            //Copiare il contenuto dello stato precedente nel nuovo stato
            //Invertire il giocatore (se era Cross mettere Circle, e viceversa)
            //Inserire la mossa nel nuovo stato
            //Ritornare il nuovo stato

            throw new NotImplementedException();
        }


        //Difficile+
        public double GetUtility(State state, Player player)
        {
            //Se player ha vinto, ritorna valore alto (double.PositiveInfinity - 1)
            //Se player ha perso (cioè avversario ha vinto), ritorna valore basso (double.NegativeInfinity + 1)
            //Se è un pareggio, ritorna 0

            //TUTTO IL RESTO, ritorna 0
            throw new NotImplementedException();
        }


        //Difficile
        public bool IsTerminal(State state)
        {

            //Se c'è un tris verticale, ritorna true
            //Se c'è un tris orizzontale, ritorna true
            //Se c'è un tris diagonale, ritorna true
            //Se la board è piena, ritorna true
            return false;
        }
    }
}
