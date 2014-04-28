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
using System;
using System.Runtime.Serialization;
#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{
    [Serializable, Alias("DeviceGroup")]
	public class GXAmiDeviceGroup : IHasId<ulong>
	{
        [Alias("ID"), Index(Unique = true), DataMember]
		public ulong Id
		{
			get;
			set;
		}
		[DataMember]
		public string Name
		{
			get;
			set;
		}
		[DataMember]
		public string Description
		{
			get;
			set;
		}

        /// <summary>
        /// Date and time when the device group was created.
        /// </summary>      
		[DataMember]
		public DateTime Added
		{
			get;
			set;
		}

        /// <summary>
        /// Date and time when the device group was removed.
        /// </summary>      
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public DateTime? Removed
		{
			get;
			set;
		}

        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public Gurux.Device.DisabledActions DisabledActions
		{
			get;
			set;
		}

        /// <summary>
        /// Returns UserAccessRights enum valus as integer.
        /// </summary>
        [Alias("DisabledActions")]
        [DataMember()]
        public int DisabledActionsAsInt
        {
            get
            {
                return (int)DisabledActions;
            }
            set
            {
                DisabledActions = (Gurux.Device.DisabledActions)value;
            }
        }

		public GXAmiDeviceGroup() : this(null)
		{
		}

		public GXAmiDeviceGroup(string name)
		{
			this.Name = name;
		}
	}
}
