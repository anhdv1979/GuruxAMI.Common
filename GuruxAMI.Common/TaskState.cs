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
    /// A data contract enum representing Task State values.
    /// Peding, Processing, Failed, etc.
    /// </summary>
    [DataContract()]
    public enum TaskState
    {
        /// <summary>
        /// Task is pending.
        /// </summary>
        [EnumMember]
        Pending,
        /// <summary>
        /// Task is being processed in a data collector.
        /// </summary>
        [EnumMember]
        Processing,
        /// <summary>
        /// Task has completed succefully.
        /// </summary>
        [EnumMember]
        Succeeded,
        /// <summary>
        /// Task has failed.
        /// </summary>
        [EnumMember]
        Failed,
        /// <summary>
        /// Task has timed out.
        /// </summary>
        [EnumMember]
        Timeout,
        /// <summary>
        /// All tasks.
        /// </summary>
        [EnumMember]
        All
    }
}
