﻿using System;
using System.Collections.Generic;

namespace Drivers.DAL_EF.Entities;

public partial class EFCompany
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = null!;
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? ContactPerson { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public virtual EFDriver? Driver { get; set; }
}
