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
    public partial class MultySelectList : UserControl
    {
        private IDictionary<string, string> _dctSource;
        private IList<string> _lstSelected;
        
        public MultySelectList()
        {
            InitializeComponent();            
        }

        public void InitSource(IDictionary<string, string> source)
        {
            _dctSource = source;
            _lstSelected = new List<string>();  
        }       

        public void UpdateLbValues()
        {
            if (_lstSelected == null || _lstSelected.Count == 0)            
                lbSelectedValues.DataSource = new BindingSource(null, null);               
            
            else
            {
                Dictionary<string, string> dict = _dctSource.Where(kvp => _lstSelected.Contains(kvp.Key)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                lbSelectedValues.DataSource = new BindingSource(dict, null);
                lbSelectedValues.ValueMember = "Key";
                lbSelectedValues.DisplayMember = "Value";
            }   
        }

        public string GetSelectedRowId 
        {
            get { return ((KeyValuePair<string, string>)lbSelectedValues.SelectedItem).Key; }
        }

        public IList<string> SelectedList
        {
            get { return _lstSelected;}
            set 
            { 
                _lstSelected = value;
                UpdateLbValues();
            }
        } 

        private void btnSelectValue_Click(object sender, EventArgs e)
        {            
            new ListValues(this, _dctSource, _lstSelected).ShowDialog();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            _lstSelected = _dctSource.Select(x => x.Key).ToList();
            UpdateLbValues();
        }

        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            _lstSelected.Clear();
            UpdateLbValues();
        }
    }
}
