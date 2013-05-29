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
using ServiceStack.DesignPatterns.Model;
using System;
using System.Runtime.Serialization;
using ServiceStack.OrmLite;
using System.ComponentModel.DataAnnotations;

namespace GuruxAMI.Common
{
    /// <summary>
    /// A data contract class representing User Action Log object.
    /// User actions are logged to the database.
    /// </summary>
    [Serializable, Alias("UserActionLog")]
    public class GXAmiUserActionLog : IHasId<int>
    {
        /// <summary>
        /// The database ID of the log entry
        /// </summary>
        [Alias("ID"), AutoIncrement, DataMember]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// ID of target ID.
        /// </summary>
        [DataMember]
        public ulong TargetID
        {
            get;
            set;
        }

        /// <summary>
        /// The database ID of the user that committed the action
        /// </summary>
        [DataMember]
        [ForeignKey(typeof(GXAmiUser), OnDelete = "CASCADE")]
        public long UserID
        {
            get;
            set;
        }

        /// <summary>
        /// The name of the target of the action
        /// </summary>        
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public ActionTargets Target
        {
            get;
            set;
        }

        /// <summary>
        /// Returns Target enum valus as integer.
        /// </summary>
        [Alias("Target")]
        [DataMember()]
        public int TargetAsInt
        {
            get
            {
                return (int)Target;
            }
            set
            {
                Target = (ActionTargets)value;
            }
        }

        /// <summary>
        /// The action performed
        /// </summary>
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public Actions Action
        {
            get;
            set;
        }

        /// <summary>
        /// Returns Action enum valus as integer.
        /// </summary>
        [Alias("Action")]
        [DataMember()]
        public int ActionAsInt
        {
            get
            {
                return (int)Action;
            }
            set
            {
                Action = (Actions)value;
            }
        }

        /// <summary>
        /// Time when the action was done
        /// </summary>
        [DataMember]
        public DateTime TimeStamp
        {
            get;
            set;
        }

        /// <summary>
        /// The IP Address of the users computer
        /// </summary>
        [DataMember, StringLength(30)]
        public string IP
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiUserActionLog()
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiUserActionLog(long userId, ActionTargets target, Actions action, string ip)
        {
            TimeStamp = DateTime.Now;
            UserID = userId;
            Target = target;
            Action = action;
            IP = ip;
        }
    }
}
