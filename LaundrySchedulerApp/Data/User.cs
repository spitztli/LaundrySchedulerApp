﻿using Microsoft.EntityFrameworkCore;
using SQLite;

namespace LaundrySchedulerApp.Data
{
    public class User
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}