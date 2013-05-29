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
	public class GXDeviceGroupUpdateRequest : IReturn<GXDeviceGroupUpdateResponse>, IReturn
	{
        /// <summary>
        /// Is item updated or added.
        /// </summary>
        public Actions Action
        {
            get;
            set;
        }

		public GXAmiDeviceGroup[] Items
		{
			get;
			internal set;
		}
		public GXAmiDeviceGroup[] DeviceGroups
		{
			get;
			internal set;
		}
        public long[] UserGroupIDs
        {
            get;
            internal set;
        }

        public GXDeviceGroupUpdateRequest(Actions action, GXAmiDeviceGroup[] groups)
		{
            Action = action;
			this.Items = groups;
		}
        public GXDeviceGroupUpdateRequest(Actions action, GXAmiDeviceGroup[] items, GXAmiDeviceGroup[] parents)
		{
            Action = action;
			this.Items = items;
			this.DeviceGroups = parents;
		}

        public GXDeviceGroupUpdateRequest(Actions action, GXAmiDeviceGroup[] items, GXAmiUserGroup[] groups)
        {
            Action = action;
            this.Items = items;
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
	}
}
