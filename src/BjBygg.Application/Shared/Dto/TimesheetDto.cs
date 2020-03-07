﻿using CleanArchitecture.Core.Enums;
using CleanArchitecture.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BjBygg.Application.Shared
{
    public class TimesheetDto : DbSyncDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public int MissionId { get; set; }

        public int TimesheetWeekId { get; set; }

        public TimesheetWeekDto TimesheetWeek { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimesheetStatus Status { get; set; }
    }
}