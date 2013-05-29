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
	public class GXActionRequest : IReturn<GXActionResponse>, IReturn
	{
		public ulong Device
		{
			get;
			internal set;
		}
		public ulong DeviceGroup
		{
			get;
			internal set;
		}
        public long User
		{
			get;
			internal set;
		}
        public long UserGroup
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
        /// Action count.
        /// </summary>
        public int Count
        {
            get;
            set;
        }

		public GXActionRequest()
		{
		}
		public GXActionRequest(GXAmiDevice device)
		{
			this.Device = device.Id;
		}
		public GXActionRequest(GXAmiDeviceGroup group)
		{
			this.DeviceGroup = group.Id;
		}
		public GXActionRequest(GXAmiUser user)
		{
			this.User = user.Id;
		}
		public GXActionRequest(GXAmiUserGroup group)
		{
			this.UserGroup = group.Id;
		}
	}
}
