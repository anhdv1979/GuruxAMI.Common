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
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Gurux.Device;
using ServiceStack.OrmLite;

namespace GuruxAMI.Common
{
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
        /// Device template name.
        /// </summary>
        [DataMember, Ignore]
        public virtual string Template
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
        /// The preset name of the device template.
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
        public virtual Guid TemplateGuid
        {
            get;
            set;
        }

        /// <summary>
        /// Device template ID.
        /// </summary>
        [DataMember, ForeignKey(typeof(GXAmiDeviceTemplate), OnDelete = "CASCADE")]
        public virtual ulong TemplateId
        {
            get;
            set;
        }

        /// <summary>
        /// Device template Version.
        /// </summary>        
        [DataMember]
        public int TemplateVersion
        {
            get;
            set;
        }

        [DataMember]
        [ServiceStack.DataAnnotations.Ignore]        
        public GXAmiParameter[] Parameters
        {
            get;
            set;
        }

        [DataMember]
        [ServiceStack.DataAnnotations.Ignore]
        public GXAmiCategory[] Categories
        {
            get;
            set;
        }
        
        [DataMember, ServiceStack.DataAnnotations.Ignore]
        public GXAmiDataTable[] Tables
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

		[DataMember]
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
        [DataMember()]
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

		[DataMember]
		public bool ForcePerPropertyRead
		{
			get;
			set;
		}

        [DataMember]
        public int UpdateInterval
		{
			get;
			set;
		}

		[DataMember]
		public int WaitTime
		{
			get;
			set;
		}
		[DataMember]
		public int ResendCount
		{
			get;
			set;
		}
		[DataMember]
		public int FailTryCount
		{
			get;
			set;
		}
		[DataMember]
		public int FailWaitTime
		{
			get;
			set;
		}
		[DataMember]
		public int ConnectionTryCount
		{
			get;
			set;
		}
		[DataMember]
		public int ConnectionFailWaitTime
		{
			get;
			set;
		}
		
        [DataMember]
		public string MediaName
		{
			get;
			set;
		}

		[DataMember]
		public string MediaSettings
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
        /// Time stamp of device state.
        /// </summary>
		[DataMember]
        public virtual DateTime TimeStamp
		{
			get;
			set;
		}

        [DataMember, Ignore()]
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
        /// Date and time when the device was created.
        /// </summary>      
		[DataMember]
		public DateTime Added
		{
			get;
			set;
		}

        /// <summary>
        /// Date and time when the device was removed.
        /// </summary>      
		[DataMember]
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
		public GXAmiDevice()
		{
		}

		public GXAmiDevice(string name)
		{
			this.Name = name;
		}
	}
}
