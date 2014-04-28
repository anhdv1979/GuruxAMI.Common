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
using System.Text;
using System.Runtime.Serialization;

namespace GuruxAMI.Common
{
    /// <summary>
    /// What is searched.
    /// </summary>
    [Flags]
    [DataContract()]
    public enum SearchType
    {
        /// <summary>
        /// All field are searched.
        /// </summary>
        [EnumMember(Value = "-1")]
        All = -1,
        /// <summary>
        /// Search is made using name.
        /// </summary>
        [EnumMember(Value = "1")]
        Name = 0x1,
        /// <summary>
        /// Search is made using description.
        /// </summary>
        [EnumMember(Value = "2")]
        Description = 0x2
    }
}
