﻿using System.Collections.Generic;

namespace Game.DataStructure
{
    public interface IGameSheet
    {
        public IReadOnlyRow AddRow(ParamBuilder builder);

        public IEnumerable<IGameCell> QueryCellOfType<T>(T type) where T : System.Enum;
    }
}