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
using ServiceStack.OrmLite;
using ServiceStack.DataAnnotations;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Gurux.Device.Editor;
#if !SS4
using ServiceStack.DesignPatterns.Model;
#else
using ServiceStack.Model;
#endif

namespace GuruxAMI.Common
{   
    [DataContract()]
    [Serializable, Alias("ParameterTemplate")]
    public class GXAmiParameterTemplate : GXAmiParameter, IHasId<ulong>
	{
        /// <summary>
        /// Device template ID.
        /// </summary>
        [DataMember, ForeignKey(typeof(GXAmiDeviceProfile), OnDelete = "CASCADE")]
        public override ulong DeviceID
        {
            get;
            set;
        }

        /// <summary>
        /// Property template ID.
        /// </summary>
        [Ignore]
        public override ulong TemplateId
        {
            get;
            set;
        }

        public GXAmiParameter ToParameter()
        {
            GXAmiParameter p = new GXAmiParameter();
            p.TemplateVersion = TemplateVersion;
            p.ParentID = ParentID;
            p.DeviceID = DeviceID;
            p.Name = Name;
            p.Value = Value;
            p.Description = Description;
            p.TypeAsString = TypeAsString;
            p.Storable = Storable;
            p.Access = Access;
            return p;
        }
	}
}
