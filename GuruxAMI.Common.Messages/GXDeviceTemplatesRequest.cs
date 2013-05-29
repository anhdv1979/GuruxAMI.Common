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
	public class GXDeviceTemplatesRequest : IReturn<GXDeviceTemplatesResponse>, IReturn
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
        /// If null all templates are returned.
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

        public GXDeviceTemplatesRequest(bool preset, string protocol, bool removed)
		{
            Preset = preset;
            Protocol = protocol;
            Removed = removed;
		}

        /// <summary>
        /// Return devive templates that devices use.
        /// </summary>
        /// <param name="devices"></param>
        /// <param name="removed"></param>
        public GXDeviceTemplatesRequest(GXAmiDevice[] devices, bool removed)
		{
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
        /// Return devive templates that devices use.
        /// </summary>
        /// <param name="devices"></param>
        /// <param name="removed"></param>
        public GXDeviceTemplatesRequest(GXAmiDataCollector[] collectors, bool removed)
		{
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
