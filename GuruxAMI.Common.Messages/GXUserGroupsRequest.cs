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
    /// <summary>
    /// Returns available user groups.
    /// </summary>
    /// <remarks>
    /// If User Group is given return all users in user group.
    /// If Device is given returns all users that can access the device.
    /// If target is not given returns all visible users.
    /// </remarks>
	public class GXUserGroupsRequest : IReturn<GXUserGroupResponse>, IReturn
	{
        /// <summary>
        /// User ID.
        /// </summary>     
        public long UserId
		{
			get;
			internal set;
		}
        /// <summary>
        /// Device ID.
        /// </summary>      
		public ulong DeviceId
		{
			get;
			internal set;
		}
        /// <summary>
        /// Device group ID.
        /// </summary>      
		public ulong DeviceGroupId
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
        /// Are removed item retreaved also.
        /// </summary>
        public bool Removed
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
		public GXUserGroupsRequest()
		{
		}

        /// <summary>
        /// Search for the user group(s) to which the device group belongs to.
        /// </summary>
		public GXUserGroupsRequest(GXAmiDeviceGroup group)
		{
            if (group != null)
            {
                this.DeviceGroupId = group.Id;
            }
		}

        /// <summary>
        /// Search for the user group(s) to which the device belongs to.
        /// </summary>
        public GXUserGroupsRequest(GXAmiDevice device)
		{
            if (device != null)
            {
                this.DeviceId = device.Id;
            }
		}

        /// <summary>
        /// Search for the user group(s) to which the user belongs to.
        /// </summary>
        public GXUserGroupsRequest(GXAmiUser user)
		{
            if (user != null)
            {
                this.UserId = user.Id;
            }
		}
	}
}
