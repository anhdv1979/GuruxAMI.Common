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
#if !SS4
using ServiceStack.ServiceHost;
#else
using ServiceStack;
#endif

namespace GuruxAMI.Common.Messages
{
    public class GXDataCollectorUpdateRequest : IReturn<GXDataCollectorUpdateResponse>, IReturn
    {
        /// <summary>
        /// DC Mac Address.
        /// </summary>
        public byte[] MacAddress
        {
            get;
            internal set;
        }

        /// <summary>
        /// User group IDs that can use this DC.
        /// </summary>
        public long[] UserGroupIDs
        {
            get;
            internal set;
        }

        /// <summary>
        /// Datacollectors to add or update.
        /// </summary>
        public GXAmiDataCollector[] Collectors
        {
            get;
            internal set;
        }

        public GXDataCollectorUpdateRequest(byte[] mac)
        {
            MacAddress = mac;
        }

        public GXDataCollectorUpdateRequest(GXAmiDataCollector[] datacollectors, GXAmiUserGroup[] userGroups)
        {
            Collectors = datacollectors;
            if (userGroups != null)
            {
                int pos = -1;
                this.UserGroupIDs = new long[userGroups.Length];
                for (int i = 0; i < userGroups.Length; i++)
                {
                    this.UserGroupIDs[++pos] = userGroups[i].Id;
                }
            }            
        }       
    }
}
