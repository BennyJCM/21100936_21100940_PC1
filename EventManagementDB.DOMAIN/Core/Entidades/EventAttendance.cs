﻿using System;
using System.Collections.Generic;

namespace EventManagementDB.DOMAIN.Core.Entidades;

public partial class EventAttendance
{
    public int Id { get; set; }

    public int? EventId { get; set; }

    public int? AttendeeId { get; set; }

    public bool Attended { get; set; }

    public DateTime? CheckedInAt { get; set; }

    public virtual Attendees? Attendee { get; set; }

    public virtual Events? Event { get; set; }
}