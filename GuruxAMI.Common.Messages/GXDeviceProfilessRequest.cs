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
	public class GXDeviceProfilesRequest : IReturn<GXDeviceProfilesResponse>, IReturn
	{
        public ulong[] DataCollectorIDs
        {
            get;
            internal set;
        }

		public ulong[] DeviceIDs
		{
			get;
			internal set;
		}

        /// <summary>
        /// Collection of profile IDs to get.
        /// </summary>
        public ulong[] ProfileIDs
        {
            get;
            internal set;
        }

        public long UserID
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
        /// All all devie profile versions retuned. In default only latest version is retreaved.
        /// </summary>
        public bool All
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
        /// All preset templates returned.
        /// </summary>        
        /// <remarks>
        /// If null all device profiles are returned.
        /// </remarks>
        public bool? Preset
        {
            get;
            set;
        }

        public string Protocol
        {
            get;
            set;
        }

        public GXDeviceProfilesRequest(bool preset, string protocol, bool all, bool removed)
		{
            All = all;
            Preset = preset;
            Protocol = protocol;
            Removed = removed;
		}

        /// <summary>
        /// Return devive profiles that devices use.
        /// </summary>
        /// <param name="devices"></param>
        /// <param name="removed"></param>
        public GXDeviceProfilesRequest(GXAmiDevice[] devices, bool all, bool removed)
		{
            All = all;
            Removed = removed;
			if (devices != null)
			{
				int pos = -1;
				this.DeviceIDs = new ulong[devices.Length];
				for (int i = 0; i < devices.Length; i++)
				{
					GXAmiDevice it = devices[i];
					this.DeviceIDs[++pos] = it.Id;
				}
			}
		}

        /// <summary>
        /// Return devive profiles that devices use.
        /// </summary>
        /// <param name="devices"></param>
        /// <param name="removed"></param>
        public GXDeviceProfilesRequest(GXAmiDataCollector[] collectors, bool all, bool removed)
		{
            All = all;
            Removed = removed;
            if (collectors != null)
			{
				int pos = -1;
                this.DataCollectorIDs = new ulong[collectors.Length];
                for (int i = 0; i < collectors.Length; i++)
				{
                    this.DataCollectorIDs[++pos] = collectors[i].Id;
				}
			}
		}       
	}
}
