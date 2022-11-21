using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ChangeMgmt.Common;
using ChangeMgmt.Modules;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraNavBar;

namespace ChangeMgmt
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        private readonly string[] _arguments;
        private readonly List<string> _id = new List<string>();
        private readonly List<string> _subId = new List<string>();
        public Main(string[] arg)
        {
            InitializeComponent();
            _arguments = arg;
        }

        private void Main_Load(object sender, EventArgs e)
        {

            DbInfo info = new DbInfo();
            if (!info.TestConnection())
            {
                FrmDbSettings dbSet = new FrmDbSettings {Info = info};

                if (dbSet.ShowDialog() != DialogResult.OK)
                {
                    Close();
                }
            }

            CheckRights(Environment.UserName);
            AlerNotofocation();
           
        }

        private void AlerNotofocation()
        {
            try
            {
                if (Entry.CategoryList.Contains("10"))
                {
                    timerAlert.Start();
                }
                else
                {
                    timerAlert.Stop();
                }
            }
            catch
            {
                //ignore
            }
        }

        private void CheckRights(string login)
        {
         Rights start = new Rights(login);
         Statuses stat = new Statuses();
            if (Entry.Block == 1)
            {
                MessageBox.Show(@"Пользователь заблокирован в программе");
                Close();
            }
            else if (Entry.UserName == "")
            {
                MessageBox.Show(@"Пользователь не добавлен");
                Close();
            }

            ApplyRights();
            Text = @"DayX Управление изменениями |" + Entry.UserName.TrimEnd(' ')+@"|";
        }
        private void ApplyRights()
        {
            foreach (NavBarGroup componenets in navBarControl1.Groups)
            {
                if (rOLLE_ACCESSTableAdapter.ScalarEnableComponent(Entry.UserId, componenets.Caption) != null)
                {
                    componenets.Visible = (bool)rOLLE_ACCESSTableAdapter.ScalarEnableComponent(Entry.UserId, componenets.Caption);
                }
            }

            foreach (NavBarItem item in navBarControl1.Items)
            {
                if (rOLLE_ACCESSTableAdapter.ScalarEnableComponent(Entry.UserId, item.Caption) != null)
                {
                    item.Visible = (bool)rOLLE_ACCESSTableAdapter.ScalarEnableComponent(Entry.UserId, item.Caption);
                }
            }
            if (_arguments.Length > 0)
            {

            }
        }
        private void navBarControl1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            navigationFrame1.SelectedPage = (NavigationPage)navigationFrame1.Pages.FindFirst(x => (string)x.Tag == e.Link.Caption);
        }
        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel1.Controls.Contains(Users.Instance))
            {

                panel1.Controls.Add(Users.Instance);
                Users.Instance.Dock = DockStyle.Fill;
                Users.Instance.BringToFront();
            }
            else
            {
                Users.Instance.BringToFront();
            }
        }
        internal void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel2.Controls.Contains(Status.Instance))
            {

                panel2.Controls.Add(Status.Instance);
                Status.Instance.Dock = DockStyle.Fill;
                Status.Instance.BringToFront();
            }
            else
            {
                Status.Instance.BringToFront();
            }
        }
        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel3.Controls.Contains(Family.Instance))
            {

                panel3.Controls.Add(Family.Instance);
                Family.Instance.Dock = DockStyle.Fill;
                Family.Instance.BringToFront();
            }
            else
            {
                Family.Instance.BringToFront();
            }
        }
        private void navBarItem11_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel4.Controls.Contains(Project.Instance))
            {

                panel4.Controls.Add(Project.Instance);
                Project.Instance.Dock = DockStyle.Fill;
                Project.Instance.BringToFront();
            }
            else
            {
                Project.Instance.BringToFront();
            }
        }
        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel5.Controls.Contains(Priority.Instance))
            {

                panel5.Controls.Add(Priority.Instance);
                Priority.Instance.Dock = DockStyle.Fill;
                Priority.Instance.BringToFront();
            }
            else
            {
                Priority.Instance.BringToFront();
            }
        }
        private void navBarItem8_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel6.Controls.Contains(HarnsMain.Instance))
            {

                panel6.Controls.Add(HarnsMain.Instance);
                HarnsMain.Instance.Dock = DockStyle.Fill;
                HarnsMain.Instance.BringToFront();
            }
            else
            {
                HarnsMain.Instance.BringToFront();
            }
        }
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel7.Controls.Contains(SinglRequest.Instance))
            {

                panel7.Controls.Add(SinglRequest.Instance);
                SinglRequest.Instance.Dock = DockStyle.Fill;
                SinglRequest.Instance.BringToFront();
            }
            else
            {
                SinglRequest.Instance.BringToFront();
            }
        }
        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel8.Controls.Contains(MultyRequest.Instance))
            {

                panel8.Controls.Add(MultyRequest.Instance);
                MultyRequest.Instance.Dock = DockStyle.Fill;
                MultyRequest.Instance.BringToFront();
            }
            else
            {
                MultyRequest.Instance.BringToFront();
            }
        }
        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel9.Controls.Contains(ApprovalList.Instance))
            {

                panel9.Controls.Add(ApprovalList.Instance);
                ApprovalList.Instance.Dock = DockStyle.Fill;
                ApprovalList.Instance.BringToFront();
            }
            else
            {
                ApprovalList.Instance.BringToFront();
            }
        }
        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel10.Controls.Contains(MyTasks.Instance))
            {

                panel10.Controls.Add(MyTasks.Instance);
                MyTasks.Instance.Dock = DockStyle.Fill;
                MyTasks.Instance.BringToFront();
            }
            else
            {
                MyTasks.Instance.BringToFront();
            }
            
        }
        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel11.Controls.Contains(AllTasks.Instance))
            {

                panel11.Controls.Add(AllTasks.Instance);
                AllTasks.Instance.Dock = DockStyle.Fill;
                AllTasks.Instance.BringToFront();
            }
            else
            {
                AllTasks.Instance.BringToFront();
            }
        }
        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel12.Controls.Contains(HistoryTask.Instance))
            {

                panel12.Controls.Add(HistoryTask.Instance);
                HistoryTask.Instance.Dock = DockStyle.Fill;
                HistoryTask.Instance.BringToFront();
            }
            else
            {
                HistoryTask.Instance.BringToFront();
            }
        }
        private void navBarItem13_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!panel13.Controls.Contains(AccessRoles.Instance))
            {

                panel13.Controls.Add(AccessRoles.Instance);
                AccessRoles.Instance.Dock = DockStyle.Fill;
                AccessRoles.Instance.BringToFront();
            }
            else
            {
                AccessRoles.Instance.BringToFront();
            }
        }

        private void timerAlert_Tick(object sender, EventArgs e)
        {
            Alert notif = new Alert();
            foreach (DataRow row in notif.AlertTable.Rows)
            {
                if (row[1].ToString() == "" && !_id.Contains(row[0].ToString()))
                {
                    string msg = "LEONI номер: " + row[2] + "\r\n" + "Приоритет: " + row[3] + "\r\n" + "Описание: " + row[4];
                    alertControl1.Show(this, @"Заявка на одобрение", msg, imageCollection1.Images[0]);
                    _id.Add(row[0].ToString());
                }

                if (row[1].ToString() != "" && !_subId.Contains(row[1]))
                {
                    string msg = "Группа №: " + row[1] + "\r\n" + "Приоритет: " + row[3] + "\r\n" + "Описание: " + row[4];
                    alertControl1.Show(this, @"Заявка на одобрение", msg, imageCollection1.Images[0]);
                    _subId.Add(row[1].ToString());
                }



            }
        }
        public class NotifierData
        {
            public bool IsWarning { get; set; }
        }
        private void alertControl1_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.AlertForm.OpacityLevel = 1;
        }

        private void alertControl1_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {

            
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Maximized;
            }
            navigationFrame1.SelectedPage = (NavigationPage)navigationFrame1.Pages.FindFirst(x => (string)x.Tag == "Статус утверждения");

            if (!panel9.Controls.Contains(ApprovalList.Instance))
            {

                panel9.Controls.Add(ApprovalList.Instance);
                ApprovalList.Instance.Dock = DockStyle.Fill;
                ApprovalList.Instance.BringToFront();
            }
            else
            {
                ApprovalList.Instance.BringToFront();
            }
        }

        private void navBarItem14_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (!panel14.Controls.Contains(Statistics.Instance))
            {

                panel14.Controls.Add(Statistics.Instance);
                Statistics.Instance.Dock = DockStyle.Fill;
                Statistics.Instance.BringToFront();
            }
            else
            {
                Statistics.Instance.BringToFront();
            }
        }
    }
}
