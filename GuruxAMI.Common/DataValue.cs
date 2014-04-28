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
using System.ComponentModel.DataAnnotations;
#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{    
    [Serializable, Alias("DataValue")]
    public class GXAmiDataValue
    {
        /// <summary>
        /// Property ID is unique in latest value.
        /// </summary>
        [DataMember]
        public virtual ulong PropertyID
        {
            get;
            set;
        }


        [DataMember]
        public object UIValue
        {
            get;
            set;
        }
        
        [DataMember]
        public DateTime TimeStamp
        {
            get;
            set;
        }


        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiDataValue()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiDataValue(ulong propertyID, string value)
        {
            PropertyID = propertyID;
            UIValue = value; 
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXAmiDataValue(ulong propertyID, string value, DateTime timeStamp)
        {
            TimeStamp = timeStamp;
            PropertyID = propertyID;
            UIValue = value;
        }
    }
}
