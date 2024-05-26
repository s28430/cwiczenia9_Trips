﻿using System;
using System.Collections.Generic;

namespace Trips.Entities;

public partial class ClientTrip
{
    public int IdClient { get; set; }

    public int IdTrip { get; set; }

    public DateTime RegisteredAt { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Trip IdTripDtoNavigation { get; set; } = null!;
}
