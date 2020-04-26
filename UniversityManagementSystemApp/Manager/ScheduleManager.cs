using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class ScheduleManager
    {
        ClassSchduleGateWay schduleGateWay = new ClassSchduleGateWay();

        public string ClassSchedules(int deptId, int courseId)
        {
            IEnumerable<ClassSchedule> sheduleList = schduleGateWay.ClassSchedule(deptId, courseId);
            string output = "";
            foreach (var aschedule in sheduleList)
            {
                if (aschedule.RoomName.StartsWith("N"))
                {
                    output = aschedule.RoomName;
                }
                else
                {
                    output += aschedule.RoomName + ", " + aschedule.DayName + ", " + aschedule.StartTime + " - " + aschedule.EndTime + ";<br />";
                }
            }
            return output;
        }
    }
}