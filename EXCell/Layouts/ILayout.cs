// ***********************************************************************
// Assembly         : SSDMGMT.Data.Service
// Author           : rapril
// Created          : 06-30-2020
//
// Last Modified By : rapril
// Last Modified On :
// ***********************************************************************
// <copyright file="ParseBasicTemplate.cs" company="Supply Side Data Management LLC">
//     Copyright ©  2020 Supply Side Data Management. All rights reserved
// </copyright>
// <summary></summary>
// ***********************************************************************

using EXCell.ConfigurationStore;
using EXCell.DataStructure;
using System.Collections.Generic;

namespace EXCell.Layouts
{
    public interface ILayout
    {
        IEnumerable<IParam> LayoutParams(IRowLayoutManager manager);
    }
}