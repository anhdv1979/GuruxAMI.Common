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
	public class GXScheduleActionRequest : IReturn<GXScheduleActionResponse>, IReturn
	{
        /// <summary>
        /// Executed schedules.
        /// </summary>
        public ulong[] ScheduleIDs
		{
			get;
			internal set;
		}

        /// <summary>
        /// Schedule actions.
        /// </summary>
        public Gurux.Device.ScheduleState Action
		{
			get;
			internal set;
		}

        /// <summary>
        /// Constructor.
        /// </summary>
		public GXScheduleActionRequest()
		{
		}

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXScheduleActionRequest(GXAmiSchedule[] schedules, Gurux.Device.ScheduleState action)
		{
			int pos = -1;
            this.ScheduleIDs = new ulong[schedules.Length];
			for (int i = 0; i < schedules.Length; i++)
			{
				GXAmiSchedule it = schedules[i];
				this.ScheduleIDs[++pos] = it.Id;
			}
            Action = action;
		}
	}
}
