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
using GuruxAMI.Common;
using System.Runtime.Serialization;

namespace GuruxAMI.Common.Messages
{
    [DataContract, Serializable]
    public class GXEventsItem
    {
        /// <summary>
        /// Group where items are added.
        /// </summary>
        public object[] Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// Target type.
        /// </summary>
        public ActionTargets Target
        {
            get;
            set;
        }

        /// <summary>
        /// Occurred action.
        /// </summary>        
        [DataMember]
        public Actions Action
        {
            get;
            set;
        }
        
        /// <summary>
        /// Action data.
        /// </summary>
        [DataMember]
        public object Data
        {
            get;
            set;
        }        

        /// <summary>
        /// Timestamp of the action.
        /// </summary>
        [DataMember]
        public DateTime Timestamp
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public GXEventsItem()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public GXEventsItem(ActionTargets target, Actions action, object data)
        {
            Target = target;
            Action = action;
            Data = data;
            Timestamp = DateTime.Now;
        }

    }	
}