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
using Gurux.Device;
using System.ComponentModel;
namespace GuruxAMI.Common
{
    [Serializable, Alias("MediaType")]
    public class GXAmiMediaType
    {
        [Alias("ID"), AutoIncrement, DataMember]
        public ulong Id
        {
            get;
            set;
        }

        /// <summary>
        /// Media name.
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        [ForeignKey(typeof(GXAmiDeviceTemplate), OnDelete = "CASCADE")]
        public ulong DeviceTemplateId
        {
            get;
            set;
        }

        /// <summary>
        /// Default media settings.
        /// </summary>
        public string Settings
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Name;
        }        
    }

    [Serializable, Alias("DeviceTemplateDataBlock")]
    public class GXAmiDeviceTemplateDataBlock : IHasId<ulong>
    {
        [Alias("ID"), AutoIncrement, DataMember]
        public ulong Id
        {
            get;
            set;
        }

        [DataMember]
        [ForeignKey(typeof(GXAmiDeviceTemplate), OnDelete = "CASCADE")]
        public ulong DeviceTemplateId
        {
            get;
            set;
        }

        [DataMember]
        public int Index
        {
            get;
            set;
        }       

        [DataMember]
        public byte[] Data
        {
            get;
            set;
        }
        
        public GXAmiDeviceTemplateDataBlock()
        {
        }

        public GXAmiDeviceTemplateDataBlock(ulong templateId, int index, byte[] data, int length)
        {            
            DeviceTemplateId = templateId;
            Index = index;
            Data = new byte[length];
            Array.Copy(data, Data, length);
        }
    }

    [Serializable, Alias("DeviceTemplate")]
    public class GXAmiDeviceTemplate : GXAmiDevice, IHasId<ulong>
	{
        [Alias("ID"), AutoIncrement, DataMember]
        public override ulong Id
		{
			get;
			set;
		}

        [Browsable(false), Ignore]
        public override ulong TemplateId
        {
            get;
            set;
        }

        [Browsable(false), Ignore]
        public override string Name
        {
            get;
            set;
        }

        [Browsable(false), Ignore]
        public override int StatesAsInt
        {
            get;
            set;
        }
        
        [Ignore]
        public override DateTime TimeStamp
        {
            get;
            set;
        }		

	}
}
