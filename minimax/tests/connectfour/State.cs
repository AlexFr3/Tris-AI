﻿using System;
using System.Collections.Generic;
using System.Text;
using minimax.tictactoe;
using minimax.connectfour;

namespace tests.connectfour
{
    public class State
    {
        public static readonly int EMPTY = -1;
        public static readonly int CROSS = (int)Player.Cross;
        public static readonly int CIRCLE = (int)Player.Circle;

        private int[,] board;
        private Player currentPlayer;

        public State()
        {
            board = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0;  j < 3;  j++)
                {
                    board[i, j]=EMPTY;
                }
                currentPlayer = Player.Cross;//inizia croce
            }
        }

        public State(int[,] board, Player player)
        {
            if (board.GetLength(0) !=3 || board.GetLength(1) != 3)
            {
                throw new ArgumentOutOfRangeException("Illegal board dimension");
            }
            this.board = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] != EMPTY && board[i, j] != CIRCLE && board[i,j] != CROSS)
                    {
                        throw new ArgumentOutOfRangeException("Illegal board state");
                    }
                    this.board[i, j] = board[i, j];
                }
            }
            this.currentPlayer = player;
        }
        public Player CurrentPlayer
        {
            get {
                return currentPlayer;
                }
        }
            
        public int[,] Board
        {
            get { return (int[,])board.Clone(); }
        }
        public int GetBoardValue(int row, int col)
        {
            if (row < 0 || row > 3)
            {
                throw new ArgumentOutOfRangeException("Illegal row");
            }
            if (col < 0 || col > 3)
            {
                throw new ArgumentOutOfRangeException("Illegal col");
            }
            return board[row, col];
        }
        
        public State GetResultingState(Action action)
        {
            int[,] newBoard = (int[,])board.Clone();
            newBoard[action.Row, action.Col] = (int)currentPlayer;

            Player player;

            //cambio player
            if (currentPlayer==Player.Circle)
            {
                player = Player.Cross;
            }
            else
            {
                player = Player.Circle;
            }
            return new State(newBoard, player);
        }


        //funzione per riga di comando
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<int, string> playerDict = new Dictionary<int, string>();
            playerDict[EMPTY] = "";
            playerDict[CIRCLE] = "0";
            playerDict[CROSS] = "X";

            sb.Append("Current player:");
            sb.Append(playerDict[(int)currentPlayer]);

            sb.Append("\nBoard");
            for (int i = 0; i < 3; i++)
            {
                sb.Append("" + playerDict[board[i, 0]] +
                    "|" + playerDict[board[i, 1]] +
                    "|" + playerDict[board[i, 2]] + "\n");
                if (i != 2)
                {
                    sb.Append("\n");
                }
            }

            return sb.ToString();
        }
    }
}
