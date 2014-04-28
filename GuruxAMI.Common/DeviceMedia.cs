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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;
using System.Runtime.Serialization;
#if !SS4
using ServiceStack.DesignPatterns.Model;
using ServiceStack.OrmLite;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{
    [DataContract()]
    [Serializable, Alias("DeviceMedia")]
    public class GXAmiDeviceMedia : IHasId<ulong>
    {
        [Alias("ID"), DataMember, AutoIncrement, Index(true)]
        public virtual ulong Id
        {
            get;
            set;
        }

        /// <summary>
        /// Data collector ID.
        /// </summary>
        [DataMember(), Index(Unique = false)]
        [ForeignKey(typeof(GXAmiDataCollector), OnDelete = "CASCADE")]
        public ulong? DataCollectorId
        {
            get;
            set;
        }

        /// <summary>
        /// Device ID.
        /// </summary>
        [DataMember(IsRequired = true), Index(Unique=false)]
        [ForeignKey(typeof(GXAmiDevice), OnDelete = "CASCADE")]
        public ulong DeviceId
        {
            get;
            set;
        }

        /// <summary>
        /// Order number.
        /// </summary>
        [DataMember()]
        public int Index
        {
            get;
            set;
        }

        /// <summary>
        /// Media description.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// name of selected media.
        /// </summary>
        [DataMember]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Media settings.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string Settings
        {
            get;
            set;
        }

        /// <summary>
        /// Can Data collector use device.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public bool Disabled
        {
            get;
            set;
        }
    }
}
