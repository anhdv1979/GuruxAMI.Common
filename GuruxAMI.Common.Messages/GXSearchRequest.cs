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

#if !SS4
using ServiceStack.ServiceHost;
#else
using ServiceStack;
#endif

using System;
namespace GuruxAMI.Common.Messages
{    
    /// <summary>
    /// Search request.
    /// </summary>
    public class GXSearchRequest : IReturn<GXSearchResponse>, IReturn
	{
        /// <summary>
        /// Search texts.
        /// </summary>
		public string[] Texts
		{
			get;
			internal set;
		}

        public ActionTargets Target
		{
			get;
			internal set;
		}

        public SearchType Type
		{
			get;
			internal set;
		}
        

        /// <summary>
        /// Search operator type if multible search items.
        /// </summary>
        public SearchOperator Operator
        {
			get;
			internal set;
		}

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="texts"></param>
        public GXSearchRequest(string[] texts, ActionTargets target, SearchType type, SearchOperator searchOperator)
		{
            Texts = texts;
            Target = target;
            Type = type;
            Operator = searchOperator;
		}
	}
}
