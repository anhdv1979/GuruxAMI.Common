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

namespace GuruxAMI.Common.Messages
{
    [Serializable]
    public class GXClaimedTask
    {        
        /// <summary>
        /// Task to handle.
        /// </summary>
        public GXAmiTask Task
        {
            get;
            set;
        }

        public GXAmiDevice Device
        {
            get;
            set;
        }

        /// <summary>
        /// Guid of device template.
        /// </summary>
        public Guid DeviceTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// DC ID that claimed the task.
        /// </summary>
        public ulong DataCollectorID
        {
            get;
            set;
        }

        /// <summary>
        /// Media name.
        /// </summary>
        public string Media
        {
            get;
            set;
        }

        /// <summary>
        /// Media communication settings.
        /// </summary>
        public string Settings
        {
            get;
            set;
        }

        /// <summary>
        /// Data to send.
        /// </summary>
        public string Data
        {
            get;
            set;
        }
    }
}
