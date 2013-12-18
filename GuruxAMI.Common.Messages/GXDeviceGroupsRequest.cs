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
	public class GXDeviceGroupsRequest : IReturn<GXDeviceGroupResponse>, IReturn
	{
        /// <summary>
        /// Device Group Id
        /// </summary>
        public ulong Id
        {
            get;
            internal set;
        }

		public ulong DeviceId
		{
			get;
			internal set;
		}

        /// <summary>
        /// Get device groups that this Device Group owns.
        /// </summary>
        public ulong DeviceGroupId
        {
            get;
            internal set;
        }

        public long UserId
		{
			get;
			internal set;
		}
        public long UserGroupId
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
        /// Excluded device groups.
        /// </summary>
        public ulong[] Excluded
        {
            get;
            set;
        }

        /// <summary>
        /// Are removed item retreaved also.
        /// </summary>
        public bool Removed
        {
            get;
            set;
        }

		public GXDeviceGroupsRequest()
		{
		}

        public GXDeviceGroupsRequest(GXAmiDeviceGroup group)
        {
            this.DeviceGroupId = group.Id;
        }
		
        public GXDeviceGroupsRequest(GXAmiDevice device)
		{
            this.DeviceId = device.Id;
		}
		
        public GXDeviceGroupsRequest(GXAmiUser user)
		{
			this.UserId = user.Id;
		}

		public GXDeviceGroupsRequest(GXAmiUserGroup group)
		{
			this.UserGroupId = group.Id;
		}
	}
}
