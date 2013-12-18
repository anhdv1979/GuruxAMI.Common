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
	public class GXUserDeleteRequest : IReturn<GXUserDeleteResponse>, IReturn
	{
		public long[] UserIDs
		{
			get;
			internal set;
		}
        public long[] GroupIDs
		{
			get;
			internal set;
		}
		public bool Permanently
		{
			get;
			set;
		}
		public GXUserDeleteRequest(GXAmiUser[] users, bool permanently)
		{
			this.Permanently = permanently;
			if (users != null)
			{
				int pos = -1;
                this.UserIDs = new long[users.Length];
				for (int i = 0; i < users.Length; i++)
				{
					GXAmiUser it = users[i];
					this.UserIDs[++pos] = it.Id;
				}
			}
		}
		public GXUserDeleteRequest(GXAmiUser[] users, GXAmiUserGroup[] groups, bool permanently)
		{
			this.Permanently = permanently;
			if (users != null)
			{
				int pos = -1;
                this.UserIDs = new long[users.Length];
				for (int i = 0; i < users.Length; i++)
				{
					GXAmiUser it = users[i];
					this.UserIDs[++pos] = it.Id;
				}
			}
			if (groups != null)
			{
				int pos = -1;
                this.GroupIDs = new long[groups.Length];
				for (int i = 0; i < groups.Length; i++)
				{
					GXAmiUserGroup it2 = groups[i];
					this.GroupIDs[++pos] = it2.Id;
				}
			}
		}
	}
}
