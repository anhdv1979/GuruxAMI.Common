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
using GuruxAMI.Common;
using System.Collections.Generic;

namespace GuruxAMI.Common.Messages
{
	public class GXTableResponse
	{
        /// <summary>
        /// TotoRow count in the selected table.
        /// </summary>
        public long Count
		{
			get;
			internal set;
		}

        /// <summary>
        /// Table rows.
        /// </summary>
        public object[][] Rows
		{
			get;
			internal set;
		}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="count"></param>
        public GXTableResponse(long count)
		{
            this.Count = count;
		}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rows"></param>
        public GXTableResponse(object[][] rows)
        {
            this.Rows = rows;
        }
	}
}
