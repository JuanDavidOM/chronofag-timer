﻿/*
 *  Copyright (C) 2017 HarpyWar <harpywar@gmail.com>
 *  
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Windows.Forms;

namespace ChronoFagTimer
{
    public partial class NewUserTimerForm : Form
    {
        Config config;
        public NewUserTimerForm(Config config)
        {
            this.config = config;
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var seconds = txtHours.Value * 60 * 60 + txtMinutes.Value * 60 + txtSeconds.Value;
            var title = txtTitle.Text;
            ((TomatoForm)Owner).AddCustomTimer(title, (int)seconds);
            this.Close();
        }

        private void NewUserTimerForm_Load(object sender, EventArgs e)
        {
            lblCaption.Text = config.GetPhrase("timercaption");
            lblHours.Text = config.GetPhrase("timerhours");
            lblMinutes.Text = config.GetPhrase("timerminutes");
            lblSeconds.Text = config.GetPhrase("timerseconds");
            btnStart.Text = config.GetPhrase("timerstart");
        }

        private void txtTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnStart_Click(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
