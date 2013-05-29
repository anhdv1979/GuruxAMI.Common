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
	public class GXDeviceDeleteRequest : IReturn<GXDeviceDeleteResponse>, IReturn
	{
		public ulong[] DeviceIDs
		{
			get;
			internal set;
		}
		public ulong[] GroupIDs
		{
			get;
			internal set;
		}
		public bool Permamently
		{
			get;
			set;
		}
		public GXDeviceDeleteRequest(GXAmiDevice[] devices, bool permamently)
		{
			this.Permamently = permamently;
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
		public GXDeviceDeleteRequest(GXAmiDevice[] devices, GXAmiDeviceGroup[] groups, bool permamently)
		{
			this.Permamently = permamently;
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
			if (groups != null)
			{
				int pos = -1;
				this.GroupIDs = new ulong[groups.Length];
				for (int i = 0; i < groups.Length; i++)
				{
					GXAmiDeviceGroup it2 = groups[i];
					this.GroupIDs[++pos] = it2.Id;
				}
			}
		}
	}
}
