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

using System;
#if !SS4
using ServiceStack.ServiceHost;
#else
using ServiceStack;
#endif

namespace GuruxAMI.Common.Messages
{
	public class GXDevicesRequest : IReturn<GXDevicesResponse>, IReturn
	{     
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
            set;
        }

        public ulong DataCollectorId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Device profile IDs according to devices are searched.
        /// </summary>
        public ulong[] DeviceProfileIDs
        {
            get;
            set;
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
        /// Device count.
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

        /// <summary>
        /// What data is retreaved from the device.
        /// It's slow to get all data if you have lots of meters.
        /// </summary>
        public DeviceContentType Content
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

        public GXDevicesRequest(GXAmiDevice device)
        {
            DeviceID = device.Id;
        }
	}
}
