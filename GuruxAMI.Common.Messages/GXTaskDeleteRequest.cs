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
#if !SS4
using ServiceStack.ServiceHost;
#else
using ServiceStack;
#endif

namespace GuruxAMI.Common.Messages
{
	public class GXTaskDeleteRequest : IReturn<GXTaskDeleteResponse>, IReturn
	{
		public ulong[] TaskIDs
		{
			get;
			internal set;
		}
        public long[] UserGroupIDs
		{
			get;
			internal set;
		}
		public ulong[] DeviceGroupIDs
		{
			get;
			internal set;
		}
		public ulong[] DeviceIDs
		{
			get;
			internal set;
		}
        public long[] UserIDs
		{
			get;
			internal set;
		}
		public GXTaskDeleteRequest(GXAmiTask[] tasks)
		{
			if (tasks != null)
			{
				int pos = -1;
				this.TaskIDs = new ulong[tasks.Length];
				for (int i = 0; i < tasks.Length; i++)
				{
					GXAmiTask it = tasks[i];
					this.TaskIDs[++pos] = it.Id;
				}
			}
		}
		public GXTaskDeleteRequest(GXAmiUser[] users)
		{
			if (users != null)
			{
				int pos = -1;
                this.UserIDs = new long[users.Length];
				for (int i = 0; i < users.Length; i++)
				{
					GXAmiUser it = users[i];
					this.UserIDs[++pos] = it.Id;
				}
			}
		}
		public GXTaskDeleteRequest(GXAmiUserGroup[] groups)
		{
			if (groups != null)
			{
				int pos = -1;
                this.UserGroupIDs = new long[groups.Length];
				for (int i = 0; i < groups.Length; i++)
				{
					GXAmiUserGroup it = groups[i];
					this.UserGroupIDs[++pos] = it.Id;
				}
			}
		}
		public GXTaskDeleteRequest(GXAmiDevice[] devices)
		{
			if (devices != null)
			{
				int pos = -1;
				this.DeviceIDs = new ulong[devices.Length];
				for (int i = 0; i < devices.Length; i++)
				{
					GXAmiDevice it = devices[i];
					this.DeviceIDs[++pos] = it.Id;
				}
			}
		}
		public GXTaskDeleteRequest(GXAmiDeviceGroup[] groups)
		{
			if (groups != null)
			{
				int pos = -1;
				this.DeviceGroupIDs = new ulong[groups.Length];
				for (int i = 0; i < groups.Length; i++)
				{
					GXAmiDeviceGroup it = groups[i];
					this.DeviceGroupIDs[++pos] = it.Id;
				}
			}
		}
	}
}
