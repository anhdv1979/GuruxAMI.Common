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
using System.Runtime.Serialization;
using System.ComponentModel;
namespace GuruxAMI.Common
{
	[Flags]
	public enum UserAccessRights
	{
        /// <summary>
        /// Access is denied.
        /// </summary>
        [EnumMember(Value = "0")]
		None = 0,

        /// <summary>
        /// SuperAdmin see all users and devices.
        /// </summary>
        [EnumMember(Value = "1")]
        SuperAdmin = 1,
               
        /// <summary>
        /// User Admin can modify and add new users to groups where user is.
        /// Only groups where user is are visible to the user.
        /// </summary>
        [EnumMember(Value = "2")]
		UserAdmin = 2,
        
        /// <summary>
        /// Device Admin can modify and add new devices to groups where user is.
        /// Only groups where user is are visible to the user.
        /// </summary>
        [EnumMember(Value = "4")]
		DeviceAdmin = 4,

        /// <summary>
        /// Normal user. User can read and write values.
        /// </summary>
        [EnumMember(Value = "8")]
        User = 8,

        /// <summary>
        /// User can't modify or make any transactions.
        /// User can only see values, not modify them.
        /// </summary>
        [EnumMember(Value = "16")]
		LimitedAccess = 16
	}
}
