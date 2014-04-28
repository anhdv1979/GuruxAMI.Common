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
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Gurux.Device;
using ServiceStack.OrmLite;
#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{
    [DataContract()]
    [Serializable, Alias("Device")]
    public class GXAmiDevice : IHasId<ulong>
	{
        [Alias("ID"), DataMember, Index()]
        public virtual ulong Id
        {
            get;
            set;
        }

        [DataMember, Index()]
		public Guid Guid
		{
			get;
			set;
		}

        /// <summary>
        /// Protocol name.
        /// </summary>
        [DataMember, Ignore]
		public virtual string Protocol
		{
			get;
			set;
		}

        /// <summary>
        /// Profile name of the device.
        /// </summary>
        [DataMember, Ignore]
        public virtual string Profile
        {
            get;
            set;
        }

        /// <summary>
        /// Protocol AddInType.
        /// </summary>
        [DataMember, Ignore]
        public virtual string ProtocolAddInType
        {
            get;
            set;
        }

        /// <summary>
        /// Protocol AddInType.
        /// </summary>
        [DataMember, Ignore]
        public virtual string ProtocolAssembly
        {
            get;
            set;
        }

        /// <summary>
        /// The preset name of the device profile.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false), Ignore]
        public virtual string PresetName
        {
            get;
            set;
        }

        /// <summary>
        /// Retrieves or sets the manufacturer.
        /// </summary>        
        [DataMember(IsRequired = false, EmitDefaultValue = false), Ignore]
        public virtual string Manufacturer
        {
            get;
            set;
        }

        /// <summary>
        /// Retrieves or sets the model.
        /// </summary>        
        [DataMember(IsRequired = false, EmitDefaultValue = false), Ignore]
        public virtual string Model
        {
            get;
            set;
        }

        /// <summary>
        /// Retrieves or sets the version info.
        /// </summary>        
        [DataMember(IsRequired = false, EmitDefaultValue = false), Ignore]
        public virtual string Version
        {
            get;
            set;
        }

        /// <summary>
        /// Data collector need this when device is read. This value is not save to the DB.
        /// </summary>
        [DataMember]
        [ServiceStack.DataAnnotations.Ignore]      
        public virtual Guid ProfileGuid
        {
            get;
            set;
        }

        /// <summary>
        /// Device profile ID.
        /// </summary>
        [DataMember, ForeignKey(typeof(GXAmiDeviceProfile), OnDelete = "CASCADE")]
        public virtual ulong ProfileId
        {
            get;
            set;
        }

        /// <summary>
        /// Device profile Version.
        /// </summary>        
        [DataMember]
        public int ProfileVersion
        {
            get;
            set;
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [ServiceStack.DataAnnotations.Ignore]        
        public GXAmiParameter[] Parameters
        {
            get;
            set;
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [ServiceStack.DataAnnotations.Ignore]
        public GXAmiCategory[] Categories
        {
            get;
            set;
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [ServiceStack.DataAnnotations.Ignore]
        public GXAmiDataTable[] Tables
        {
            get;
            set;
        }

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [ServiceStack.DataAnnotations.Ignore]
        public GXAmiVisualizer Visualizer
        {
            get;
            set;
        }

        [DataMember, Index(Unique = false)]
		public virtual string Name
		{
			get;
			set;
		}

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public string Description
		{
			get;
			set;
		}

        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
		public AutoConnect AutoConnect
		{
			get;
			set;
		}

        /// <summary>
        /// Returns AutoConnect enum valus as integer.
        /// </summary>
        /// <remarks>
        /// This value is saved to the DB.
        /// </remarks>
        [Alias("AutoConnect")]
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public virtual int AutoConnectAsInt
        {
            get
            {
                return (int)AutoConnect;
            }
            set
            {
                AutoConnect = (AutoConnect)value;
            }
        }

        /// <summary>
        /// Is each property read separetly.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public bool ForcePerPropertyRead
		{
			get;
			set;
		}

        /// <summary>
        /// How often device is read in ms.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public int UpdateInterval
		{
			get;
			set;
		}

        /// <summary>
        /// How long reply is waited.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public int WaitTime
		{
			get;
			set;
		}

        /// <summary>
        /// How many times data is try to send.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public int ResendCount
		{
			get;
			set;
		}

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public int FailTryCount
		{
			get;
			set;
		}

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public int FailWaitTime
		{
			get;
			set;
		}

        /// <summary>
        /// How many times connection is try to made.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public int ConnectionTryCount
		{
			get;
			set;
		}

        /// <summary>
        /// How long is waited before connection is failed.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public int ConnectionFailWaitTime
		{
			get;
			set;
		}

        /// <summary>
        /// Media connections to the meter.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [Ignore()]
        public GXAmiDeviceMedia[] Medias
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
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
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
        /// Time stamp of device state.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public virtual DateTime TimeStamp
		{
			get;
			set;
		}

        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [Ignore()]
        public GXAmiMediaType[] AllowedMediaTypes
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
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
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
        /// Date and time when the device was created.
        /// </summary>      
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
		public DateTime Added
		{
			get;
			set;
		}

        /// <summary>
        /// Date and time when the device was removed.
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
        /// Returns Disabled Actions enum valus as integer.
        /// </summary>
        [Alias("DisabledActions")]
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
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
		public GXAmiDevice()
		{
		}

		public GXAmiDevice(string name)
		{
			this.Name = name;
		}
	}
}
