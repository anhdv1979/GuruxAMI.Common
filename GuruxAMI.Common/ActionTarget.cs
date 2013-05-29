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

namespace GuruxAMI.Common
{
    [Flags]
    public enum ActionTargets
    {
        /// <summary>
        /// No target is selected.
        /// </summary>
        None = 0,
        /// <summary>
        /// Action target is database.
        /// </summary>
        Database = 0x1,
        /// <summary>
        /// Action target is user.
        /// </summary>
        User= 0x2,
        /// <summary>
        /// Action target is user group.
        /// </summary>
        UserGroup= 0x4,
        /// <summary>
        /// Action target is device.
        /// </summary>
        Device= 0x8,
        /// <summary>
        /// Action target is device group.
        /// </summary>
        DeviceGroup = 0x10, 
        /// <summary>
        /// Action target is task.
        /// </summary>
        Task = 0x20,
        /// <summary>
        /// Action target is device template.
        /// </summary>
        DeviceTemplate = 0x40,
        /// <summary>
        /// Action target is data collector.
        /// </summary>
        DataCollector = 0x80,
        /// <summary>
        /// Device error.
        /// </summary>
        DeviceError = 0x100,
        /// <summary>
        /// System error.
        /// </summary>
        SystemError = 0x200,
        /// <summary>
        /// Property value is changed.
        /// </summary>
        ValueChanged = 0x400,
        /// <summary>
        /// Property value is changed.
        /// </summary>
        TableValueChanged = 0x800,
        /// <summary>
        /// Device or DC trace state is changed.
        /// </summary>
        Trace = 0x1000,
    }
}
