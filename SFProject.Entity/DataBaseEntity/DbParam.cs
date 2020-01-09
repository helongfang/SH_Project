﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFProject.Entity.DataBaseEntity
{
    public class DbParam
    {
        public string Name { get; set; }

        public DbType Type { get; set; }

        public int Size { get; set; }

        public object Value { get; set; }

        public ParameterDirection Direction { get; set; }

        public DbParam(string name, DbType type, object value, ParameterDirection dirction)
        {
            this.Name = name;
            this.Type = type;
            this.Value = value;
            this.Direction = dirction;
            this.Size = 0;
        }

        public DbParam(string name, DbType type, object value, ParameterDirection dirction, int size)
            : this(name, type, value, dirction)
        {
            this.Size = size;
        }

        public static DbParam Create(string name, DbType type, object value, ParameterDirection dirction = ParameterDirection.Input, int size = 0)
        {
            return new DbParam(name, type, value, dirction, size);
        }
    }
}
