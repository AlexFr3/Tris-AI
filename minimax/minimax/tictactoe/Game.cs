using System;
using System.Collections.Generic;
using System.Text;
using minimax.core.adversarial;

namespace minimax.tictactoe
{
    class Game : IGame<State, Action, Player>
    {
        public int vincitore;
        public List<Action> GetActions(State state)
        {
            List<Action> actions = new List<Action>();
            Action tmp;

            int[,] campo = state.campo;
            Player giocatoreCorrente = state.giocatoreCorrente;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (campo[row, col] == -1)
                    {
                        tmp = new Action(row, col);
                        actions.Add(tmp);
                    }
                }
            }
            return actions;
        }   //fatto

        public State GetInitialState()
        {
            // crea il campo iniziale, e riporta uno stato iniziale

            int[,] campo = new int[3, 3];
            State statoIniziale = new State();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    campo[i, j] = -1;

                }
            }
            
            return statoIniziale;
        } //fatto

        public Player GetPlayer(State state)
        {
            //Prende il giocatore che  sta per giocare
            Player giocatore = state.giocatoreCorrente;
            return giocatore;
        } //fatto
        public Player[] GetPlayers()
        {
            //creazione di un array con un giocatore con cerchio e uno croce 
            Player[] players = new Player[2] { Player.Cross, Player.Circle };
            return players;
        }

        

        public double GetUtility(State state, Player player)
        {
            int vincitore = ControlloCombinazioni(state);
            if (IsTerminal(state) == true)
            {
                if (vincitore == (int)player)
                    return double.PositiveInfinity - 1;
                else if (vincitore == -1)
                    return 0;
                else
                {
                    return double.NegativeInfinity + 1;
                }
            }

            return 0;
        }

        public bool IsTerminal(State state)
        {
            if ((ControlloCombinazioni(state) == (int)Player.Circle) || (ControlloCombinazioni(state) == (int)Player.Cross))
            {
                
                return true;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state.campo[i, j] == -1)
                    {
                        return false;
                    }
                }
            }
            return true;


        }//fatto
        public State GetResult(State state, Action actions)
        {
            /*
            -viene creato un nuovo stato
            -copia dallo stato precedente il contenuto e lo mette nel nuovo stato 
            -inverte il giocatore per es: da croce a cerchio
            -inserire la mossa nel nuovo stato
            -ritorna il nuovo stato
            */

            State statoCopiato = new State();
            statoCopiato.campo = (int[,])state.campo.Clone();
            statoCopiato.giocatoreCorrente = state.giocatoreCorrente;

            statoCopiato.campo[actions.Row, actions.Col] = (int)statoCopiato.giocatoreCorrente;
            if (statoCopiato.giocatoreCorrente == Player.Circle)
            {
                statoCopiato.giocatoreCorrente = Player.Cross;
            }
            else
            {
                statoCopiato.giocatoreCorrente = Player.Circle;
            }
            return statoCopiato;
        }//fatto

        public static int ControlloCombinazioni(State state)
        {
            //Controllo  combinazioni 
            for (int i = 0; i < 3; i++)
            {
                if (state.campo[i, 0] != -1)
                {
                    if ((state.campo[i, 0] == state.campo[i, 1]) && (state.campo[i, 0] == state.campo[i, 2]))
                    {
                        return state.campo[i, 0];
                    }

                }
                if (state.campo[0, i] != -1)
                {
                    if ((state.campo[0, i] == state.campo[1, i]) && (state.campo[0, i] == state.campo[2, i]))
                    {
                        return state.campo[0, i];
                    }
                }
            }
            if (state.campo[1, 1] != -1)
            {
                if ((state.campo[0, 0] == state.campo[1, 1]) && (state.campo[0, 0] == state.campo[2, 2]))
                {
                    return state.campo[1, 1];
                }
                else if ((state.campo[0, 2] == state.campo[1, 1]) && (state.campo[0, 2] == state.campo[2, 0]))
                {
                    return state.campo[1, 1];
                }
            }
            return -1;
        }//fatto
    }


}
