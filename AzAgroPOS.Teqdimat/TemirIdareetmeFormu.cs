using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class TemirIdareetmeFormu : Form
    {
        private readonly TemirPresenter _presenter;
        public TemirIdareetmeFormu(TemirManager temirManager, MusteriManager musteriManager, IstifadeciManager istifadeciManager)
        {
            InitializeComponent();
            //_presenter = new TemirPresenter(this, temirManager, musteriManager, istifadeciManager);
        }
    }
}
