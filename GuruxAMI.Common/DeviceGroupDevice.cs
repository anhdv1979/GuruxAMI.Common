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

using ServiceStack.DataAnnotations;
using ServiceStack.DesignPatterns.Model;
using System;
using System.Runtime.Serialization;
using ServiceStack.OrmLite;
namespace GuruxAMI.Common
{
    [Serializable, Alias("DeviceGroupDevice")]
    public class GXAmiDeviceGroupDevice : IHasId<long>
	{
        [Alias("ID"), AutoIncrement, Index()]
        public long Id
        {
            get;
            set;
        }

		[DataMember]
        [ForeignKey(typeof(GXAmiDevice), OnDelete = "CASCADE")]
        public ulong DeviceID
		{
			get;
			set;
		}

		[DataMember]
        [ForeignKey(typeof(GXAmiDeviceGroup), OnDelete = "CASCADE")]
		public ulong DeviceGroupID
		{
			get;
			set;
		}

		[DataMember]
		public DateTime Added
		{
			get;
			set;
		}
	}
}
