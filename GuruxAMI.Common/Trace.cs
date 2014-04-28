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
using System.ComponentModel;
using ServiceStack.OrmLite;
using System.Security.Cryptography;
using System.IO;
#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{
    /// <summary>
    /// GuruxAMI trace data item.
    /// </summary>
    [Serializable, Alias("Trace")]
    public class GXAmiTrace : IHasId<ulong>
    {
        /// <summary>
        /// The database ID of the trace.
        /// </summary>
        [DataMember()]
        [Alias("ID"), AutoIncrement, Index(Unique = true)]
        public ulong Id
        {
            get;
            set;
        }

        [DataMember()]
        [Alias("DataCollectorID")]
        public ulong DataCollectorId
        {
            get;
            set;
        }

        /// <summary>
        /// DC collector is used for internal use only. Do not use.
        /// </summary>
        [Ignore, IgnoreDataMember]
        public Guid DataCollectorGuid
        {
            get;
            set;
        }

        [DataMember()]
        [Alias("DeviceID")]
        public ulong DeviceId
        {
            get;
            set;
        }

        /// <summary>
        /// Trace type.
        /// </summary>
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public Gurux.Common.TraceTypes Type
        {
            get;
            set;
        }

        /// <summary>
        /// Returns TaskType enum valus as integer.
        /// </summary>
        [Alias("Type")]
        [DataMember()]
        public int TypeAsInt
        {
            get
            {
                return (int)Type;
            }
            set
            {
                Type = (Gurux.Common.TraceTypes)value;
            }
        }


        /// <summary>
        /// Timestamp.
        /// </summary>
        [DataMember()]
        public DateTime Timestamp
        {
            get;
            set;
        }
        
        /// <summary>
        /// Received/send data.
        /// </summary>
        [ServiceStack.DataAnnotations.Ignore, DataMember]
        public object Data
        {
            get;
            set;
        }

        /// <summary>
        /// Data type.
        /// </summary>
        [DataMember()]
        public string DataType
        {
            get;
            set;
        }
    }
}
