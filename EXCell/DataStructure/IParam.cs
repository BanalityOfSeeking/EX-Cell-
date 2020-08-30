﻿using System;

namespace EXCell.DataStructure
{
    public interface IParam
    {
        Type ParamType { get; }
        int MaxLen { get; }
        int MinLen { get; }
        string Name { get; }
        object Options { get; }
        string Value { get; }
    }
}