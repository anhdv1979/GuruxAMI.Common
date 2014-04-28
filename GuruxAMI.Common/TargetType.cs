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
using System.Runtime.Serialization;
namespace GuruxAMI.Common
{
    /// <summary>
    /// A data contract enum representing Target Type values.
    /// Device, Property, DeviceProfiles, etc.
    /// </summary>
    [DataContract()]
    public enum TargetType
    {
        /// <summary>
        /// Target type is not set.
        /// </summary>
        [EnumMember(Value = "0")]
        None,
        /// <summary>
        /// Target is a data collector.
        /// </summary>
        [EnumMember(Value = "1")]
        DataCollector,
        /// <summary>
        /// Target is a device group.
        /// </summary>
        [EnumMember(Value = "2")]
        DeviceGroup,

        /// <summary>
        /// Target is a device.
        /// </summary>
        [EnumMember(Value = "3")]
        Device,

        /// <summary>
        /// Target is a category.
        /// </summary>
        [EnumMember(Value = "4")]
        Category,

        /// <summary>
        /// Target is a table.
        /// </summary>
        [EnumMember(Value = "5")]
        Table,
        
        /// <summary>
        /// Target is a property.
        /// </summary>
        [EnumMember(Value = "6")]
        Property,

        /// <summary>
        /// Target is a schedule item.
        /// </summary>
        [EnumMember(Value = "7")]
        Schedule,

        /// <summary>
        /// Target is a device profile.
        /// </summary>
        [EnumMember(Value = "8")]
        DeviceProfile,

        /// <summary>
        /// Target is a software package.
        /// </summary>
        [EnumMember(Value = "9")]
        SoftwarePackage,
        
        /// <summary>
        /// Media is the target.
        /// </summary>
        [EnumMember(Value = "10")]
        Media
    }
}
