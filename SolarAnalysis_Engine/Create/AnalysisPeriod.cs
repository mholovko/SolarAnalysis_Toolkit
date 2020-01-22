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
using System.Text;
using System.Threading.Tasks;
using BH.oM.Environment.Climate;
using BH.oM.Geometry;

using BH.oM.Reflection.Attributes;
using System.ComponentModel;
using BH.oM.SolarAnalysis;

namespace BH.Engine.SolarAnalysis

{
    public static partial class Create
    {
        /***************************************************/
        /**** Public Methods                            ****/
        /***************************************************/

        public static AnalysisPeriod AnalysisPeriod(SpaceTime spaceTimeStart, SpaceTime spaceTimeEnd)
        {
            //DateTime startDateTime = Convert.ToDateTime(spaceTimeStart);
            //DateTime endDateTime = Convert.ToDateTime(spaceTimeEnd);
            DateTime startDateTime = new DateTime(spaceTimeStart.Year, spaceTimeStart.Month, spaceTimeStart.Day, spaceTimeStart.Hour, spaceTimeStart.Minute, spaceTimeStart.Second, spaceTimeStart.Millisecond);
            DateTime endDateTime = new DateTime(spaceTimeEnd.Year, spaceTimeEnd.Month, spaceTimeEnd.Day, spaceTimeEnd.Hour, spaceTimeEnd.Minute, spaceTimeEnd.Second, spaceTimeEnd.Millisecond);
            PeriodType periodType;

            TimeSpan period = endDateTime - startDateTime;

            if (period.TotalHours < 0)
            {
                spaceTimeEnd = spaceTimeStart;

            }

            if (period.TotalHours >= 1)
            {
                if (period.TotalHours > 24)
                {
                    periodType = PeriodType.Period;
                }
                else
                {
                    periodType = PeriodType.Day;
                }
            }
            else 
            {
                periodType = PeriodType.Point;
            }


            AnalysisPeriod analysisPeriod = new AnalysisPeriod
            {
                StartTime = spaceTimeStart,
                EndTime = spaceTimeEnd,
                Type = periodType
            };
            return analysisPeriod;
        }
    }
}