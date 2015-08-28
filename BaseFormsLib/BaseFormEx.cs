using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseFormsLib
{
    public class BaseFormEx : BaseForm
    {
        private DataGridView _dgv;

        //property
        public DataGridView Dgv
        {            
            get
            {
                return _dgv;
            }
            set
            {
                _dgv = value;
            }
        }

        public string OpenNextCard(ref int rowIndex)
        {
            try
            {
                if (rowIndex > -1 && rowIndex < _dgv.RowCount - 1)
                    rowIndex++;
                else
                    rowIndex = 0;

                _dgv.ClearSelection();
                _dgv.Rows[rowIndex].Selected = true;
                return _dgv.Rows[rowIndex].Cells["Id"].Value.ToString();
            }
            catch (Exception)
            {                
                return string.Empty;                
            }
        }        
        public string OpenPrevCard(ref int rowIndex)
        {
            try
            {
                if (rowIndex > 0 && rowIndex < _dgv.RowCount)
                    rowIndex--;
                else
                    rowIndex = _dgv.RowCount - 1;

                _dgv.ClearSelection();
                _dgv.Rows[rowIndex].Selected = true;
                return _dgv.Rows[rowIndex].Cells["Id"].Value.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }  
    }
}
