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
#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{
    [Serializable, Alias("TraceData")]
    public class GXAmiTraceData
    {
        /// <summary>
        /// The database ID of the trace data.
        /// </summary>
        [Alias("ID"), DataMember, AutoIncrement, Index(Unique = false)]
        public virtual ulong Id
        {
            get;
            set;
        }

        [Alias("TraceID"), DataMember, Index(Unique = false), ForeignKey(typeof(GXAmiTrace), OnDelete = "CASCADE")]
        public ulong TraceId
        {
            get;
            set;
        }

        /// <summary>
        /// If size of data is not fit to one data field data is splitted to several tasks.
        /// </summary>
        [DataMember, Index(Unique = false)]
        public int Index
        {
            get;
            set;
        }

        /// <summary>
        /// Task data.
        /// </summary>
        [DataMember]
        public string Data
        {
            get;
            set;
        }
    }
}
