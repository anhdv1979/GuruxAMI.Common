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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GuruxAMI.Common.Messages
{
	public class GXTasksResponse
	{
		public object[] Items
		{
			get;
			internal set;
		}

        [XmlIgnore()]
        [IgnoreDataMember()]
        public GXAmiTask[] Tasks
        {
            get
            {
                GXAmiTask[] tmp = new GXAmiTask[Items.Length];
                if (Items.Length != 0)
                {
                    System.Array.Copy(Items, tmp, Items.Length);
                }
                return tmp;                
            }
        }

        [XmlIgnore()]
        [IgnoreDataMember()]
        public GXAmiTaskLog[] Log
        {
            get
            {
                GXAmiTaskLog[] tmp = new GXAmiTaskLog[Items.Length];
                if (Items.Length != 0)
                {
                    System.Array.Copy(Items, tmp, Items.Length);
                }
                return tmp;
            }
        }

		public GXTasksResponse(GXAmiTask[] tasks)
		{            
            this.Items = tasks;
		}
	}
}
