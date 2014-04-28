//
// --------------------------------------------------------------------------
//  Gurux Ltd
// 
//
//
// Filename:        $HeadURL$
//
// Version:         $Revision$,
//                  $Date$
//                  $Author$
//
// Copyright (c) Gurux Ltd
//
//---------------------------------------------------------------------------
//
//  DESCRIPTION
//
// This file is a part of Gurux Device Framework.
//
// Gurux Device Framework is Open Source software; you can redistribute it
// and/or modify it under the terms of the GNU General Public License 
// as published by the Free Software Foundation; version 2 of the License.
// Gurux Device Framework is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of 
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. 
// See the GNU General Public License for more details.
//
// This code is licensed under the GNU General Public License v2. 
// Full text may be retrieved at http://www.gnu.org/licenses/gpl-2.0.txt
//---------------------------------------------------------------------------

using System;
#if !SS4
using ServiceStack.ServiceHost;
#else
using ServiceStack;
#endif

namespace GuruxAMI.Common.Messages
{
    public enum TableRequestType
    {
        RowCount,
        Rows
    }

	public class GXTableRequest : IReturn<GXTableResponse>, IReturn
	{
        public TableRequestType Type
		{
			get;
			internal set;
		}
        
		public ulong TableId
		{
			get;
			internal set;
		}

        /// <summary>
        /// Start index.
        /// </summary>
        public int Index
        {
            get;
            set;
        }

        /// <summary>
        /// Action count.
        /// </summary>
        public int Count
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor for get row count.
        /// </summary>
        public GXTableRequest(GXAmiDataTable table)
		{
            Type = TableRequestType.RowCount;
            TableId = table.Id;
		}

        /// <summary>
        /// Constructor for get table rows.
        /// </summary>
        public GXTableRequest(GXAmiDataTable table, int index, int count)
        {
            Type = TableRequestType.Rows;
            TableId = table.Id;
            Index = index;
            Count = count;
        }	
	}
}
