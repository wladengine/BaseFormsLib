using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaseFormsLib
{    
    public partial class Joints : UserControl
    {
        private DataTable _dataSource;
        public event EventHandler SelectedItemChanged;
        private IList<JointPair> _BackupedSelectedList;

        public Joints()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets top label text
        /// </summary>
        public string MainName
        {
            get { return lblCaption.Text; }
            set { lblCaption.Text = value; }
        }

        /// <summary>
        /// Gets or sets groupbox text
        /// </summary>
        public string SecondName
        {
            get { return gbSecond.Text; }
            set { gbSecond.Text = value; }
        }

        /// <summary>
        /// Sets data source for main element combobox
        /// </summary>
        public DataTable DataSource
        {
            set { _dataSource = value; }
        }

        /// <summary>
        /// Gets combobox selected item
        /// </summary>
        public object SelectedItem
        {
            get
            {
                return cmbMain.SelectedItem;
            }
        }

        /// <summary>
        /// Gets combobox selected value
        /// </summary>
        public object SelectedValue
        {
            get
            {
                return cmbMain.SelectedValue;
            }
        }

        /// <summary>
        /// Gets combobox selected text
        /// </summary>
        public string SelectedText
        {
            get
            {
                return cmbMain.SelectedText;
            }
        }

        /// <summary>
        /// Sets read only
        /// </summary>
        public bool ReadOnly
        {
            set
            {
                
                lbNot.AllowDrop = lbYes.AllowDrop = !value;
                btnToLeft.Enabled = btnToRight.Enabled = !value;
                cmbMain.Enabled = value;
            }
        }
        
        /// <summary>
        /// Gets or sets selected list of  JointPairs
        /// </summary>
        public IList<JointPair> SelectedList
        {
            get 
            {
                List<JointPair> list = new List<JointPair>();
                foreach (JointPair obj in lbYes.Items)
                    list.Add(obj);

                return list;
            }
            set 
            {
                lbYes.Items.Clear();
                if(value!=null)
                    lbYes.Items.AddRange(value.ToArray());

                _BackupedSelectedList = new List<JointPair>(value);
            }    
        }

        /// <summary>
        /// Gets or sets notselected list of  JointPairs
        /// </summary>
        public IList<JointPair> NotSelectedList
        {
            get 
            {
                List<JointPair> list = new List<JointPair>();
                foreach (JointPair obj in lbNot.Items)
                    list.Add(obj);

                return list;
            }
            set
            {
                lbNot.Items.Clear();
                if (value != null)
                    lbNot.Items.AddRange(value.ToArray());
            }
        }

        /// <summary>
        /// Gets archived selected list of  JointPairs
        /// </summary>
        public IList<JointPair> BackupedSelectedList
        {
            get
            {                
                return _BackupedSelectedList.ToList().AsReadOnly();
            }
        }

        /// <summary>
        /// Binds datasource to main element combobox
        /// </summary>
        /// <param name="valueMember"></param>
        /// <param name="selectedValue"></param>
        public void BindData(string valueMember, string displayMember)
        {
            if (_dataSource == null)
                return;

            cmbMain.DataSource = _dataSource;
            cmbMain.ValueMember = valueMember;
            cmbMain.DisplayMember = displayMember;
            
            return;
        }

        private void Joints_Resize(object sender, EventArgs e)
        {
            int totalWidth = gbSecond.Width;
            int totalHeight = gbSecond.Height;

            int btnWidth = btnToLeft.Width;
            int spaceWidth = 20;
            int spacing = 5;
            int listWidth = (totalWidth - spacing * 2 - spaceWidth * 2 - btnWidth) / 2;
            lbNot.Left = spacing;
            lbNot.Width = lbYes.Width = listWidth;

            btnToLeft.Left = btnToRight.Left = spacing + listWidth + spaceWidth;

            lblSelected.Left = lbYes.Left = spacing + listWidth + spaceWidth*2 + btnWidth;

            lbYes.Height = lbNot.Height = totalHeight - spacing - 38;
        }

        private void btnToRight_Click(object sender, EventArgs e)
        {
            foreach (JointPair obj in lbNot.SelectedItems)
            {
                lbYes.Items.Add(obj);                
            }
            foreach (JointPair obj in lbYes.Items)
            {
                lbNot.Items.Remove(obj);
            }
        }

        private void cmbMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedItemChanged != null)
                SelectedItemChanged(sender, e);
        }

        private void btnToLeft_Click(object sender, EventArgs e)
        {
            foreach (JointPair obj in lbYes.SelectedItems)
            {
                lbNot.Items.Add(obj);
            }
            foreach (JointPair obj in lbNot.Items)
            {
                lbYes.Items.Remove(obj);
            }
        }

        private void lbNot_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbNot.SelectedItem == null)
                return;

            _currentDrop = lbNot;
            lbNot.DoDragDrop(lbNot.SelectedItem as JointPair, DragDropEffects.Move);
        }

        private ListBox _currentDrop = null;

        private void lbYes_DragDrop(object sender, DragEventArgs e)
        {
            if ((sender as ListBox) == _currentDrop)
                return;
            JointPair item = e.Data.GetData(typeof(JointPair)) as JointPair; 
            lbYes.Items.Add(item);            
            lbNot.Items.Remove(item);

        }       

        private void lbYes_MouseDown(object sender, MouseEventArgs e)
        {
            if (lbYes.SelectedItem == null)
                return;
            _currentDrop = lbYes;
            lbNot.DoDragDrop(lbYes.SelectedItem as JointPair, DragDropEffects.Move);
        }

        private void lbNot_DragDrop(object sender, DragEventArgs e)
        {
            if ((sender as ListBox) == _currentDrop)
                return;
            JointPair item = e.Data.GetData(typeof(JointPair)) as JointPair;
            lbNot.Items.Add(item);
            lbYes.Items.Remove(item);
        }

        private void lbYes_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lbNot_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }    
        
    }
}
