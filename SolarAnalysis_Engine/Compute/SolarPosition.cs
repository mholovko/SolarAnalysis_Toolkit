/*
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
using BH.oM.Environment;
using BH.oM.Reflection.Attributes;
using System.ComponentModel;
using BH.oM.SolarAnalysis;
using BH.oM.Environment.Climate;
using SPA = SPACalculator.SPACalculator;
using Sun = BH.oM.SolarAnalysis.Sun;

namespace BH.Engine.SolarAnalysis
{
    public static partial class Compute
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/
        [Description("Calculate the solar azimuth (degrees clockwise from 0 at North) from Datetime and Location objects")]
        [Input("spaceTime", "The latitude of the location to calculate the solar azimuth from. This should be given in degrees. Default 0")]
        [Output("sun", "The sun with calculated position")]
        public static Sun SolarPosition(this SpaceTime spaceTime)
            
        {
            
            SPA.SPAData spa = new SPA.SPAData
            {
                Year = spaceTime.Year,
                Month = spaceTime.Month,
                Day = spaceTime.Day,
                Hour = spaceTime.Hour,
                Minute = spaceTime.Minute,
                Second = spaceTime.Second,
                Timezone = spaceTime.Location.UtcOffset,
                DeltaUt1 = 0,
                DeltaT = 67,
                Longitude = spaceTime.Location.Longitude,
                Latitude = spaceTime.Location.Latitude,
                Elevation = spaceTime.Location.Elevation,
                Pressure = 820,
                Temperature = 11,
                Slope = 0,
                AzmRotation = 0,
                AtmosRefract = 0.5667,
                Function = SPA.CalculationMode.SPA_ALL
            };

            var result = SPA.SPACalculate(ref spa);
            return new Sun { Altitude = 90 - spa.Zenith, Azimuth = spa.Azimuth, Sunrise = spa.Sunrise,Sunset =spa.Sunset  };
        }
    }
}