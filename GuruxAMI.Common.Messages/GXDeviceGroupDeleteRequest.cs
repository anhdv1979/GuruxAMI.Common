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
	public class GXDeviceGroupDeleteRequest : IReturn<GXDeviceGroupDeleteResponse>, IReturn
	{
		public ulong[] DeviceGroupIDs
		{
			get;
			internal set;
		}
		public ulong[] Parents
		{
			get;
			internal set;
		}
		public bool Permanently
		{
			get;
			set;
		}
		public GXDeviceGroupDeleteRequest(GXAmiDeviceGroup[] groups, bool permanently)
		{
			this.Permanently = permanently;
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
		public GXDeviceGroupDeleteRequest(GXAmiDeviceGroup[] groups, GXAmiDeviceGroup[] parents, bool permanently)
		{
			this.Permanently = permanently;
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
			if (parents != null)
			{
				int pos = -1;
				this.Parents = new ulong[parents.Length];
				for (int i = 0; i < parents.Length; i++)
				{
					GXAmiDeviceGroup it = parents[i];
					this.Parents[++pos] = it.Id;
				}
			}
		}
	}
}
