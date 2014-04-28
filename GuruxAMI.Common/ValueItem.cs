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
using ServiceStack.OrmLite;
using ServiceStack.DataAnnotations;
using System.Runtime.Serialization;

#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{
    /// <summary>
    /// Parameter value is used to enumerate possible values that parameter or property can get.
    /// </summary>
    [DataContract()]
    [Serializable, Alias("ValueItem")]
    public class GXAmiValueItem : IHasId<ulong>
    {
        [Alias("ID"), AutoIncrement, DataMember]
        public ulong Id
        {
            get;
            set;
        }

        /// <summary>
        /// Parameter template ID who owns this value.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [ForeignKey(typeof(GXAmiParameterTemplate), OnDelete = "CASCADE")]
        public ulong? ParameterId
        {
            get;
            set;
        }

        /// <summary>
        /// Property template ID who owns this value.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        [ForeignKey(typeof(GXAmiPropertyTemplate), OnDelete = "CASCADE")]
        public ulong? PropertyId
        {
            get;
            set;
        }

        /// <summary>
        /// UI Value of the property or parameter.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string UIValue
        {
            get;
            set;
        }
        /// <summary>
        /// Device value of the property or parameter.
        /// </summary>
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public string DeviceValue
        {
            get;
            set;
        }
    }
}
