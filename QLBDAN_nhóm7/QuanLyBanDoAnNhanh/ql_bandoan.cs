using QuanLyBanDoAnNhanh.DAO;
using QuanLyBanDoAnNhanh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thucdon = QuanLyBanDoAnNhanh.DTO.Thucdon;

namespace QuanLyBanDoAnNhanh
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class ql_bandoan : MetroFramework.Forms.MetroForm
    {

        private Taikhoan loginAccount;

        public Taikhoan LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }
        public ql_bandoan(Taikhoan acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadTable();
            LoadCategory();
           // LoadComboboxTable(cbSwitchTable);
        }

        #region Method
        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }
        void LoadCategory()
        {
            List<Loai> listCategory = Danhmuc_DAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";

        }
       public void LoadFoodListByCategoryID( int id)
        {
            List<Doan> listFood = Doan_DAO.Instance.GetFoodByCategoryID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "Name";

        }
        void LoadCategoryIntoTextbox(ComboBox cb)
        {
            cb.DataSource = Danhmuc_DAO.Instance.GetListCategory();

        }
        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Ban> tableList = Ban_DAO.Instance.LoadTableList();
            foreach (Ban item in tableList)
            {
                Button btn = new Button(){ Width = Ban_DAO.TableWidth, Height = Ban_DAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine+ item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                
                switch (item.Status)
                {
                    case "":
                        btn.BackColor = Color.Bisque;
                        break;
                    default:
                        btn.BackColor = Color.LightGreen;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }
       
        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<Thucdon> listBillInfo = Thucdon_DAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (Thucdon item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;

                lsvBill.Items.Add(lsvItem); 
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;

            txbTotalPrice.Text = totalPrice.ToString("c",culture);
        }
        #endregion
        #region Events
        
        void btn_Click (object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Ban).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ql_thongtintaikhoan f = new ql_thongtintaikhoan (LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }
        void f_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
            f.ShowDialog();
            f.Close();
            this.LoadTable();
            this.LoadCategoryIntoTextbox(cbCategory);

        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Loai selected = cb.SelectedItem as Loai;
            id = selected.ID;
            LoadFoodListByCategoryID(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Ban table = lsvBill.Tag as Ban;
            if(table == null)
            {
                MessageBox.Show("Hãy chọn bàn!");
                return;
            }
            int idBill = Hoadon_DAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbFood.SelectedItem as Doan).ID;
            int count = (int)nmFoodCount.Value;
            if(idBill == -1)
            {
                Hoadon_DAO.Instance.InsertBill(table.ID);
                TTHoadon_DAO.Instance.InsertBillInfo(Hoadon_DAO.Instance.GetMaxIDBill(), foodID, count);
            }
            else
            {
                TTHoadon_DAO.Instance.InsertBillInfo(idBill, foodID, count);

            }
            ShowBill(table.ID);
            LoadTable();

        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Ban table = lsvBill.Tag as Ban;

            int idBill = Hoadon_DAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)nmDiscount.Value;
            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
            if(idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn đang thanh toán hóa đơn cho bàn {0}\n Tổng tiền - (Tổng tiền /100) * Giảm giá \n=> {1} - ({1}/100 * {2}) = {3} "
                    ,table.Name,totalPrice,discount, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    Hoadon_DAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                    ShowBill(table.ID);
                    LoadTable();
                }
            }
        }



        #endregion

        private void tbxhoadon_Click(object sender, EventArgs e)
        {
                hoadon f = new hoadon();
                this.Hide();
                f.ShowDialog();
                this.Show();
            
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
