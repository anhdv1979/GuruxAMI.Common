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
namespace GuruxAMI.Common
{
    /// <summary>
    /// A data contract class representing System Error Log object.
    /// </summary>
    [Serializable, Alias("SystemError")]
	public class GXAmiSystemError : IHasId<uint>
	{
        /// <summary>
        /// The database ID of the error log entry.
        /// </summary>
        [Alias("ID"), AutoIncrement, DataMember]
        public uint Id
		{
			get;
			set;
		}

        /// <summary>
        /// User ID of the user who has cause the exception.
        /// </summary>
		[DataMember]
        [ForeignKey(typeof(GXAmiUser), OnDelete = "CASCADE")]
		public long UserID
		{
			get;
			set;
		}

        /// <summary>
        /// Time when the error has occurred.
        /// </summary>
        [DataMember]
		public DateTime TimeStamp
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
        /// Additional information
        /// </summary>
        [DataMember]        
		public string Parameter
		{
			get;
			set;
		}

        /// <summary>
        /// Call stack of the exception.
        /// </summary>
		[DataMember]
		public string CallStack
		{
			get;
			set;
		}

        /// <summary>
        /// The type of the exception.
        /// </summary>
		[DataMember]
		public string ExceptionType
		{
			get;
			set;
		}

        /// <summary>
        /// The exception message.
        /// </summary>
		[DataMember]
		public string Message
		{
			get;
			set;
		}

        /// <summary>
        /// Default constructor
        /// </summary>
		public GXAmiSystemError()
		{
		}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ex">Occurred error.</param>
        public GXAmiSystemError(long userId, ActionTargets target, Actions action, Exception ex)
        {
            UserID = userId;
            Target = target;
            Action = action;
            this.TimeStamp = DateTime.Now;
            this.Parameter = string.Empty;
            this.CallStack = ex.StackTrace.ToString();
            int len = this.CallStack.Length;
            if (len > 255)
            {
                this.CallStack = this.CallStack.Substring(0, 254);
            }
            this.ExceptionType = ex.GetType().ToString();
            this.Message = ex.Message;
        }
        
	}
}
