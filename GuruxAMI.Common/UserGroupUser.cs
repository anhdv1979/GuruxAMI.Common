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
using ServiceStack.DesignPatterns.Model;

namespace GuruxAMI.Common
{
    /// <summary>
    /// A data contract class representing User Group to User binding object.
    /// </summary>
    [Serializable, Alias("UserGroupUser")]
    public class GXAmiUserGroupUser : IHasId<long>
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
        /// The database ID of the user
        /// </summary>
        [DataMember]
        [ForeignKey(typeof(GXAmiUser), OnDelete = "CASCADE")]
        public long UserID
        {
            get;
            set;
        }

        /// <summary>
        /// The time when the binding was added
        /// </summary>
        [DataMember]
        public DateTime Added
        {
            get;
            set;
        }

        /// <summary>
        /// If this is not null then the binding has been removed and shouldn't be displayed on the user interface.
        /// </summary>
        [DataMember]
        public DateTime? Removed
        {
            get;
            set;
        }
    }
}
