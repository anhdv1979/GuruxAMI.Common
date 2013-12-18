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

using ServiceStack.ServiceHost;
using System;
namespace GuruxAMI.Common.Messages
{
	public class GXTasksRequest : IReturn<GXTasksResponse>, IReturn
	{
        /// <summary>
        /// Is data search from log table.
        /// </summary>
        public bool Log
        {
            get;
            internal set;
        }

        public ulong[] DeviceIDs
		{
			get;
			internal set;
		}
        public ulong[] DeviceGroupIDs
		{
			get;
			internal set;
		}
        public long[] UserIDs
		{
			get;
			internal set;
		}
        public long[] UserGroupIDs
		{
			get;
			internal set;
		}

        public ulong[] TaskIDs
        {
            get;
            internal set;
        }


        public TaskState State
		{
			get;
			internal set;
		}

        /// <summary>
        /// Start index.
        /// </summary>
        public int Index
        {
            get;
            set;
        }

        /// <summary>
        /// User count.
        /// </summary>
        public int Count
        {
            get;
            set;
        }

        /// <summary>
        /// Excluded task IDs.
        /// </summary>
        public ulong[] Excluded
        {
            get;
            set;
        }

        /// <summary>
        /// Get all tasks by state.
        /// </summary>
        /// <param name="state">Task state.</param>
        public GXTasksRequest(TaskState state)
		{
            State = state;
		}

        /// <summary>
        /// Get Device tasks by state.
        /// </summary>
        public GXTasksRequest(TaskState state, GXAmiDevice[] devices)
		{
            State = state;
            if (devices != null)
            {
                int pos = -1;
                this.DeviceIDs = new ulong[devices.Length];
                for (int i = 0; i < devices.Length; i++)
                {
                    this.DeviceIDs[++pos] = devices[i].Id;
                }
            }
		}

        /// <summary>
        /// Get device group tasks by state.
        /// </summary>
        public GXTasksRequest(TaskState state, GXAmiDeviceGroup[] groups)
		{
            State = state;
            if (groups != null)
            {
                int pos = -1;
                this.DeviceGroupIDs = new ulong[groups.Length];
                for (int i = 0; i < groups.Length; i++)
                {
                    this.DeviceGroupIDs[++pos] = groups[i].Id;
                }
            }
		}

        /// <summary>
        /// Get user tasks by state.
        /// </summary>
        public GXTasksRequest(TaskState state, GXAmiUser[] users)
		{
            State = state;
            if (users != null)
            {
                int pos = -1;
                this.UserIDs = new long[users.Length];
                for (int i = 0; i < users.Length; i++)
                {
                    this.UserIDs[++pos] = users[i].Id;
                }
            }
		}

        /// <summary>
        /// Get user group tasks by state.
        /// </summary>
        public GXTasksRequest(TaskState state, GXAmiUserGroup[] groups)
		{
            State = state;
            if (groups != null)
            {
                int pos = -1;
                this.UserGroupIDs = new long[groups.Length];
                for (int i = 0; i < groups.Length; i++)
                {
                    this.UserGroupIDs[++pos] = groups[i].Id;
                }
            }            
		}

        /// <summary>
        /// Get user group tasks by state.
        /// </summary>
        public GXTasksRequest(ulong[] tasks, bool log)
        {
            Log = log;
            if (tasks != null)
            {
                int pos = -1;
                this.TaskIDs = new ulong[tasks.Length];
                foreach (ulong it in tasks)
                {
                    this.TaskIDs[++pos] = it;
                }
            }
        }        
	}
}
