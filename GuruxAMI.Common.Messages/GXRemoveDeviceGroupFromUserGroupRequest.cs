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
	public class GXRemoveDeviceGroupFromUserGroupRequest : IReturn<GXRemoveDeviceGroupFromUserGroupResponse>, IReturn
	{
		public long[] UserGroups
		{
			get;
			internal set;
		}
        public ulong[] DeviceGroups
        {
            get;
            internal set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXRemoveDeviceGroupFromUserGroupRequest(GXAmiDeviceGroup[] deviceGroups, GXAmiUserGroup[] userGroups)
		{
            DeviceGroups = new ulong[deviceGroups.Length];
            for (int pos = 0; pos != deviceGroups.Length; ++pos)
            {
                DeviceGroups[pos] = deviceGroups[pos].Id;
            }
            UserGroups = new long[userGroups.Length];
            for (int pos = 0; pos != userGroups.Length; ++pos)
            {
                UserGroups[pos] = userGroups[pos].Id;
            }			
		}
	}
}
