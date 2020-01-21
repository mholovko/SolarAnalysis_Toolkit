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

using BH.Engine.Geometry;
using BH.oM.Geometry;

using BH.oM.Reflection.Attributes;
using System.ComponentModel;

using BH.oM.Environment.Climate;
using BH.Engine.Environment;
using Sun = BH.oM.SolarAnalysis.Sun;
using Curve = Rhino.Geometry.Curve;
using Point3d = Rhino.Geometry.Point3d;
using BH.Engine.Rhinoceros;

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

        public static List<ICurve> MounthPaths(Location location)
        {
            List<ICurve> paths = new List<ICurve>();
            for (int m = 1; m <= 12; ++m)
            {
                SpaceTime spaceTime = new SpaceTime
                {
                    Location = location,
                    Day = 21,
                    Year = 2020,
                    Month = m,
                };
                ICurve path = DailyPath(spaceTime);
                paths.Add(path);
            }
            return paths;
        }
        public static List<ICurve> MounthPaths(SpaceTime spaceTime)
        {
            List<ICurve> paths = new List<ICurve>();
            for (int m = 1; m <= 12; ++m)
            {
                spaceTime.Day = 21;
                spaceTime.Month = m;
                ICurve path = DailyPath(spaceTime);
                paths.Add(path);
            }
            return paths;
        }
        public static List<ICurve> HourPath(SpaceTime spaceTime)
        {
               List<ICurve> paths = new List<ICurve>();

            for (int h = 0; h <= 23; ++h)
            {
            List<Point3d> sunPositions = new List<Point3d>();
                for (int m = 1; m <= 12; ++m)
                {
                    spaceTime.Day = 21;
                    spaceTime.Month = m;
                    spaceTime.Hour = h;
                    Sun ss = SolarPA(spaceTime);

                    Point sunPosition = Geometry.Create.Point(ss.SolarVector());
                    Point3d sunPosition3d = Rhinoceros.Convert.ToRhino(sunPosition);
                    sunPositions.Add(sunPosition3d);
                }
                sunPositions.Add(sunPositions[0]);
                Rhino.Geometry.CurveKnotStyle nnotStyle = Rhino.Geometry.CurveKnotStyle.UniformPeriodic;
                Curve crv = Curve.CreateInterpolatedCurve(sunPositions, 3, nnotStyle);
                ICurve crvB = Rhinoceros.Convert.ToBHoM(crv);
                paths.Add(crvB); 
                }
            return paths;
        }

        /***************************************************/
    }


}