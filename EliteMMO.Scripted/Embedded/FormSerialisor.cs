namespace FormSerialisation
{
    using EliteMMO.Scripted.Views;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;
    public static class FormSerialisor
    {
        public static List<string> childCtrlskip = new List<string>(new string[] {"WaltzPTadd","PartyWaltsList","CurePTlist",
            "shutdowngroup"});
        public static void Serialise(Control c, string XmlFileName)
        {
            XmlTextWriter xmlSerialisedForm = new XmlTextWriter(XmlFileName, System.Text.Encoding.Default);
            xmlSerialisedForm.Formatting = Formatting.Indented;
            xmlSerialisedForm.WriteStartDocument();
            xmlSerialisedForm.WriteStartElement("ChildForm");
            AddChildControls(xmlSerialisedForm, c);
            xmlSerialisedForm.WriteStartElement("Control");
            xmlSerialisedForm.WriteAttributeString("Type", "Extra");
            xmlSerialisedForm.WriteAttributeString("Name", "Extra");
            xmlSerialisedForm.WriteElementString("idleX", ScriptFarmDNC.idleX.ToString());
            xmlSerialisedForm.WriteElementString("idleY", ScriptFarmDNC.idleY.ToString());
            xmlSerialisedForm.WriteElementString("idleZ", ScriptFarmDNC.idleZ.ToString());
            xmlSerialisedForm.WriteEndElement();
            xmlSerialisedForm.WriteEndElement();
            xmlSerialisedForm.WriteEndDocument();
            xmlSerialisedForm.Flush();
            xmlSerialisedForm.Close();
            
        }
        private static void AddChildControls(XmlTextWriter xmlSerialisedForm, Control c)
        {
            foreach (Control childCtrl in c.Controls)
            {
                if (!(childCtrl is Label) && !(childCtrl is ListView) && !(childCtrl is MenuStrip) &&
                      childCtrl.GetType().ToString() != "System.Windows.Forms.UpDownBase+UpDownEdit" &&
                      childCtrl.GetType().ToString() != "System.Windows.Forms.UpDownBase+UpDownButtons" &&
                      childCtrl.GetType().ToString() != "System.Windows.Forms.Button" && !childCtrlskip.Contains(childCtrl.Name))
                {
                    xmlSerialisedForm.WriteStartElement("Control");
                    xmlSerialisedForm.WriteAttributeString("Type", childCtrl.GetType().ToString());
                    xmlSerialisedForm.WriteAttributeString("Name", childCtrl.Name);
                    if (childCtrl is TextBox)
                    {
                        xmlSerialisedForm.WriteElementString("Text", ((TextBox)childCtrl).Text);
                    }
                    else if (childCtrl is RadioButton)
                    {
                        xmlSerialisedForm.WriteElementString("Checked", ((RadioButton)childCtrl).Checked.ToString());
                    }
                    else if (childCtrl is NumericUpDown)
                    {
                        xmlSerialisedForm.WriteElementString("Value", ((NumericUpDown)childCtrl).Value.ToString());
                        xmlSerialisedForm.WriteElementString("Enabled", ((NumericUpDown)childCtrl).Enabled.ToString());
                    }
                    else if (childCtrl is GroupBox)
                    {
                        xmlSerialisedForm.WriteElementString("Enabled", ((GroupBox)childCtrl).Enabled.ToString());
                    }
                    else if (childCtrl is CheckedListBox)
                    {
                        CheckedListBox lst = (CheckedListBox)childCtrl;
                        var count = 0;
                        foreach (string i in lst.CheckedItems)
                        {
                            xmlSerialisedForm.WriteElementString("SelectedItem" + count, i);
                            count++;
                        }
                        xmlSerialisedForm.WriteElementString("SelectedIndexcount", (lst.CheckedIndices.Count.ToString()));
                    }
                    else if (childCtrl is ComboBox)
                    {
                        xmlSerialisedForm.WriteElementString("Text", ((ComboBox)childCtrl).Text);
                    }
                    else if (childCtrl is CheckBox)
                    {
                        xmlSerialisedForm.WriteElementString("Checked", ((CheckBox)childCtrl).Checked.ToString());
                        xmlSerialisedForm.WriteElementString("Enabled", ((CheckBox)childCtrl).Enabled.ToString());
                        xmlSerialisedForm.WriteElementString("CheckState", ((CheckBox)childCtrl).CheckState.ToString());
                    }
                    if (childCtrl.HasChildren)
                    {
                        if (childCtrl is SplitContainer)
                        {
                            AddChildControls(xmlSerialisedForm, ((SplitContainer)childCtrl).Panel1);
                            AddChildControls(xmlSerialisedForm, ((SplitContainer)childCtrl).Panel2);
                        }
                        else
                        {
                            AddChildControls(xmlSerialisedForm, childCtrl);
                        }
                    }
                    xmlSerialisedForm.WriteEndElement();
                }
            }
        }
        public static void Deserialise(Control c, string XmlFileName)
        {
            if (File.Exists(XmlFileName))
            {
                XmlDocument xmlSerialisedForm = new XmlDocument();
                xmlSerialisedForm.Load(XmlFileName);
                XmlNode topLevel = xmlSerialisedForm.ChildNodes[1];
                foreach (XmlNode n in topLevel.ChildNodes)
                {
                    SetControlProperties((Control)c, n);
                }
                XmlNode secondLevel = xmlSerialisedForm.ChildNodes[2];
            }
        }
        private static void SetControlProperties(Control currentCtrl, XmlNode n)
        {
            string controlName = n.Attributes["Name"].Value;
            if (controlName == "Extra")
            {
                ScriptFarmDNC.idleX = float.Parse(n["idleX"].InnerText);
                ScriptFarmDNC.idleY = float.Parse(n["idleY"].InnerText);
                ScriptFarmDNC.idleZ = float.Parse(n["idleZ"].InnerText);
            }
            if (controlName == "") return;
            string controlType = n.Attributes["Type"].Value;
            if (controlType == "") return;
            Control[] ctrl = currentCtrl.Controls.Find(controlName, true);
            if (ctrl.Length > 0)
            {
                Control ctrlToSet = GetImmediateChildControl(ctrl, currentCtrl);
                if (ctrlToSet != null)
                {
                    if (ctrlToSet.GetType().ToString() == controlType)
                    {
                        switch (controlType)
                        {
                            case "Extra":
                                break;
                            case "System.Windows.Forms.CheckedListBox":
                                CheckedListBox ltr = (CheckedListBox)ctrlToSet;
                                var Icount=Convert.ToInt32(n["SelectedIndexcount"].InnerText);
                                foreach (int i in ltr.CheckedIndices)
                                {
                                    ltr.SetItemCheckState(i, CheckState.Unchecked);
                                }
                                for (int i = 0; i < (Icount); i++)
                                {
                                    var sitem = n["SelectedItem" + i.ToString()].InnerText;
                                    if (sitem != null && ltr.Items.Contains(sitem))
                                    {
                                        var index = ltr.Items.IndexOf(sitem);
                                        ltr.SetItemCheckState(index, CheckState.Checked);
                                        ltr.SetSelected(index, true);
                                    }
                                }
                                break;
                            case "System.Windows.Forms.RadioButton":
                                ((RadioButton)ctrlToSet).Checked = Convert.ToBoolean(n["Checked"].InnerText);
                                break;
                            case "System.Windows.Forms.GroupBox":
                                ((GroupBox)ctrlToSet).Enabled = Convert.ToBoolean(n["Enabled"].InnerText);
                                break;
                            case "System.Windows.Forms.NumericUpDown":
                                ((NumericUpDown)ctrlToSet).Value = Convert.ToDecimal(n["Value"].InnerText);
                                ((NumericUpDown)ctrlToSet).Enabled = Convert.ToBoolean(n["Enabled"].InnerText);
                                break;
                            case "System.Windows.Forms.TextBox":
                                ((TextBox)ctrlToSet).Text = n["Text"].InnerText;
                                break;
                            case "System.Windows.Forms.ComboBox":
                                if (((ComboBox)ctrlToSet).Text == "Not Selected")
                                {
                                    ((ComboBox)ctrlToSet).Text = n["Text"].InnerText;
                                }
                                else
                                    ((ComboBox)ctrlToSet).Text = "";

                                ((ComboBox)ctrlToSet).SelectedText = n["Text"].InnerText;
                                break;
                            case "System.Windows.Forms.CheckBox":
                                ((CheckBox)ctrlToSet).Checked = Convert.ToBoolean(n["Checked"].InnerText);
                                ((CheckBox)ctrlToSet).CheckState = (CheckState)Enum.Parse(typeof(CheckState), n["CheckState"].InnerText);
                                break;
                        }
                        if (n.HasChildNodes && ctrlToSet.HasChildren)
                        {
                            XmlNodeList xnlControls = n.SelectNodes("Control");
                            foreach (XmlNode n2 in xnlControls)
                            {
                                SetControlProperties(ctrlToSet, n2);
                            }
                        }
                    }
                }
            }
        }
        private static Control GetImmediateChildControl(Control[] ctrl, Control currentCtrl)
        {
            Control c = null;
            for (int i = 0; i < ctrl.Length; i++)
            {
                if ((ctrl[i].Parent.Name == currentCtrl.Name) || (currentCtrl is SplitContainer && ctrl[i].Parent.Parent.Name == currentCtrl.Name))
                {
                    c = ctrl[i];
                    break;
                }
            }
            return c;
        }
    }
}
