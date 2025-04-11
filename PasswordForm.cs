using Sunisoft.IrisSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPower
{
    public partial class PasswordForm: Form
    {
        //private SkinEngine skinEngine1;

        public bool IsAuthorized { get; private set; } = false;
        public PasswordForm()
        {
            InitializeComponent();
            //this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            //this.skinEngine1.SkinFile = Application.StartupPath + "\\DeepCyan.ssk"; // 注意：这里的文件名需要与debug文件夹中的皮肤文件名一致
            InitializeEvents(); // 绑定按钮事件
        }

        #region 事件绑定
        private void InitializeEvents()
        {
            // 数字按钮事件绑定
            btn0.Click += new EventHandler(btnNumber_Click);
            btn1.Click += new EventHandler(btnNumber_Click);
            btn2.Click += new EventHandler(btnNumber_Click);
            btn3.Click += new EventHandler(btnNumber_Click);
            btn4.Click += new EventHandler(btnNumber_Click);
            btn5.Click += new EventHandler(btnNumber_Click);
            btn6.Click += new EventHandler(btnNumber_Click);
            btn7.Click += new EventHandler(btnNumber_Click);
            btn8.Click += new EventHandler(btnNumber_Click);
            btn9.Click += new EventHandler(btnNumber_Click);

            // 删除按钮事件
            btnDelete.Click += new EventHandler(btnDelete_Click);

            // 确认按钮事件
            btnConfirm.Click += new EventHandler(btnConfirm_Click);
        }
        #endregion

        #region 事件处理
        // 点击数字按钮（0-9）
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && txtPassword.Text.Length < 6)
            {
                txtPassword.Text += btn.Text; // 追加数字
            }
        } 
        #endregion

        #region 事件处理
        // 点击“确认”按钮
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "000000")
            {
                IsAuthorized = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误！");
                txtPassword.Text = ""; // 清空输入
            }
        }
      
    

// 点击“删除”按钮
private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length > 0)
            {
                txtPassword.Text = txtPassword.Text.Substring(0, txtPassword.Text.Length - 1); // 删除最后一个字符
            }
        }


        #endregion
    }
}

