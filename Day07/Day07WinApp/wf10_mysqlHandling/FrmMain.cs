﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wf10_mysqlHandling
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // MySQL 연결 문자열
            string connectionString = "Server=localhost;Port=3306;Database=bookrentalshop;Uid=root;Pwd=12345;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            
            conn.Open();

            string selQuery = @"SELECT memberIdx
	                                , Names
                                    , Levels
                                    , Addr
                                    , Mobile
                                    , Email
                                 FROM membertbl;";

            MySqlDataAdapter adpter = new MySqlDataAdapter(selQuery, conn);

            DataSet ds = new DataSet();
            adpter.Fill(ds);

            BindingSource source = new BindingSource();  
            source.DataSource = ds.Tables[0];
            
            DgvMember.DataSource = source;

            conn.Close();
        }
    }
}
