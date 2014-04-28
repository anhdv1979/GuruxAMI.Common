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
#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

using System;
using System.Runtime.Serialization;
using ServiceStack.OrmLite;

namespace GuruxAMI.Common
{
    [Serializable, Alias("CategoryTemplate")]
    public class GXAmiCategoryTemplate : GXAmiCategory, IHasId<ulong>
	{
        [Alias("ID"), DataMember]
        public override ulong Id
        {
            get;
            set;
        }

        /// <summary>
        /// Device ID.
        /// </summary>
        [DataMember, ForeignKey(typeof(GXAmiDeviceProfile), OnDelete = "CASCADE")]
        public override ulong DeviceID
        {
            get;
            set;
        }

        /// <summary>
        /// Hide Category template ID.
        /// </summary>
        [Ignore]
        public override ulong ProfileId
        {
            get;
            set;
        }

        public GXAmiCategory ToCategory()
        {
            GXAmiCategory cat = new GXAmiCategory();
            cat.TemplateVersion = TemplateVersion;
            cat.ProfileId = Id & 0xFFFF;
            cat.Name = Name;            
            //Properties
            //Parameters
            cat.DisabledActions = DisabledActions;            
            return cat;
        }
	}
}
