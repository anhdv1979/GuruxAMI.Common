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
    /// <summary>
    /// Returns trace levels.
    /// </summary>
    public class GXTracesRequest : IReturn<GXTracesResponse>, IReturn
	{
        /// <summary>
        /// Is item updated or added.
        /// </summary>
        public Guid[] DataCollectors
        {
            get;
            set;
        }

        public ulong[] DeviceIDs
        {
            get;
            internal set;
        }

        /// <summary>
        /// Trace level constructor for DataCollector.
        /// </summary>
        /// <param name="collectors"></param>
        /// <param name="level"></param>
        public GXTracesRequest(GXAmiDataCollector[] collectors)
		{
            int pos = -1;
            this.DataCollectors = new Guid[collectors.Length];
            for (int i = 0; i < collectors.Length; i++)
            {
                this.DataCollectors[++pos] = collectors[i].Guid;
            }
        }               

        /// <summary>
        /// Trace level constructor for Device.
        /// </summary>
        /// <param name="devices"></param>
        /// <param name="level"></param>
        public GXTracesRequest(GXAmiDevice[] devices)
		{
            int pos = -1;
            this.DeviceIDs = new ulong[devices.Length];
            for (int i = 0; i < devices.Length; i++)
            {
                this.DeviceIDs[++pos] = devices[i].Id;
            }
		}        
	}
}
