using System;
using System.Data;
using System.Windows.Forms;


namespace ChangeMgmt
{
    public partial class Migration : Form
    {
        public Migration()
        {
            InitializeComponent();
        }

        private DB_con _con = new DB_con();

        private void btnUsers_Click(object sender, EventArgs e)
        {
            DataTable dtUsers = _con.Select("SELECT * FROM ddusers", "leonirus");
            foreach (DataRow dtUsersRow in dtUsers.Rows)
            {
                try
                {
                    enG_USERSTableAdapter.Insert(dtUsersRow["displayName"].ToString(),
                        dtUsersRow["sAMAccountName"].ToString(),
                        dtUsersRow["mail"].ToString(), false);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            DataTable dtProcess = _con.Select("SELECT * FROM ddprocess", "leonirus");
            foreach (DataRow dtProcessRow in dtProcess.Rows)
            {

                DateTime dedline = Convert.ToDateTime(dtProcessRow["implementdate"].ToString());
                DateTime datecreate = Convert.ToDateTime(dtProcessRow["date"].ToString());
                DateTime validtime;
                try
                {
                    validtime = Convert.ToDateTime(dtProcessRow["validtime"].ToString());
                }
                catch
                {
                    validtime = datecreate;
                }

                try
                {
                    eNG_PROCTableAdapter.INSERT_NEW_ROW_MIGR(null, dtProcessRow["leoniNumber"].ToString(),
                        PriorID(dtProcessRow), dedline, datecreate, userID(dtProcessRow), validtime,
                        dtProcessRow["descriptionFull"].ToString(), STATUS(dtProcessRow), 97, "ok", DateTime.Now, true,
                        (int) dtProcessRow["ID"]);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }



        private int STATUS(DataRow row)
        {
            int STATUS_NO = 1;

            DataTable dt = _con.Select(
                "SELECT\r\n\t`ddprocess`.`validate`,\r\n\t`dd_process_approv`.`status_approv_Y`,\r\n\t`dd_process_approv`.`status_approv_N` \r\nFROM\r\n\t`leonirus`.`ddprocess` `ddprocess` \r\n\t\tINNER JOIN `leonirus`.`dd_process_approv` `dd_process_approv` \r\n\t\tON `ddprocess`.`ID` = `dd_process_approv`.`id_ddprocess` \r\nWHERE\r\n\t(`ddprocess`.`ID` = " +
                (int) row["id"] + ")",
                "leonirus");
            if ((bool) dt.Rows[0]["validate"] && dt.Rows[0]["status_approv_Y"].ToString() == "1" &&
                dt.Rows[0]["status_approv_N"].ToString() == "0")
            {
                STATUS_NO = 3;
            }
            else if ((bool) dt.Rows[0]["validate"] && dt.Rows[0]["status_approv_Y"].ToString() == "0" &&
                     dt.Rows[0]["status_approv_N"].ToString() == "1")
            {
                STATUS_NO = 5;
            }
            else if ((!(bool) dt.Rows[0]["validate"] && dt.Rows[0]["status_approv_Y"].ToString() == "1" &&
                      dt.Rows[0]["status_approv_N"].ToString() == "0"))
            {
                STATUS_NO = 2;
            }
            else if ((!(bool) dt.Rows[0]["validate"] && dt.Rows[0]["status_approv_Y"].ToString() == "0" &&
                      dt.Rows[0]["status_approv_N"].ToString() == "1"))
            {
                STATUS_NO = 5;
            }

            return STATUS_NO;
        }

        private int userID(DataRow User)
        {
            int USER_NO = 2;
            try
            {
                USER_NO = (int) enG_USERSTableAdapter.GET_USER_NO(User["owner"].ToString());
            }
            catch
            {
                enG_USERSTableAdapter.Insert(User["owner"].ToString(), User["owner"].ToString(),
                    User["owner"].ToString(), false);
                USER_NO = (int) enG_USERSTableAdapter.GET_USER_NO(User["owner"].ToString());
            }

            //USER_NO = enG_USERSTableAdaptersele
            return USER_NO;
        }

        private int PriorID(DataRow Prior)
        {
            int PRIOR_NO = 1;
            string priors = "Низкий";
            if (Prior["description"].ToString() == "Low")
            {
                priors = "Низкий";
            }
            else if (Prior["description"].ToString() == "Medium")
            {
                priors = "Средний";
            }
            else if (Prior["description"].ToString() == "High")
            {
                priors = "Высокий";
            }


            PRIOR_NO = (int) eNG_PRIORTableAdapter.GET_PRIOIR_NO(priors);
            return PRIOR_NO;
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            DataTable dtProcess = _con.Select("SELECT * FROM ddchanges", "leonirus");
            foreach (DataRow dtProcessRow in dtProcess.Rows)
            {
                DateTime d = Convert.ToDateTime(dtProcessRow["Date"]);
                int user_no = 97;
                try
                {
                    user_no = (int) enG_USERSTableAdapter.GET_USER_NO_BY_LOGIN(dtProcessRow["Owner"].ToString());
                }
                catch
                {
                    user_no = 97;
                }

                bool status = (dtProcessRow["ChangeState"].ToString() == "0") ? false : true;
                enG_PROC_TASKSTableAdapter.INSERT_TASK_MIGR(Categor(dtProcessRow), d,
                    status, user_no, dtProcessRow["ChangeDescription"].ToString(),
                    (int) dtProcessRow["ProcessID"]);

            }

        }

        private void OtherTasks()
        {
            DataTable listtype =
                _con.Select(
                    "SELECT\r\n\tDISTINCT `ddchanges`.`ChangeType` \r\nFROM\r\n\t`leonirus`.`ddchanges` `ddchanges`",
                    "leonirus");
            foreach (DataRow r in listtype.Rows)
            {
                DataTable dd = _con.Select(
                    "SELECT\r\n\t* \r\nFROM\r\n\t`leonirus`.`ddprocess` `ddprocess` \r\n\t\tINNER JOIN `leonirus`.`dd_process_approv` `dd_process_approv` \r\n\t\tON `ddprocess`.`ID` = `dd_process_approv`.`id_ddprocess` \r\nWHERE\r\n\t(`ddprocess`.`validate` = 0) AND\r\n\t(`dd_process_approv`.`status_approv_Y` = 1) AND\r\n\t(`ddprocess`.`" +
                    r["ChangeType"] + "` <> (`ddprocess`.`" + r["ChangeType"] + "st`))", "leonirus");

                foreach (DataRow rr in dd.Rows)
                {
                    enG_PROC_TASKSTableAdapter.INSERT_TASK_MIGR(Categor(r), null,
                        false, null, null,
                        (int)rr[0]);
                }
               
            }

        }

        private void btnTasksOther_Click(object sender, EventArgs e)
        {
            OtherTasks();
        }


        private int Categor(DataRow row)
        {
            int cat = 1;
            if (row["ChangeType"].ToString() == "fors")
            {
                cat = 1;
            }
            else if (row["ChangeType"].ToString() == "preassembly")
            {
                cat = 5;
            }

            if (row["ChangeType"].ToString() == "cap")
            {
                cat = 2;
            }
            else if (row["ChangeType"].ToString() == "laycad")
            {
                cat = 4;
            }

            if (row["ChangeType"].ToString() == "assembly")
            {
                cat = 6;
            }
            else if (row["ChangeType"].ToString() == "testtable")
            {
                cat = 7;
            }

            return cat;
        }

    }
}
