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

using BH.oM.Environment.Climate;
using BH.Engine.Environment;

namespace BH.Engine.SolarAnalysis
{
    public static partial class Compute
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/
        [Description("DailyPath")]
        [Input("sun", "Sun position")]
        [Output("SolarVector", "The sun vector calculated position")]
        public static Circle DailyPath(this SpaceTime spaceTime)
        {
            double[] hours = { 0, 11.9, 12 };
            List<Point> sunPositions = new List<Point>();
            bool validCircle = false;

            foreach (double hour in hours)
            {
                int h = (int)hour;
                int m = (int)(hour - (double)h) * 60;
                spaceTime.Hour = h;
                spaceTime.Minute = m;
                Sun sun = spaceTime.SolarPosition();
                Point sunPosition = Geometry.Create.Point(sun.SolarVector());
                sunPositions.Add(sunPosition);
                if (sunPosition.Z > 0)
                    validCircle = true;
            }

            if (validCircle)
            {

                Circle circle = Geometry.Create.Circle(sunPositions[0], sunPositions[1], sunPositions[2]);
                return circle;
            }
            Circle circlea = new Circle();
            return circlea;


        }

        /***************************************************/
    }
}