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
using System.ComponentModel.DataAnnotations;
using Gurux.Device;

namespace GuruxAMI.Common
{
	[Serializable]
    [Alias("DataCollector")]    
    public class GXAmiDataCollector : IHasId<ulong>
	{
        [Alias("ID"), AutoIncrement, DataMember]
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

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return this.Guid.ToString();
            }
            return Name;
        }

        /// <summary>
        /// Each data collector has unique identifier.
        /// </summary>
        [DataMember]
        public Guid Guid
        {
            get;
            set;
        }

        /// <summary>
        /// Available serial ports.
        /// </summary>
        [DataMember]
        public string[] SerialPorts
        {
            get;
            set;
        }

        /// <summary>
        /// Medias available.
        /// </summary>
        [DataMember]
        public string[] Medias
        {
            get;
            set;
        }
		
        [DataMember]
		public DateTime? LastRequestTimeStamp
		{
			get;
			set;
		}
		
        /// <summary>
        /// Data collector's last IP address.
        /// </summary>
        [DataMember, StringLength(30)]
		public string IP
		{
			get;
			set;
		}

        /// <summary>
        /// Data collector's last MAC address.
        /// </summary>
		[DataMember, StringLength(40)]
		public string MAC
		{
			get;
			set;
		}

        /// <summary>
        /// Device state.
        /// </summary>
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public DeviceStates State
        {
            get;
            set;
        }

        /// <summary>
        /// Returns State enum valus as integer.
        /// </summary>
        /// <remarks>
        /// This value is saved to the DB.
        /// </remarks>
        [Alias("State")]
        [DataMember()]
        public virtual int StatesAsInt
        {
            get
            {
                return (int)State;
            }
            set
            {
                State = (DeviceStates)value;
            }
        }

        /// <summary>
        /// Data Collector is registering by itself.
        /// </summary>
        /// <remarks>
        /// DC is not assigned to anyone.
        /// </remarks>
        [DataMember]
		public bool UnAssigned
		{
			get;
			set;
		}

        /// <summary>
        /// Used trace level.
        /// </summary>
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public System.Diagnostics.TraceLevel TraceLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Returns TraceLevel enum valus as integer.
        /// </summary>
        [Alias("TraceLevel")]
        [DataMember()]
        public int TraceLevelAsInt
        {
            get
            {
                return (int)TraceLevel;
            }
            set
            {
                TraceLevel = (System.Diagnostics.TraceLevel)value;
            }
        }

        /// <summary>
        /// Date and time when the data collector was created.
        /// </summary>      
        [DataMember]
        public DateTime Added
        {
            get;
            set;
        }

        /// <summary>
        /// Date and time when the data collector was removed.
        /// </summary>      
        [DataMember]
        public DateTime? Removed
        {
            get;
            set;
        }       

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiDataCollector()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiDataCollector(string name, string ipAddress, string description)
        {
            this.Name = name;
            this.IP = ipAddress;
            this.Description = description;
        }

        /// <summary>
        /// Make clone from the DC.
        /// </summary>
        /// <returns></returns>
        public GXAmiDataCollector Clone()
        {
            GXAmiDataCollector item = new GXAmiDataCollector(Name, IP, Description);
            item.Id = Id;
            item.Guid = Guid;
            item.SerialPorts = SerialPorts;            
            item.Medias = Medias;
            item.LastRequestTimeStamp = LastRequestTimeStamp;
            item.MAC = MAC;
            item.UnAssigned = UnAssigned;
            item.Added = Added;
            item.Removed = Removed;
            return item;
        }
	}
}
