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
	public class GXDeviceUpdateRequest : IReturn<GXDeviceUpdateResponse>, IReturn
	{
        /// <summary>
        /// Is item updated or added.
        /// </summary>
        public Actions Action
        {
            get;
            set;
        }

		public GXAmiDevice[] Devices
		{
			get;
			internal set;
		}
		public GXAmiDeviceGroup[] DeviceGroups
		{
			get;
			internal set;
		}
		public GXDeviceUpdateRequest(Actions action, GXAmiDevice[] devices)
		{
            Action = action;
			this.Devices = devices;
		}

        public GXDeviceUpdateRequest(Actions action, GXAmiDevice[] devices, GXAmiDeviceGroup[] deviceGroups)
		{
            Action = action;
			this.Devices = devices;
			this.DeviceGroups = deviceGroups;
		}
	}
}
