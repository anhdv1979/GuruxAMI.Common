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
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Gurux.AMI.DataContracts
{
	/// <summary>
	/// A data contract class representing Device Error Log object.
	/// This is logged from Data Collector when GXDeviceList.OnError triggers.
	/// </summary>
	[Serializable]
	[DataContract(Namespace = "http://www.gurux.org")]
	public class DeviceErrorLog
	{
		/// <summary>
		/// The database ID of the error log entry
		/// </summary>
		[DataMember]
		public int? DeviceErrorLogID { get; set; }

		/// <summary>
		/// The database ID of the target of the error log entry 
		/// </summary>
		[DataMember]
		public ulong TargetID { get; set; }

		/// <summary>
		/// The time when the error occurred
		/// </summary>
		[DataMember]
		public DateTime TimeStamp { get; set; }

		/// <summary>
		/// The description of the error
		/// </summary>
		[DataMember]
		public string Description { get; set; }

		/// <summary>
		/// The severity of the error
		/// </summary>
		[DataMember]
		public int Severity { get; set; }
	}
}
