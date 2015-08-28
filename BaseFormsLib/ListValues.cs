using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaseFormsLib
{
    public partial class ListValues : Form
    {
        MultySelectList _owner;
        IList<string> _lstSelected;

        public ListValues(MultySelectList owner, IDictionary<string, string> dctSource, IList<string> lstSelected)
        {
            InitializeComponent();

            _owner = owner;
            _lstSelected = lstSelected;

            if (dctSource == null || dctSource.Count == 0)
                return;

            chbValues.DataSource = new BindingSource(dctSource, null);            
            chbValues.ValueMember = "Key";
            chbValues.DisplayMember = "Value";
                        
            for (int i = 0; i < chbValues.Items.Count; i++)
            {
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)chbValues.Items[i];
                if(_lstSelected.Contains(item.Key))
                    chbValues.SetItemChecked(i, true);
            }           

            chbValues.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _owner.SelectedList = GetSelectedList();            
            this.Close();
        }

        private IList<string> GetSelectedList()
        {
            List<string> lst = new List<string>();
            foreach (KeyValuePair<string, string> item in chbValues.CheckedItems)
            {
                lst.Add(item.Key);
            }

            return lst;           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            Object[] vars = new object[chbValues.Items.Count];
            chbValues.Items.CopyTo(vars, 0);
            for (int index = 0; index < chbValues.Items.Count; index++)
                chbValues.SetItemChecked(index, true);

            chbValues.Refresh();
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < chbValues.Items.Count; index++)
                chbValues.SetItemChecked(index, false);
            chbValues.Refresh();
        }
    }
}
