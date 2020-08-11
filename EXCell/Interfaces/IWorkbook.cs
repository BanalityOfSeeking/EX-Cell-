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

namespace EXCell.DataStructure
{
    public interface IWorkbook
    {
        Workbook AddSheet();
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}