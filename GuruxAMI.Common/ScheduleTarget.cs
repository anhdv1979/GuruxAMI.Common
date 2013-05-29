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
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GuruxAMI.Common
{
    [Serializable, Alias("ScheduleTarget")]
    public class GXAmiScheduleTarget
    {
        /// <summary>
        /// The type of the target
        /// </summary>		
        [ServiceStack.DataAnnotations.Ignore, IgnoreDataMember()]
        public TargetType TargetType
        {
            get;
            set;
        }

        /// <summary>
        /// Returns TargetType enum valus as integer.
        /// </summary>
        [Alias("TargetType")]
        [DataMember()]
        public int TargetTypeAsInt
        {
            get
            {
                return (int)TargetType;
            }
            set
            {
                TargetType = (TargetType)value;
            }
        }

        [DataMember]
        public ulong TargetID
        {
            get;
            set;
        }

        /// <summary>
        /// Construtor.
        /// </summary>
        public GXAmiScheduleTarget()
        {
        }

        /// <summary>
        /// Construtor.
        /// </summary>
        public GXAmiScheduleTarget(TargetType type, ulong targetId)
        {
            TargetType = type;
            TargetID = targetId;
        }
    }
}
