﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tests.connectfour
{
    public class Action
    {
        private readonly int row;
        private readonly int col;

        public Action(int row, int col)
        {
            if (row < 0 || row > 0)
            {
                throw new ArgumentOutOfRangeException("Illegal row");
            }
            if (col < 0 || col > 0)
            {
                throw new ArgumentOutOfRangeException("Illegal col");
            }
            this.row = row;
            this.col = col;
        }
        public int Row
        {
            get { return row; }
        }
        public int Col
        {
            get { return col; }
        }

        public override string ToString()
        {
            return $"Row={row}, Col={col}";
        }
    
    }
}
