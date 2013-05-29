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
namespace GuruxAMI.Common
{
    [Serializable, Alias("MediaSettingsTemplate")]
	internal class GXAmiMediaSettingsTemplate : IHasId<int>
	{
        [Alias("ID"), DataMember]
		public int Id
		{
			get;
			set;
		}
		[DataMember]
		public int? DataCollectorID
		{
			get;
			set;
		}
		[DataMember]
		public string MediaType
		{
			get;
			set;
		}
		[DataMember]
		public string TemplateName
		{
			get;
			set;
		}
		[DataMember]
		public bool IsDefault
		{
			get;
			set;
		}
		[Alias("MediaSettingsTemplateXML"), DataMember]
		public string MediaSettings
		{
			get;
			set;
		}
	}
}
