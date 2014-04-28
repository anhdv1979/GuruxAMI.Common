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
    [Flags]
    [DataContract()]
    public enum ActionTargets
    {
        /// <summary>
        /// No target is selected.
        /// </summary>
        [EnumMember(Value = "0")]
        None = 0,
        /// <summary>
        /// Action target is database.
        /// </summary>
        [EnumMember(Value = "1")]        
        Database = 0x1,
        /// <summary>
        /// Action target is user.
        /// </summary>
        [EnumMember(Value = "2")]
        User = 0x2,
        /// <summary>
        /// Action target is user group.
        /// </summary>
        [EnumMember(Value = "4")]
        UserGroup = 0x4,
        /// <summary>
        /// Action target is device.
        /// </summary>
        [EnumMember(Value = "8")]
        Device = 0x8,
        /// <summary>
        /// Action target is device group.
        /// </summary>
        [EnumMember(Value = "16")]
        DeviceGroup = 0x10, 
        /// <summary>
        /// Action target is task.
        /// </summary>
        [EnumMember(Value = "32")]
        Task = 0x20,
        /// <summary>
        /// Action target is device profile.
        /// </summary>
        [EnumMember(Value = "64")]
        DeviceProfile = 0x40,
        /// <summary>
        /// Action target is data collector.
        /// </summary>
        [EnumMember(Value = "128")]
        DataCollector = 0x80,
        /// <summary>
        /// Device error.
        /// </summary>
        [EnumMember(Value = "256")]
        DeviceError = 0x100,
        /// <summary>
        /// System error.
        /// </summary>
        [EnumMember(Value = "512")]
        SystemError = 0x200,
        /// <summary>
        /// Property value is changed.
        /// </summary>
        [EnumMember(Value = "1024")]
        ValueChanged = 0x400,
        /// <summary>
        /// Property value is changed.
        /// </summary>
        [EnumMember(Value = "2048")]
        TableValueChanged = 0x800,
        /// <summary>
        /// Device or DC trace state is changed.
        /// </summary>
        [EnumMember(Value = "4096")]
        Trace = 0x1000,
        /// <summary>
        /// Schedule is changed.
        /// </summary>
        [EnumMember(Value = "8192")]
        Schedule = 0x2000,
    }
}
