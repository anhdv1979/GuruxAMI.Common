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

using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
namespace GuruxAMI.Common.Messages
{
	public class GXValuesUpdateRequest : IReturn<GXValuesUpdateResponse>, IReturn
	{
        /// <summary>
        /// List of updated property IDs and values.
        /// </summary>
        public object[] Values
        {
            get;
            internal set;
        }

        public GXValuesUpdateRequest(GXAmiDataValue[] values)
		{
            Values = values;
		}

        public GXValuesUpdateRequest(GXAmiProperty property, object value)
        {
            Values = new GXAmiDataValue[]{new GXAmiDataValue(property.Id, Convert.ToString(value))};            
        }

        public GXValuesUpdateRequest(GXAmiProperty property, object value, uint rowIndex, uint columnIndex)
        {
            Values = new GXAmiDataRow[] { new GXAmiDataRow(property.ParentID, property.Id, Convert.ToString(value), rowIndex, columnIndex) };
        }
	}
}
