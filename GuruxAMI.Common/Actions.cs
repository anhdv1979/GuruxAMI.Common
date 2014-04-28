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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GuruxAMI.Common
{
    [Flags]
    [DataContract()]
    public enum Actions
    {
        /// <summary>
        /// None action.
        /// </summary>
        [EnumMember(Value = "0")]
        None = 0x0,
        /// <summary>
        /// Items was retreaved.
        /// </summary>
        [EnumMember(Value = "1")]
        Get = 0x1,
        /// <summary>
        /// New item is added.
        /// </summary>
        [EnumMember(Value = "2")]
        Add = 0x2, 
        /// <summary>
        /// Item is edit.
        /// </summary>
        [EnumMember(Value = "4")]
        Edit = 0x4,
        /// <summary>
        /// Item is removed.
        /// </summary>
        [EnumMember(Value = "8")]
        Remove = 0x8,
        /// <summary>
        /// Device is read or write.
        /// </summary>
        [EnumMember(Value = "16")]
        Transaction = 0x10,
        /// <summary>
        /// Device, schedule or DC state is changed.
        /// </summary>
        [EnumMember(Value = "32")]
        State = 0x20,
    }
}
