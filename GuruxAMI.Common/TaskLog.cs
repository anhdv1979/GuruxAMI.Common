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

using ServiceStack.DataAnnotations;
using System;
using System.Runtime.Serialization;
namespace GuruxAMI.Common
{
    /// <summary>
    /// Tasks are saved to the log.
    /// </summary>
    [Serializable, Alias("TaskLog")]
	public class GXAmiTaskLog : GXAmiTask
	{
        [Alias("ID"), DataMember, Index(Unique = true)]
        public override ulong Id
        {
            get;
            set;
        }

        /// <summary>
        /// The time when the task was finished.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public DateTime? FinishTime
        {
            get;
            set;
        }

        public GXAmiTaskLog()
        {

        }
        public GXAmiTaskLog(GXAmiTask task)
        {
            Id = task.Id;
            Data = task.Data;
            TaskType = task.TaskType;
            Priority = task.Priority;
            TargetType = task.TargetType;
            TargetID = task.TargetID;
            TargetDeviceID = task.TargetDeviceID;
            UserID = task.UserID;
            SenderDataCollectorGuid = task.SenderDataCollectorGuid;
            State = task.State;
            DataCollectorID = task.DataCollectorID;
            DataCollectorGuid = task.DataCollectorGuid;
            CreationTime = task.CreationTime;
            ClaimTime = task.ClaimTime;
            ExpirationTime = task.ExpirationTime;
        }
	}
}
