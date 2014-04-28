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
#if !SS4
using ServiceStack.ServiceHost;
#else
using ServiceStack;
#endif

namespace GuruxAMI.Common.Messages
{
    /// <summary>
    /// Start listen events.
    /// </summary>
    public class GXEventsRegisterRequest : IReturn<GXEventsRegisterResponse>, IReturn
	{
        /// <summary>
        /// Session Guid.
        /// </summary>
        public Guid SessionListener
        {
            get;
            set;
        }
        /// <summary>
        /// Instance Guid.
        /// </summary>
        public Guid Instance
        {
            get;
            set;
        }

        /// <summary>
        /// DataCollector Guid
        /// </summary>
        public Guid DataCollectorGuid
        {
            get;
            set;
        }

        /// <summary>
        /// Targets whose actions we want to know.
        /// </summary>
        public ActionTargets Targets
        {
            get;
            set;
        }

        /// <summary>
        /// Actions we want to know.
        /// </summary>
        public Actions Actions
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public GXEventsRegisterRequest(ActionTargets targets, Actions actions, Guid dataCollectorGuid, Guid session, Guid instance)
		{
            Instance = instance;
            SessionListener = session;
            DataCollectorGuid = dataCollectorGuid;
            Targets = targets;
            Actions = actions;
		}
	}
}
