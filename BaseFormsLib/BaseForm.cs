using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BaseFormsLib
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        //фокус на форму по клику на любой контрол
        protected virtual void InitFocusHandlers()
        {
            foreach (Control control in this.Controls)
                if (!(control is Button) && !(control is ComboBox))
                    control.Click += new EventHandler(FocusForm);
            this.Click += new EventHandler(FocusForm);
        }

        //колбаска
        protected void FocusForm(object obj, EventArgs ea)
        {
            this.Focus();
        }
    }
}
