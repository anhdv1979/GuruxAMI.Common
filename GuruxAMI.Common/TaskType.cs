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
    /// A data contract enum representing Task Type values.
    /// Read, StopMonitor, StartSchedule etc.
    /// </summary>
    [DataContract()]
    public enum TaskType
    {
        /// <summary>
        /// Task type is not set.
        /// </summary>
        [EnumMember(Value = "0")]
        None,
        /// <summary>
        /// Read target, ie. a device or a property.
        /// </summary>
        [EnumMember(Value = "1")]
        Read,
        /// <summary>
        /// Write target, ie. a device or a property.
        /// </summary>
        [EnumMember(Value = "2")]
        Write,
        /// <summary>
        /// Start monitoring a device,
        /// </summary>
        [EnumMember(Value = "3")]
        StartMonitor,
        /// <summary>
        /// Stop monitoring a device,
        /// </summary>
        [EnumMember(Value = "4")]
        StopMonitor,
        /// <summary>
        /// Update a profile.
        /// </summary>
        [EnumMember(Value = "5")]
        ProfileUpdate,
        /// <summary>
        /// Update a device.
        /// </summary>
        [EnumMember(Value = "6")]
        ForceDeviceUpdate,
        /// <summary>
        /// Install a software package.
        /// </summary>
        [EnumMember(Value = "7")]
        InstallSoftware,
        /// <summary>
        /// Uninstall a software package.
        /// </summary>
        [EnumMember(Value = "8")]
        UninstallSoftware,
        /// <summary>
        /// Restart data collector.
        /// </summary>        
        [EnumMember(Value = "9")]
        Restart,
        /// <summary>
        /// Get Media property
        /// </summary>
        [EnumMember(Value = "10")]
        MediaGetProperty,        
        /// <summary>
        /// Set Media property
        /// </summary>
        [EnumMember(Value = "11")]
        MediaSetProperty,
        /// <summary>
        /// Open the media.
        /// </summary>
        [EnumMember(Value = "12")]
        MediaOpen,
        /// <summary>
        /// Close the media.
        /// </summary>
        [EnumMember(Value = "13")]
        MediaClose,
        /// <summary>
        /// Write byte array to the media.
        /// </summary>
        [EnumMember(Value = "14")]
        MediaWrite,
        /// <summary>
        /// Media state is changed.
        /// </summary>
        [EnumMember(Value = "15")]
        MediaState,
        /// <summary>
        /// Media error is occurred.
        /// </summary>
        [EnumMember(Value = "16")]
        MediaError
    }
}
