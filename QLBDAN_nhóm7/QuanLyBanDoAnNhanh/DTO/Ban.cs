﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanDoAnNhanh.DTO
{
    public class Ban
    {
        public Ban(int id, string name, string status)
        {
            this.ID = id;
            this.Name  = name;
            this.Status = status;
        }

        public Ban(DataRow row)
        {
            this.ID  = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Status = row["status"].ToString();
        }

        public string status;
        public string Status
        {
            get { return status; }  
            set { status = value; } 
        }

        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
