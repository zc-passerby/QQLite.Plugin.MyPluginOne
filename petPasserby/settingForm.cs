using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace petPasserby
{
    public partial class settingForm : Form
    {
        public petPasserbyPlugin Plugin { get; set; }
        public settingForm(petPasserbyPlugin plugin)
        {
            InitializeComponent();
            this.Icon = QQLite.Framework.License.SoftIcon;
            this.Plugin = plugin;
        }
    }
}
