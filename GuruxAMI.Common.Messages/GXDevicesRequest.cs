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
	public class GXDevicesRequest : IReturn<GXDevicesResponse>, IReturn
	{
        /// <summary>
        /// Is content (Categories, tables and properties) returned also.
        /// </summary>
        public bool Content
        {
            get;
            set;
        }

        public long UserGroupID
		{
			get;
			internal set;
		}
		public long UserID
		{
			get;
			internal set;
		}

        public ulong DeviceGroupID
        {
            get;
            internal set;
        }

        public ulong DeviceID
        {
            get;
            internal set;
        }

        public ulong DataCollectorId
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
        /// Excluded devices.
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

		public GXDevicesRequest()
		{
		}
		public GXDevicesRequest(GXAmiDeviceGroup deviceGroup)
		{
            this.DeviceGroupID = deviceGroup.Id;
		}
		public GXDevicesRequest(GXAmiUserGroup userGroup)
		{
			this.UserGroupID = userGroup.Id;
		}
		public GXDevicesRequest(GXAmiUser user)
		{
			this.UserID = user.Id;
		}

        public GXDevicesRequest(GXAmiDataCollector collector)
        {
            this.DataCollectorId = collector.Id;
        }

        public GXDevicesRequest(GXAmiDevice device, bool content)
        {
            DeviceID = device.Id;
            Content = content;
        }
	}
}
