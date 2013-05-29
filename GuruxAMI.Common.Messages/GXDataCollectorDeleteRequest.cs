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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.ServiceHost;

namespace GuruxAMI.Common.Messages
{
    public class GXDataCollectorDeleteRequest : IReturn<GXDataCollectorDeleteResponse>, IReturn
    {
        /// <summary>
        /// Remove device(s) from the data controller.
        /// </summary>
        public ulong[] DeviceIDs
        {
            get;
            internal set;
        }

        /// <summary>
        /// Remove users from datacontroller.
        /// </summary>
        public long UserId
        {
            get;
            internal set;
        }

        /// <summary>
        /// Removed data controllers.
        /// </summary>
        public ulong[] DataControllerIDs
        {
            get;
            internal set;
        }
        
        public bool Permamently
        {
            get;
            set;
        }
        
        /// <summary>
        /// Constructor.
        /// </summary>
        public GXDataCollectorDeleteRequest(GXAmiDataCollector[] collectors, bool permamently)
        {
            this.Permamently = permamently;
            if (collectors != null)
            {
                int pos = -1;
                this.DataControllerIDs = new ulong[collectors.Length];
                for (int i = 0; i < collectors.Length; i++)
                {                    
                    this.DataControllerIDs[++pos] = collectors[i].Id;
                }
            }
        }
    }
}
