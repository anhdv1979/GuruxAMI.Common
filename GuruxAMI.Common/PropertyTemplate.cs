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
    [Serializable, Alias("PropertyTemplate")]
    public class GXAmiPropertyTemplate : GXAmiProperty, IHasId<ulong>
	{
        [Alias("ID"), DataMember]
        public override ulong Id
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

        [DataMember, ForeignKey(typeof(GXAmiDeviceTemplate), OnDelete = "CASCADE")]
        public override ulong DeviceID
        {
            get;
            set;
        }

        public GXAmiProperty ToProperty()
        {
            GXAmiProperty prop = new GXAmiProperty();
            prop.TemplateId = prop.Id = Id & 0xFFFF;
            prop.TemplateVersion = TemplateVersion;
            prop.Name = Name;
            prop.Unit = Unit;
            prop.AccessMode = AccessMode;
            prop.DisabledActions = DisabledActions;
            return prop;
        }
	}
}
