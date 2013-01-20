﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSOFAPConsole.FAP.Interfaces;

namespace PSOFAPConsole.FAP
{
    public class CellInterferer : ICellInterferer
    {
        int cellIndex;
        readonly ICellRelation cellRelation;

        public CellInterferer(int cellIndex, ICellRelation cellRelation)
        {
            this.cellIndex = cellIndex;
            this.cellRelation = cellRelation;
        }

        #region ICellInterferer Members

        public int getCellIndex()
        {
            return cellIndex;
        }

        public ICellRelation getCellRelation()
        {
            return cellRelation;
        }

        #endregion

    }
}
