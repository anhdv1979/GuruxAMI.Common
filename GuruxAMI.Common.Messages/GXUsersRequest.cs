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
    /// Returns collection of users.
    /// </summary>
    /// <remarks>
    /// If User Group is given return all users in user group.
    /// If Device is given returns all users that can access the device.
    /// If target is not given returns all visible users.
    /// </remarks>
	public class GXUsersRequest : IReturn<GXUsersResponse>, IReturn
	{
		public ulong DeviceID
		{
			get;
			internal set;
		}
        public long UserGroupID
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
        /// Returns all users.
        /// </summary>
		public GXUsersRequest()
		{
		}

        /// <summary>
        /// Returns users who can access device.
        /// </summary>
        /// <param name="device"></param>
		public GXUsersRequest(GXAmiDevice device)
		{
			if (device != null)
			{
				this.DeviceID = device.Id;
			}
		}

        /// <summary>
        /// Returns users who belong to user group.
        /// </summary>
        public GXUsersRequest(GXAmiUserGroup userGroup)
		{
			if (userGroup != null)
			{
				this.UserGroupID = userGroup.Id;
			}
		}
	}
}
