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
    /// <summary>
    /// //This enum is used to retrieve only necessary device info.
    /// It's slow to get all data from the meter if there are lots of meters.
    /// </summary>
    [DataContract()]
    public enum DeviceContentType
    {
        /// <summary>
        /// All information from the device is retrieved.
        /// </summary>
        [EnumMember(Value = "0")]
        All,
        /// <summary>
        /// Only main content like device ID, Guid, Name, Status and Type are retrieved.
        /// </summary>
        [EnumMember(Value = "1")]
        Main,
        /// <summary>
        /// All device info is retrieved. Catgories and properties are not retrieved.
        /// </summary>
        [EnumMember(Value = "2")]
        Device
    }
}
