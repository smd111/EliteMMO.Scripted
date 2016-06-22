namespace EliteMMO.Scripted.Views
{
    using API;
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    partial class ScriptOnEventTool
    {
        private static EliteAPI api;
        public static bool botRunning = false;
        public string fileXML;
        public string _ext;
        public static string triggeredline = "";
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public enum CType : short
        {
            SentSay = 1,			    // = a say message that the user sends
            SentShout = 2,		        // = a shout message that the user sends
            SentYell = 3,
            SentTell = 4,			    // = user sends tell to someone else
            SentParty = 5,		        // = user message to Party
            SentLinkShell = 6,	        // = user message to linkshell
            SentEmote = 7,			    // = user uses /emote
        }
        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.addSettarget = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.useRegEx = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChatType = new System.Windows.Forms.ComboBox();
            this.StartStop = new System.Windows.Forms.MenuStrip();
            this.startScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label52 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.eCommand = new System.Windows.Forms.TextBox();
            this.Events = new System.Windows.Forms.ListView();
            this.ET = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.command = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GetSetEvents = new System.Windows.Forms.MenuStrip();
            this.loadOEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCheckedOEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateEvent = new System.Windows.Forms.MenuStrip();
            this.addNewEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chatEvent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bgw_script_events = new System.ComponentModel.BackgroundWorker();
            this.groupBox4.SuspendLayout();
            this.StartStop.SuspendLayout();
            this.GetSetEvents.SuspendLayout();
            this.CreateEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.addSettarget);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.useRegEx);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.ChatType);
            this.groupBox4.Controls.Add(this.StartStop);
            this.groupBox4.Controls.Add(this.label52);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.eCommand);
            this.groupBox4.Controls.Add(this.Events);
            this.groupBox4.Controls.Add(this.GetSetEvents);
            this.groupBox4.Controls.Add(this.CreateEvent);
            this.groupBox4.Controls.Add(this.chatEvent);
            this.groupBox4.Location = new System.Drawing.Point(10, 30);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(455, 397);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "On Event Tool";
            // 
            // addSettarget
            // 
            this.addSettarget.Location = new System.Drawing.Point(12, 311);
            this.addSettarget.Name = "addSettarget";
            this.addSettarget.Size = new System.Drawing.Size(40, 23);
            this.addSettarget.TabIndex = 37;
            this.addSettarget.Text = "ADD";
            this.addSettarget.UseVisualStyleBackColor = true;
            this.addSettarget.Click += new System.EventHandler(this.addSettarget_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 255);
            this.label3.MaximumSize = new System.Drawing.Size(160, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 52);
            this.label3.TabIndex = 36;
            this.label3.Text = "To SetTarget. Target what you want to target then click \"ADD\" and it will be put " +
    "into Execute Command box.";
            // 
            // useRegEx
            // 
            this.useRegEx.AutoSize = true;
            this.useRegEx.Location = new System.Drawing.Point(284, 320);
            this.useRegEx.Name = "useRegEx";
            this.useRegEx.Size = new System.Drawing.Size(144, 17);
            this.useRegEx.TabIndex = 35;
            this.useRegEx.Text = "Use Regular Expressions";
            this.useRegEx.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Chat Type";
            // 
            // ChatType
            // 
            this.ChatType.Enabled = false;
            this.ChatType.FormattingEnabled = true;
            this.ChatType.Items.AddRange(new object[] {
            "Say",
            "Shout",
            "Yell",
            "Tell",
            "Party",
            "Linkshell",
            "Emote"});
            this.ChatType.Location = new System.Drawing.Point(284, 296);
            this.ChatType.Name = "ChatType";
            this.ChatType.Size = new System.Drawing.Size(160, 21);
            this.ChatType.TabIndex = 33;
            this.ChatType.Text = "ALL";
            // 
            // StartStop
            // 
            this.StartStop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StartStop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startScriptToolStripMenuItem,
            this.stopScriptToolStripMenuItem});
            this.StartStop.Location = new System.Drawing.Point(3, 370);
            this.StartStop.Name = "StartStop";
            this.StartStop.Size = new System.Drawing.Size(449, 24);
            this.StartStop.TabIndex = 31;
            this.StartStop.Text = "menuStrip1";
            // 
            // startScriptToolStripMenuItem
            // 
            this.startScriptToolStripMenuItem.Name = "startScriptToolStripMenuItem";
            this.startScriptToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startScriptToolStripMenuItem.Text = "Start";
            this.startScriptToolStripMenuItem.Click += new System.EventHandler(this.ToolStartClick);
            // 
            // stopScriptToolStripMenuItem
            // 
            this.stopScriptToolStripMenuItem.Enabled = false;
            this.stopScriptToolStripMenuItem.Name = "stopScriptToolStripMenuItem";
            this.stopScriptToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.stopScriptToolStripMenuItem.Text = "Stop";
            this.stopScriptToolStripMenuItem.Click += new System.EventHandler(this.ToolStopClick);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(182, 278);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(96, 13);
            this.label52.TabIndex = 30;
            this.label52.Text = "Execute Command";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Chat Event";
            // 
            // eCommand
            // 
            this.eCommand.Location = new System.Drawing.Point(284, 274);
            this.eCommand.Name = "eCommand";
            this.eCommand.Size = new System.Drawing.Size(160, 20);
            this.eCommand.TabIndex = 28;
            // 
            // Events
            // 
            this.Events.CheckBoxes = true;
            this.Events.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ET,
            this.command,
            this.CT,
            this.RE});
            this.Events.FullRowSelect = true;
            this.Events.GridLines = true;
            this.Events.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.Events.Location = new System.Drawing.Point(12, 48);
            this.Events.Name = "Events";
            this.Events.Size = new System.Drawing.Size(432, 198);
            this.Events.TabIndex = 27;
            this.Events.UseCompatibleStateImageBehavior = false;
            this.Events.View = System.Windows.Forms.View.Details;
            this.Events.DoubleClick += new System.EventHandler(this.Events_DoubleClick);
            // 
            // ET
            // 
            this.ET.Text = "Event Text";
            this.ET.Width = 134;
            // 
            // command
            // 
            this.command.Text = "Command Execute";
            this.command.Width = 169;
            // 
            // CT
            // 
            this.CT.Text = "Chat Type";
            this.CT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CT.Width = 78;
            // 
            // RE
            // 
            this.RE.Text = "RegEx";
            this.RE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RE.Width = 47;
            // 
            // GetSetEvents
            // 
            this.GetSetEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadOEToolStripMenuItem,
            this.saveOEToolStripMenuItem,
            this.editSelectedToolStripMenuItem,
            this.removeCheckedOEToolStripMenuItem});
            this.GetSetEvents.Location = new System.Drawing.Point(3, 16);
            this.GetSetEvents.Name = "GetSetEvents";
            this.GetSetEvents.Size = new System.Drawing.Size(449, 24);
            this.GetSetEvents.TabIndex = 0;
            this.GetSetEvents.Text = "GetSetEvents";
            // 
            // loadOEToolStripMenuItem
            // 
            this.loadOEToolStripMenuItem.Name = "loadOEToolStripMenuItem";
            this.loadOEToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.loadOEToolStripMenuItem.Text = "Load";
            this.loadOEToolStripMenuItem.Click += new System.EventHandler(this.LoadOEToolStripMenuItemClick);
            // 
            // saveOEToolStripMenuItem
            // 
            this.saveOEToolStripMenuItem.Enabled = false;
            this.saveOEToolStripMenuItem.Name = "saveOEToolStripMenuItem";
            this.saveOEToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveOEToolStripMenuItem.Text = "Save";
            this.saveOEToolStripMenuItem.Click += new System.EventHandler(this.SaveOEToolStripMenuItemClick);
            // 
            // editSelectedToolStripMenuItem
            // 
            this.editSelectedToolStripMenuItem.Enabled = false;
            this.editSelectedToolStripMenuItem.Name = "editSelectedToolStripMenuItem";
            this.editSelectedToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.editSelectedToolStripMenuItem.Text = "Edit Selected";
            this.editSelectedToolStripMenuItem.Click += new System.EventHandler(this.EditSelectedToolStripMenuItemClick);
            // 
            // removeCheckedOEToolStripMenuItem
            // 
            this.removeCheckedOEToolStripMenuItem.Enabled = false;
            this.removeCheckedOEToolStripMenuItem.Name = "removeCheckedOEToolStripMenuItem";
            this.removeCheckedOEToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.removeCheckedOEToolStripMenuItem.Text = "Remove Checked";
            this.removeCheckedOEToolStripMenuItem.Click += new System.EventHandler(this.RemoveCheckedOEToolStripMenuItemClick);
            // 
            // CreateEvent
            // 
            this.CreateEvent.Dock = System.Windows.Forms.DockStyle.None;
            this.CreateEvent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewEventToolStripMenuItem});
            this.CreateEvent.Location = new System.Drawing.Point(284, 340);
            this.CreateEvent.Name = "CreateEvent";
            this.CreateEvent.Size = new System.Drawing.Size(122, 24);
            this.CreateEvent.TabIndex = 32;
            this.CreateEvent.Text = "menuStrip2";
            // 
            // addNewEventToolStripMenuItem
            // 
            this.addNewEventToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.addNewEventToolStripMenuItem.Name = "addNewEventToolStripMenuItem";
            this.addNewEventToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.addNewEventToolStripMenuItem.Text = "Create/Save Event";
            this.addNewEventToolStripMenuItem.Click += new System.EventHandler(this.AddNewEventToolStripMenuItemClick);
            // 
            // chatEvent
            // 
            this.chatEvent.Location = new System.Drawing.Point(284, 252);
            this.chatEvent.Name = "chatEvent";
            this.chatEvent.Size = new System.Drawing.Size(160, 20);
            this.chatEvent.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(87, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 10;
            // 
            // bgw_script_events
            // 
            this.bgw_script_events.WorkerReportsProgress = true;
            this.bgw_script_events.WorkerSupportsCancellation = true;
            this.bgw_script_events.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgwScriptEventsDoWork);
            // 
            // ScriptOnEventTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label1);
            this.Name = "ScriptOnEventTool";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 5, 25);
            this.Size = new System.Drawing.Size(474, 435);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.StartStop.ResumeLayout(false);
            this.StartStop.PerformLayout();
            this.GetSetEvents.ResumeLayout(false);
            this.GetSetEvents.PerformLayout();
            this.CreateEvent.ResumeLayout(false);
            this.CreateEvent.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.Label label52;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox eCommand;
        public new System.Windows.Forms.ListView Events;
        public System.Windows.Forms.ColumnHeader ET;
        public System.Windows.Forms.ColumnHeader command;
        public System.Windows.Forms.MenuStrip GetSetEvents;
        public System.Windows.Forms.ToolStripMenuItem loadOEToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveOEToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem removeCheckedOEToolStripMenuItem;
        public System.Windows.Forms.TextBox chatEvent;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.MenuStrip StartStop;
        public System.Windows.Forms.ToolStripMenuItem startScriptToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem stopScriptToolStripMenuItem;
        public System.Windows.Forms.MenuStrip CreateEvent;
        public System.Windows.Forms.ToolStripMenuItem addNewEventToolStripMenuItem;
        public System.ComponentModel.BackgroundWorker bgw_script_events;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox ChatType;
        public System.Windows.Forms.CheckBox useRegEx;
        public System.Windows.Forms.ColumnHeader CT;
        public System.Windows.Forms.ColumnHeader RE;
        public System.Windows.Forms.ToolStripMenuItem editSelectedToolStripMenuItem;
        private Button addSettarget;
        private Label label3;
        private void ToolStartClick(object sender, EventArgs e)
        {
            botRunning = true;

            startScriptToolStripMenuItem.Enabled = false;
            stopScriptToolStripMenuItem.Enabled = true;

            if (!bgw_script_events.IsBusy)
                bgw_script_events.RunWorkerAsync();
        }
        private void ToolStopClick(object sender, EventArgs e)
        {
            botRunning = false;

            startScriptToolStripMenuItem.Enabled = true;
            stopScriptToolStripMenuItem.Enabled = false;

            bgw_script_events.CancelAsync();
        }
        private void AddNewEventToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(chatEvent.Text) ||
                !string.IsNullOrEmpty(eCommand.Text))
            {
                var items = new string[] {chatEvent.Text, eCommand.Text, ChatType.Text, useRegEx.Checked.ToString()};

                if (Events.SelectedItems.Count > 0)
                {
                    var selected = Events.SelectedItems[0];
                    selected.SubItems[0].Text = chatEvent.Text;
                    selected.SubItems[1].Text = eCommand.Text;
                    selected.SubItems[2].Text = ChatType.Text;
                    selected.SubItems[3].Text = useRegEx.Checked.ToString();
                    Events.SelectedItems.Clear();
                }
                else
                {
                    var item = new ListViewItem(items);
                    Events.Items.Add(item);
                }

                if (saveOEToolStripMenuItem.Enabled == false)
                    saveOEToolStripMenuItem.Enabled = true;

                if (removeCheckedOEToolStripMenuItem.Enabled == false)
                    removeCheckedOEToolStripMenuItem.Enabled = true;

                if (editSelectedToolStripMenuItem.Enabled == false)
                    editSelectedToolStripMenuItem.Enabled = true;

                chatEvent.Text = "";
                eCommand.Text = "";

                if (_ext == ".oef" || _ext == "xml")
                {
                    XmlDocument _saveFile = new XmlDocument();

                    XmlNode rootNode = _saveFile.CreateElement("OnEventsList");
                    _saveFile.AppendChild(rootNode);

                    for (var x = 0; x < Events.Items.Count; x++)
                    {
                        XmlNode userNode = _saveFile.CreateElement("Event");

                        if (_ext == ".oef")
                        {
                            XmlAttribute ChatEvent = _saveFile.CreateAttribute("eventtext");
                            ChatEvent.Value = Events.Items[x].SubItems[0].Text.ToString();
                            userNode.Attributes.Append(ChatEvent);

                            XmlAttribute EventCommand = _saveFile.CreateAttribute("eventcmd");
                            EventCommand.Value = Events.Items[x].SubItems[1].Text.ToString();
                            userNode.Attributes.Append(EventCommand);

                            XmlAttribute isChecked = _saveFile.CreateAttribute("eventchecked");
                            isChecked.Value = Events.Items[x].Checked.ToString();
                            userNode.Attributes.Append(isChecked);
                        }

                        if (_ext == ".xml")
                        {
                            XmlAttribute isChecked = _saveFile.CreateAttribute("isChecked");
                            isChecked.Value = Events.Items[x].Checked.ToString();
                            rootNode.AppendChild(userNode);

                            XmlAttribute ChatEvent = _saveFile.CreateAttribute("ChatEvent");
                            ChatEvent.Value = Events.Items[x].SubItems[0].Text.ToString();
                            rootNode.AppendChild(userNode);

                            XmlAttribute EventCommand = _saveFile.CreateAttribute("EventCommand");
                            EventCommand.Value = Events.Items[x].SubItems[1].Text.ToString();
                            rootNode.AppendChild(userNode);

                            XmlAttribute ChatTypeX = _saveFile.CreateAttribute("ChatType");
                            ChatTypeX.Value = Events.Items[x].SubItems[2].Text.ToString();
                            rootNode.AppendChild(userNode);

                            XmlAttribute isRegEx = _saveFile.CreateAttribute("isRegEx");
                            isRegEx.Value = Events.Items[x].SubItems[3].Text.ToString();
                            rootNode.AppendChild(userNode);
                        }

                        _saveFile.Save(fileXML);
                    }
                }
            }
        }
        private void Events_DoubleClick(object sender, EventArgs e)
        {
            if (Events.SelectedItems.Count <= 0) return;

            foreach (ListViewItem selected in Events.SelectedItems)
            {
                Events.Items.Remove(selected);
            }

            if (Events.Items.Count == 0)
            {
                saveOEToolStripMenuItem.Enabled = false;
                removeCheckedOEToolStripMenuItem.Enabled = false;
                editSelectedToolStripMenuItem.Enabled = false;
            }
        }
        private void LoadOEToolStripMenuItemClick(object sender, EventArgs e)
        {
            var eventPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Events\\";

            if (Directory.Exists(eventPath) == false)
                Directory.CreateDirectory(eventPath);

            OpenFileDialog _openFile = new OpenFileDialog();
            _openFile.Title = "Select OnEvents File To Load";
            _openFile.InitialDirectory = eventPath;
            _openFile.Filter = "OnEvent File (*.xml)|*.xml|OnEvent File (*.oef)|*.oef";
            _openFile.FilterIndex = 1;
            _openFile.RestoreDirectory = true;

            DialogResult _dlgResult = _openFile.ShowDialog();
            if (_dlgResult != DialogResult.OK)
                return;

            fileXML = _openFile.FileName;

            try
            {
                Events.Items.Clear();
                var ext = Path.GetExtension(_openFile.FileName);
                _ext = ext;

                if (ext == ".oef")
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(_openFile.FileName);

                    XmlNode mainNode = xmlDoc.SelectSingleNode("OnEventsList");
                    XmlNodeList nodeList = mainNode.ChildNodes;

                    for (int x = 0; x < nodeList.Count; x++)
                    {
                        Events.Items.Add(new ListViewItem(new string[]
                        {
                            nodeList[x].Attributes["eventtext"].Value.ToString(), 
                            nodeList[x].Attributes["eventcmd"].Value.ToString(),
                        }));
                        string temp = nodeList[x].Attributes["eventchecked"].Value.ToString();
                        Events.Items[x].Checked = Convert.ToBoolean(temp);

                        Events.Items[x].SubItems.Add("ALL");
                        Events.Items[x].SubItems.Add("False");
                    }
                }
                else if (ext == ".xml")
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(_openFile.FileName);

                    XmlNode mainNode = xmlDoc.SelectSingleNode("OnEventsList");
                    XmlNodeList nodeList = mainNode.ChildNodes;

                    for (var x = 0; x < nodeList.Count; x++)
                    {
                        Events.Items.Add(new ListViewItem(new string[]
                        {
                            nodeList[x].Attributes["ChatEvent"].Value.ToString(), 
                            nodeList[x].Attributes["EventCommand"].Value.ToString(),
                            nodeList[x].Attributes["ChatType"].Value.ToString(),
                            nodeList[x].Attributes["isRegEx"].Value.ToString()
                        }));
                        
                        var temp = nodeList[x].Attributes["isChecked"].Value.ToString();
                        Events.Items[x].Checked = Convert.ToBoolean(temp);
                    }
                }

                if (saveOEToolStripMenuItem.Enabled == false)
                    saveOEToolStripMenuItem.Enabled = true;

                if (removeCheckedOEToolStripMenuItem.Enabled == false)
                    removeCheckedOEToolStripMenuItem.Enabled = true;

                if (editSelectedToolStripMenuItem.Enabled == false)
                    editSelectedToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load the OnEvents file. Please try again.\n" + ex.Message);
                throw;
            }
        }
        private void SaveOEToolStripMenuItemClick(object sender, EventArgs e)
        {
            var eventPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Events\\";
            
            if (Directory.Exists(eventPath) == false)
                Directory.CreateDirectory(eventPath);

            SaveFileDialog _saveFile = new SaveFileDialog();
            _saveFile.Title = "Save OnEvents File";
            _saveFile.InitialDirectory = eventPath;
            _saveFile.Filter = "OnEvent File (*.xml)|*.xml";
            _saveFile.FilterIndex = 0;
            _saveFile.RestoreDirectory = true;

            DialogResult _dlgResult = _saveFile.ShowDialog();
            if (_dlgResult != DialogResult.OK) return;

            try
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(_saveFile.FileName, Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("OnEventsList");

                for (int i = 0; i < Events.Items.Count; i++)
                {
                    xmlWriter.WriteStartElement("Event");
                    xmlWriter.WriteAttributeString("isChecked", Events.Items[i].Checked.ToString());
                    xmlWriter.WriteAttributeString("ChatEvent", Events.Items[i].SubItems[0].Text.ToString());
                    xmlWriter.WriteAttributeString("EventCommand", Events.Items[i].SubItems[1].Text.ToString());
                    xmlWriter.WriteAttributeString("ChatType", Events.Items[i].SubItems[2].Text.ToString());
                    xmlWriter.WriteAttributeString("isRegEx", Events.Items[i].SubItems[3].Text.ToString());

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save OnEvents file. Please try another location.\n" + ex.Message);
                throw;
            }
        }
        private void RemoveCheckedOEToolStripMenuItemClick(object sender, EventArgs e)
        {
            foreach (ListViewItem items in Events.CheckedItems)
            {
                Events.Items.Remove(items);
            }

            if (Events.Items.Count == 0)
            {
                if (saveOEToolStripMenuItem.Enabled == true)
                    saveOEToolStripMenuItem.Enabled = false;

                if (removeCheckedOEToolStripMenuItem.Enabled == true)
                    removeCheckedOEToolStripMenuItem.Enabled = false;

                if (editSelectedToolStripMenuItem.Enabled == true)
                    editSelectedToolStripMenuItem.Enabled = false;   
            }
        }
        private void EditSelectedToolStripMenuItemClick(object sender, EventArgs e)
        {
            var i = Events.Items.IndexOf(Events.SelectedItems[0]);

            chatEvent.Text = Events.SelectedItems[0].SubItems[0].Text;
            eCommand.Text = Events.SelectedItems[0].SubItems[1].Text;
            ChatType.Text = Events.SelectedItems[0].SubItems[2].Text;

            if (Events.SelectedItems[0].SubItems[3].Text.ToString() == "False")
            {
                useRegEx.Checked = false;
            }
            else
            {
                useRegEx.Checked = true;
            }
        }
    }
}
