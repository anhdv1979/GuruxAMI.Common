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
using System.Text;
using System.Runtime.Serialization;
using ServiceStack.OrmLite;
using ServiceStack.DataAnnotations;
#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{
	/// <summary>
	/// A data contract class representing Data Collector to User Group binding object.
	/// </summary>
    [Serializable, Alias("DataCollectorUserGroup")]
    public class GXAmiDataCollectorUserGroup : IHasId<long>
	{
        [Alias("ID"), AutoIncrement, Index(Unique = true), DataMember]
        public long Id
        {
            get;
            set;
        }

		/// <summary>
		/// The database ID of the user group
		/// </summary>
        [DataMember]
        [ForeignKey(typeof(GXAmiUserGroup), OnDelete = "CASCADE")]
        public long UserGroupID
        {
            get;
            set;
        }

		/// <summary>
		/// The database ID of the data collector
		/// </summary>
        [DataMember]
        [ForeignKey(typeof(GXAmiDataCollector), OnDelete = "CASCADE")]
        public ulong DataCollectorID
        {
            get;
            set;
        }
	}
}
