﻿using System;
using System.Collections.Generic;

namespace WebApplication1_feb16.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Designation { get; set; }
}
