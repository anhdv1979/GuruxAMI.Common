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
	public class GXErrorDeleteRequest : IReturn<GXErrorDeleteResponse>, IReturn
	{
		public uint[] DeviceErrorIDs
		{
			get;
			internal set;
		}
		public uint[] SystemErrorIDs
		{
			get;
			internal set;
		}
		public ulong DeviceID
		{
			get;
			internal set;
		}
		public ulong DeviceGroupID
		{
			get;
			internal set;
		}
		public bool Removed
		{
			get;
			set;
		}
		public GXErrorDeleteRequest(GXAmiDeviceError[] errors)
		{
			if (errors != null)
			{
				int pos = -1;
				this.DeviceErrorIDs = new uint[errors.Length];
				for (int i = 0; i < errors.Length; i++)
				{
					GXAmiDeviceError it = errors[i];
					this.DeviceErrorIDs[++pos] = it.Id;
				}
			}
		}
		public GXErrorDeleteRequest(GXAmiSystemError[] errors)
		{
			int pos = -1;
			this.SystemErrorIDs = new uint[errors.Length];
			for (int i = 0; i < errors.Length; i++)
			{
				GXAmiSystemError it = errors[i];
				this.SystemErrorIDs[++pos] = it.Id;
			}
		}
		public GXErrorDeleteRequest(GXAmiDevice device)
		{
			this.DeviceID = device.Id;
		}
		public GXErrorDeleteRequest(GXAmiDeviceGroup group)
		{
			this.DeviceGroupID = group.Id;
		}
	}
}
