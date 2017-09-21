﻿using System;
using System.Windows.Forms;
using System.Timers;

namespace PortugalVistoCheckerTraySystem
{
    class ContextMenus
    {
        /// <summary>
        /// Is the About box displayed?
        /// </summary>
        bool isLogsLoaded = false;
        Form form = new FormLog();
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ContextMenuStrip</returns>
        public ContextMenuStrip Create()
        {
            // Add the default menu options.
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;
            ToolStripSeparator sep;

            // Windows Explorer.
            item = new ToolStripMenuItem();
            item.Text = "Refresh";
            item.Click += new EventHandler(Refresh_Click);
            menu.Items.Add(item);

            // About.
            item = new ToolStripMenuItem();
            item.Text = "Info";
            item.Click += new EventHandler(Log_Click);
            menu.Items.Add(item);

            // Separator.
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            // Exit.
            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new System.EventHandler(Exit_Click);
            menu.Items.Add(item);

            return menu;
        }

        /// <summary>
        /// Handles the Click event of the Explorer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Refresh_Click(object sender, EventArgs e)
        {
            Program.pi.CheckStatus();
        }

        /// <summary>
        /// Handles the Click event of the About control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Log_Click(object sender, EventArgs e)
        {
            if (!isLogsLoaded)
            {
                isLogsLoaded = true;
                form.ShowDialog();
                isLogsLoaded = false;
            }
            else
            {
                form.Focus();
            }
        }

        /// <summary>
        /// Processes a menu item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Exit_Click(object sender, EventArgs e)
        {
            // Quit without further ado.
            Application.Exit();
        }
    }
}