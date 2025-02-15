using FinansalCrm.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FinansalCrm
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        FinansalCrmDbEntities db = new FinansalCrmDbEntities();
        int count = 0;
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString() + "TL";

            var lastbankProcess = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Amount).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastbankProcess.ToString() + "TL";


            // chart1 kodları

            var bankData = db.Banks.Select(x => new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();

            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach (var item in bankData)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }

            // chart2 kodları

            var biilData = db.Bills.Select(x => new
            {
                x.BiilTitle,
                x.BillAmount
            });
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            foreach (var item in biilData)
            {
                series2.Points.AddXY(item.BiilTitle, item.BillAmount);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if (count % 4 == 1)
            {
                var elektrikfaturası = db.Bills.Where(x=>x.BiilTitle == "Elektrik Faturası").Select(y=>y.BillAmount).FirstOrDefault();
                lblBilTitle.Text = "Elektrik Faturası";
                lblbillAmount.Text = elektrikfaturası.ToString() + "TL";


            }

            if (count % 4 == 2)
            {
                var dogalgazfaturası = db.Bills.Where(x => x.BiilTitle == "Dogalgaz Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBilTitle.Text = "Dogalgaz Faturası";
                lblbillAmount.Text = dogalgazfaturası.ToString() + "TL";


            }

            if (count % 4 == 3)
            {
                var sufaturası = db.Bills.Where(x => x.BiilTitle == "Su Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBilTitle.Text = "Su Faturası";
                lblbillAmount.Text = sufaturası.ToString() + "TL";


            }

            if (count % 4 == 0)
            {
                var internetfat = db.Bills.Where(x => x.BiilTitle == "İnternet Faturası").Select(y => y.BillAmount).FirstOrDefault();
                lblBilTitle.Text = "İnternet Faturası";
                lblbillAmount.Text = internetfat.ToString() + "TL";


            }
        }
    }
}
