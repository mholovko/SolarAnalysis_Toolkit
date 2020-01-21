﻿/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2019, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BH.oM.Environment.Climate;
using BH.oM.Geometry;

using BH.oM.Reflection.Attributes;
using System.ComponentModel;
using BH.oM.SolarAnalysis;

namespace BH.Engine.Environment

{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        [Description("Returns an Environment SpaceTime object")]
        [Input("location", "An Environment Location object specifying the latitude, longitude and other location specifics of the SpaceTime object, default null")]
        [Input("year", "The year of the time for the space time object, default 2007")]
        [Input("month", "The month of the time for the space time object, default 1 (January)")]
        [Input("day", "The day of the time for the space time object, default 1")]
        [Input("hour", "The hour of the day for the space time object, default 12")]
        [Input("minute", "The minute of the hour for the space time object, default 0")]
        [Input("second", "The second of the minute for the space time object, default 0")]
        [Input("millisecond", "The millisecond of the second for the space time object, default 0")]
        [Input("name", "The name of the space time, default empty string")]
        [Output("spaceTime", "An Environment SpaceTime object - used for defining locations in space and time for climate analysis")]
        [Deprecated("3.0", "Deprecated in favour of default create components produced by BHoM")]
        public static AnalysisPeriod AnalysisPeriod(SpaceTime spaceTimeStart, SpaceTime spaceTimeEnd)
        {
            AnalysisPeriod analysisPeriod = new AnalysisPeriod
            {
                StartTime = spaceTimeStart,
                EndTime = spaceTimeEnd
            };

            return analysisPeriod;
        }
    }
}