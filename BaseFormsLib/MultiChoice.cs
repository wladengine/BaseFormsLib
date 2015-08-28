using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseFormsLib
{
    public partial class MultiChoice : Form
    {
        MultiSelectCombo _owner;
        IList<string> _lstSelected;

        //конструктор
        public MultiChoice(MultiSelectCombo owner, List<KeyValuePair<string, string>> lstSource, IList<string> lstSelected)
        {
            InitializeComponent();

            _owner = owner;
            _lstSelected = lstSelected;

            if (lstSource == null || lstSource.Count == 0)
                return;

            clbItems.DataSource = new BindingSource(lstSource, null);
            clbItems.ValueMember = "Key";
            clbItems.DisplayMember = "Value";

            for (int i = 0; i < clbItems.Items.Count; i++)
            {
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)clbItems.Items[i];
                if (_lstSelected.Contains(item.Key))
                    clbItems.SetItemChecked(i, true);
            }

            clbItems.Focus();
        }

        //выделить все
        private void btnSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.clbItems.Items.Count; i++)
                this.clbItems.SetItemChecked(i, true);
        }

        //снять выделение всего
        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.clbItems.Items.Count; i++)
                this.clbItems.SetItemChecked(i, false);
        }

        //закрытие по отмене
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //готово
        private void btnOk_Click(object sender, EventArgs e)
        {
            _owner.SelectedIds = GetSelectedList();            
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

            
            
        //    if (this.clbItems.CheckedItems.Count == 0)
        //        return;
        //    else if (this.clbItems.CheckedItems.Count == 1)
        //    {
        //        cbe.SelectedItem = this.clbItems.Items[clbItems.CheckedIndices[0]].ToString();
        //    }
        //    else
        //    {
        //        List<string> list = new List<string>();
                
        //        foreach (int i in this.clbItems.CheckedIndices)
        //        {
        //            list.Add(clbItems.Items[i].ToString());
        //        }
                
        //        cbe.FillWithSelected(list);
        //    }
            
        //    this.Close();
        //}
    }
}