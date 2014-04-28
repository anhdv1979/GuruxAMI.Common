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
using System.Runtime.Serialization;
#if !SS4
using ServiceStack.ServiceHost;
#else
using ServiceStack;
#endif

namespace GuruxAMI.Common.Messages
{
	public class GXErrorUpdateRequest : IReturn<GXErrorUpdateResponse>, IReturn
	{
        /// <summary>
        /// The database ID of the target of the error log entry 
        /// </summary>
        public ulong TaskID
        {
            get;
            internal set;
        }

        /// <summary>
        /// Device ID that caused the error.
        /// </summary>
        public ulong DeviceID
        {
            get;
            internal set;
        }

        /// <summary>
        /// DataCollector ID that caused the error.
        /// </summary>
        public ulong DataCollectorID
        {
            get;
            internal set;
        }

        /// <summary>
        /// The database ID of the target of the error log entry 
        /// </summary>
        public string Message
        {
            get;
            internal set;
        }
        
        public string Source
        {
            get;
            internal set;
        }

        public string StackTrace
        {
            get;
            internal set;
        }

        public int Severity
        {
            get;
            internal set;
        }

        /// <summary>
        /// Constructor for device error.
        /// </summary>
        public GXErrorUpdateRequest(ulong deviceID, ulong taskId, int severity, Exception ex)
		{
            this.DeviceID = deviceID;
            this.TaskID = taskId;
            this.Severity = severity;
            this.Message = ex.Message;
            this.Source = ex.Source;
            this.StackTrace = ex.StackTrace;
		}

        /// <summary>
        /// Constructor for Data Collector error.
        /// </summary>
        public GXErrorUpdateRequest(GXAmiDataCollector dc, ulong taskId, int severity, Exception ex)
        {
            this.DataCollectorID = dc.Id;
            this.TaskID = taskId;
            this.Severity = severity;
            this.Message = ex.Message;
            this.Source = ex.Source;
            this.StackTrace = ex.StackTrace;
        }
	}
}
