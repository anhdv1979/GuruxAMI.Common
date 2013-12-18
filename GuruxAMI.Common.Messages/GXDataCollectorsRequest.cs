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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;

namespace GuruxAMI.Common.Messages
{
    public class GXDataCollectorsRequest : IReturn<GXDataCollectorsResponse>, IReturn
    {
        /// <summary>
        /// Get Data Collector by ID.
        /// </summary>
        public ulong DataCollectorId
        {
            get;
            internal set;
        }

        public ulong DeviceId
        {
            get;
            internal set;
        }

        public long UserId
        {
            get;
            internal set;
        }

        public bool UnAssigned
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
        /// Get data collectors by MAC address.
        /// </summary>
        public byte[] MacAddress
        {
            get;
            internal set;
        }

        /// <summary>
        /// Get data collectors by IP address.
        /// </summary>
        public string IPAddress
        {
            get;
            internal set;
        }

        /// <summary>
        /// Get data collectors by Guid.
        /// </summary>
        public Guid Guid
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
        /// Constructor.
        /// </summary>
        public GXDataCollectorsRequest(bool unassigned)
        {
            UnAssigned = unassigned;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXDataCollectorsRequest(GXAmiUser user)
        {
            if (user != null)
            {
                UserId = user.Id;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXDataCollectorsRequest(GXAmiDevice device)
        {
            if (device != null)
            {
                DeviceId = device.Id;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <remarks>
        /// Get data collectors by MAC address.
        /// </remarks>
        public GXDataCollectorsRequest(byte[] mac)
        {
            MacAddress = mac;
        }
        
        /// <summary>
        /// Get data collectors by IP address.
        /// </summary>
        /// <param name="ipAddress"></param>
        public GXDataCollectorsRequest(string ipAddress)
        {
            IPAddress = ipAddress;
        }

        /// <summary>
        /// Get data collectors by Guid.
        /// </summary>
        /// <param name="guid">Guid</param>
        public GXDataCollectorsRequest(Guid guid)
        {
            this.Guid = guid;
        }       
    }
}
