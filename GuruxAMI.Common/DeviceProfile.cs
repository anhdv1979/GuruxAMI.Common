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
using ServiceStack.OrmLite;
using Gurux.Device;
using System.ComponentModel;
#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{
    [Serializable, Alias("DeviceProfile")]
    public class GXAmiDeviceProfile : GXAmiDevice, IHasId<ulong>
	{
        [Alias("ID"), AutoIncrement, DataMember]
        public override ulong Id
		{
			get;
			set;
		}

        /// <summary>
        /// Protocol name.
        /// </summary>
        [DataMember]
        public override string Protocol
        {
            get;
            set;
        }

        /// <summary>
        /// Device profile name.
        /// </summary>
        [DataMember]
        public override string Profile
        {
            get;
            set;
        }

        /// <summary>
        /// Protocol AddInType.
        /// </summary>
        [DataMember]
        public override string ProtocolAddInType
        {
            get;
            set;
        }

        /// <summary>
        /// Protocol AddInType.
        /// </summary>
        [DataMember]
        public override string ProtocolAssembly
        {
            get;
            set;
        }

        /// <summary>
        /// The preset name of the device profile.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public override string PresetName
        {
            get;
            set;
        }

        /// <summary>
        /// Retrieves or sets the manufacturer.
        /// </summary>        
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public override string Manufacturer
        {
            get;
            set;
        }

        /// <summary>
        /// Retrieves or sets the model.
        /// </summary>        
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public override string Model
        {
            get;
            set;
        }

        /// <summary>
        /// Retrieves or sets the version info.
        /// </summary>        
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public override string Version
        {
            get;
            set;
        }

        [Browsable(false), Ignore]
        public override ulong ProfileId
        {
            get;
            set;
        }

        [Browsable(false), Ignore]
        public override string Name
        {
            get;
            set;
        }

        [Browsable(false), Ignore]
        public override int StatesAsInt
        {
            get;
            set;
        }
        
        [Ignore]
        public override DateTime TimeStamp
        {
            get;
            set;
        }		

	}
}
