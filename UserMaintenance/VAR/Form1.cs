using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VAR.entities;

namespace VAR
{
    public partial class Form1 : Form
    {
        PortfolioEntities context = new PortfolioEntities();
        List<Tick> Ticks;
        List<portfolioitem> Portfolio = new List<portfolioitem>();
        CreatePortfolio();
        public Form1()
        {
            InitializeComponent();
            Ticks = context.Tick.ToList();
            dataGridView1.DataSource = Ticks;
        }
        private void CreatePortfolio()
        {
            Portfolio.Add(new portfolioitem() { Index = "OTP", Volume = 10 });
            Portfolio.Add(new portfolioitem() { Index = "ZWACK", Volume = 10 });
            Portfolio.Add(new portfolioitem() { Index = "ELMU", Volume = 10 });

            dataGridView2.DataSource = Portfolio;
        }
    }
}
