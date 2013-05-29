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
        [EnumMember]
        None,
        /// <summary>
        /// Read target, ie. a device or a property.
        /// </summary>
        [EnumMember]
        Read,
        /// <summary>
        /// Write target, ie. a device or a property.
        /// </summary>
        [EnumMember]
        Write,
        /// <summary>
        /// Start monitoring a device,
        /// </summary>
        [EnumMember]
        StartMonitor,
        /// <summary>
        /// Stop monitoring a device,
        /// </summary>
        [EnumMember]
        StopMonitor,
        /// <summary>
        /// Start a schedule.
        /// </summary>
        [EnumMember]
        StartSchedule,
        /// <summary>
        /// Stop a schedule.
        /// </summary>
        [EnumMember]
        StopSchedule,
        /// <summary>
        /// Run a schedule once.
        /// </summary>
        [EnumMember]
        RunSchedule,
        /// <summary>
        /// Update a template.
        /// </summary>
        [EnumMember]
        TemplateUpdate,
        /// <summary>
        /// Update a device.
        /// </summary>
        [EnumMember]
        ForceDeviceUpdate,
        /// <summary>
        /// Install a software package.
        /// </summary>
        [EnumMember]
        InstallSoftware,
        /// <summary>
        /// Uninstall a software package.
        /// </summary>
        [EnumMember]
        UninstallSoftware,
        /// <summary>
        /// Restart data collector.
        /// </summary>        
        [EnumMember]
        Restart,
        /// <summary>
        /// Open the media.
        /// </summary>
        [EnumMember]
        MediaOpen,
        /// <summary>
        /// Close the media.
        /// </summary>
        [EnumMember]
        MediaClose,
        /// <summary>
        /// Write byte array to the media.
        /// </summary>
        [EnumMember]
        MediaWrite,
        /// <summary>
        /// Media state is changed.
        /// </summary>
        [EnumMember]
        MediaState,
        /// <summary>
        /// Media error is occurred.
        /// </summary>
        [EnumMember]
        MediaError,
    }
}
