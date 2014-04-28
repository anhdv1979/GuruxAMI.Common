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
    [Serializable, Alias("TaskData")]
    public class GXAmiTaskData : IHasId<ulong>
    {
        /// <summary>
        /// The database ID of the task data.
        /// </summary>
        [Alias("ID"), DataMember, AutoIncrement, Index(Unique = true)]
        public virtual ulong Id
        {
            get;
            set;
        }

        /// <summary>
        /// The database ID of the task.
        /// </summary>
        [DataMember, Index(Unique = false), ForeignKey(typeof(GXAmiTask), OnDelete = "CASCADE")]
        [Alias("TaskID")]
        public virtual ulong TaskId
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

    [Serializable, Alias("TaskLogData")]
    public class GXAmiTaskLogData : GXAmiTaskData
    {
        /// <summary>
        /// The database ID of the task.
        /// </summary>
        [DataMember, Index(Unique = false), ForeignKey(typeof(GXAmiTaskLog), OnDelete = "CASCADE")]
        [Alias("TaskID")]
        override public ulong TaskId
        {
            get;
            set;
        }
    }
}
