﻿using BjBygg.Application.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace BjBygg.Application.Queries.DbSyncQueries.SyncAll
{
    public class SyncAllResponse
    {
        public DbSyncResponse<MissionDto> MissionSync { get; set; }

        public DbSyncResponse<EmployerDto> EmployerSync { get; set; }

        public DbSyncResponse<MissionImageDto> MissionImageSync { get; set; }

        public DbSyncResponse<MissionNoteDto> MissionNoteSync { get; set; }

        public DbSyncResponse<MissionReportDto> MissionReportSync { get; set; }

        public DbSyncResponse<MissionReportTypeDto> MissionReportTypeSync { get; set; }

        public DbSyncResponse<MissionTypeDto> MissionTypeSync { get; set; }

        public DbSyncResponse<TimesheetWeekDto> TimesheetWeekSync { get; set; }

        public DbSyncResponse<TimesheetDto> TimesheetSync { get; set; }

    }
}