﻿using DataModel.Entities;
using Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Store.ProductForms
{
    public partial class SerialNumbers : Form
    {
        private List<SerialNumber> seriallist;
        private int count;
        private bool abletodelete = false;
        private ISerialNumberLogic serialnumlogic;
        private TextBox[] serialnumBoxes;
        public SerialNumbers(List<SerialNumber> seriallist,int count)
        {
            this.seriallist = seriallist;
            this.count = count;
            serialnumBoxes = new TextBox[count];
            InitializeComponent();
            createSerialBox(count);
            FillTextBox();
        }

        public SerialNumbers(List<SerialNumber> seriallist,int count,ISerialNumberLogic serialnumlogic)
        {
            this.seriallist = seriallist;
            this.count = count;
            abletodelete = true;
            this.serialnumlogic = serialnumlogic;
            serialnumBoxes = new TextBox[count];
            InitializeComponent();
            createSerialBox(count);
            FillTextBox();
        }
        private void createSerialBox(int count)
        {
            Button[] deletebuttons = new Button[count];

            for (int u = 0; u < serialnumBoxes.Count(); u++)
            {
                serialnumBoxes[u] = new TextBox();
                deletebuttons[u] = new Button();
            }
            int i = 0;
            foreach (TextBox txt in serialnumBoxes)
            {
                Button button = new Button();
                button.Name = i.ToString();
                button.Parent = parentpanel;
                button.Size = new Size(50, 20);
                button.Text = "Delete";
                button.Click += new System.EventHandler(this.deletebutton_click);
                
                int lochight = 10 + (i * 28);
                int locwidth = 20;
                txt.Parent = parentpanel;
                txt.Name = "serialnumber" + i.ToString();
                if (i % 2 == 0)
                {
                    txt.Location = new Point(locwidth, 10 + (i / 2 * 28));
                    button.Location = new Point(locwidth + 160, 10 + (i / 2 * 28));
                }
                else
                {
                    txt.Location = new Point(locwidth + 220, 10 + ((i - 1) / 2 * 28));
                    button.Location = new Point(locwidth + 160+220, 10 + (i / 2 * 28));
                }
                txt.Visible = true;
                txt.Size = new Size(150, 20);
                parentpanel.Controls.Add(txt);
                if (abletodelete)
                {
                    parentpanel.Controls.Add(button);
                }
                i++;
                if (lochight+24>parentpanel.Height)
                {
                    parentpanel.Size = new Size(parentpanel.Width, parentpanel.Height + 100);
                }
            }
        }
        private void GetTextBoxStrings(List<SerialNumber> list)
        {
            int counter = 0;
            foreach (Control c in parentpanel.Controls)
            {
                if (c is TextBox)
                {
                    if (list.Count>counter)
                    {
                        if (((TextBox)c).Text != list[counter].SerialNum)
                        {
                            list[counter].SerialNum = ((TextBox)c).Text;
                            list[counter].Modified = true;
                        }
                    }
                    else if(((TextBox)c).Text.Trim() != String.Empty)
                    {
                        SerialNumber serialnum = new SerialNumber();
                        serialnum.SerialNum = ((TextBox)c).Text;
                        list.Add(serialnum);
                    }
                }
                counter++;
            }
        }

        private void deletebutton_click(object sender, EventArgs e)
        {
            Button currentbutton = (Button)sender;
            string textboxname = "serialnumber" + currentbutton.Name;
            TextBox currenttextbox = serialnumBoxes.FirstOrDefault(p => p.Name == textboxname);
            serialnumlogic.DeleteByUnique(currenttextbox.Text);
        }

        private void FillTextBox()
        {
            int i=0;
            foreach (Control c in parentpanel.Controls)
            {
                if (i<seriallist.Count)
                {
                    if (c is TextBox)
                        c.Text = seriallist[i].SerialNum;
                    else
                        continue;
                }
                i++;
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTextBoxStrings(seriallist);
            this.DialogResult = DialogResult.OK;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox txt = new TextBox();
            int i = parentpanel.Controls.Count;
            string name = "serialnumber" + i.ToString();
            int lochight = 10 + (i * 28);
            int locweight = 20;
            txt.Parent = parentpanel;
            txt.Name = name;
            if (i % 2 == 0)
                txt.Location = new Point(locweight, 10 + (i / 2 * 28));
            else
                txt.Location = new Point(locweight + 220, 10 + ((i - 1) / 2 * 28));
            txt.Visible = true;
            txt.Size = new Size(200, 20);
            parentpanel.Controls.Add(txt);
            i++;
            if (lochight + 24 > parentpanel.Height)
            {
                parentpanel.Size = new Size(parentpanel.Width, parentpanel.Height + 100);
            }
        }
    }
}
