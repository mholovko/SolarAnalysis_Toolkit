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
using BH.oM.Environment;

using BH.Engine.Geometry;
using BH.oM.Geometry;

using BH.oM.Reflection.Attributes;
using System.ComponentModel;
using Sun = BH.oM.SolarAnalysis.Sun;

using BH.oM.Environment.Climate;
using Convert = BH.Engine.Environment.Convert;


namespace BH.Engine.SolarAnalysis
{
    public static partial class Compute
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/
        [Description("Calculate the solar vector")]
        [Input("sun", "Sun position")]
        [Output("SolarVector", "The sun vector calculated position")]
        public static Vector SolarVector(this Sun sun)
        {
            double azimuth = Convert.ToRadians(sun.Azimuth);
            double altitude = Convert.ToRadians(sun.Altitude);

            Vector solarVector = new Vector
            {
                X = Math.Sin(azimuth) * Math.Cos(altitude),
                Y = Math.Cos(altitude) * Math.Cos(azimuth),
                Z = Math.Sin(altitude)
            };

            return solarVector;


        }
    }

        /***************************************************/


    }
