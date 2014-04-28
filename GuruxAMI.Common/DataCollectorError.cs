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
    [Serializable, Alias("DataCollectorError")]
    public class GXAmiDataCollectorError : IHasId<uint>
    {
        /// <summary>
        /// The database ID of the error log entry
        /// </summary>
        [Alias("ID"), AutoIncrement, DataMember]
        public uint Id
        {
            get;
            set;
        }

        /// <summary>
        /// The database ID of the task of the error log entry 
        /// </summary>
        [DataMember]
        [ForeignKey(typeof(GXAmiTaskLog), OnDelete = "CASCADE")]
        public ulong TaskID
        {
            get;
            set;
        }

        /// <summary>
        /// The database ID of the device containing the target.
        /// </summary>
        [DataMember]
        public ulong DataCollectorID
        {
            get;
            set;
        }

        /// <summary>
        /// The time when the error occurred
        /// </summary>
        [DataMember]
        public DateTime TimeStamp
        {
            get;
            set;
        }

        /// <summary>
        /// The description of the error
        /// </summary>
        [DataMember]
        public string Message
        {
            get;
            set;
        }


        [DataMember]
        public string Source
        {
            get;
            set;
        }

        [DataMember]
        public string StackTrace
        {
            get;
            set;
        }

        /// <summary>
        /// The severity of the error
        /// </summary>
        [DataMember]
        public int Severity
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiDataCollectorError()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiDataCollectorError(ulong taskID, ulong dataCollectorID, Exception ex)
        {
            TaskID = taskID;
            DataCollectorID = dataCollectorID;
            TimeStamp = DateTime.Now;
            Message = ex.Message;
            Source = ex.Source;
            StackTrace = ex.StackTrace;
        }
    }
}
