using PrimeNumbers.BLL;
using PrimeNumbers.BLL.Services.Implementations;
using PrimeNumbers.BLL.Services.Interfaces;
using PrimeNumbers.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimeNumbers.UI
{
    //TODO: Add saving state for previous cycles
    //TODO: maybe showing detailed info in separate tab?
    //TODO: change ints to longs or ulongs?
    //TODO: Add handling out of memory and overflow exceptions and info about maximum number handled by long numbers

    public partial class MainForm : Form
    {
        private readonly ICycleService _cycleService;
        private readonly IXmlWriter _xmlWriter;
        long  elpsd = -DateTime.Now.Ticks;


        int x = 1, y = 1, r = 5;
        IList<int> listOfPrimes = new List<int>() { 1 };
        private int limit = 100000000;
        private CycleInfo lastCycleResult = new CycleInfo();

        public MainForm()
        {
        }

        public MainForm(ICycleService cycleService, IXmlWriter xmlWriter)
        {
            InitializeComponent();

            //runGeneralTimerAsync();
            timer1.Interval = 1000;
            timer1.Start();

            _cycleService = cycleService;
            _xmlWriter = xmlWriter;
        }

        private async Task RunGeneralTimerAsync()
        {
            var elpsd = -DateTime.Now.Ticks;
            var cycleTime = TimeSpan.FromTicks(elpsd + DateTime.Now.Ticks);
            while (true)
            {
                await Task.Run(() =>
                {
                    cycleTime = TimeSpan.FromTicks(elpsd + DateTime.Now.Ticks);
                });
                if(cycleTime > TimeSpan.FromSeconds(10))
                    this.cycleTimeTextBox.Text = cycleTime.ToString();
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void exportAsXmlButton_Click(object sender, EventArgs e)
        {
            _xmlWriter.Serialize(lastCycleResult);
        }

        private async void startCyclesButton_Click(object sender, EventArgs e)
        {
            await RunCycles();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cycleTimeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var cycleTime = TimeSpan.FromTicks(elpsd + DateTime.Now.Ticks);
            this.cycleTimeTextBox.Text = cycleTime.ToString(@"hh\:mm\:ss");
        }

        private async Task DoStuffAsync()
        {
            await Task.Run(async () =>
           {
               await RunCycles();
           });
        }

        async Task RunCycles()
        {
            var cycleTime = 5;
            var breakTime = 1;
            var elpsd = -DateTime.Now.Ticks;
            var generatingState = new PrimeGenerationState()
            {
                X = 1,
                Y = 1,
                Limit = 1000000
            };

            CycleInfo cycleResult = new CycleInfo();

            //var lastCycleInfo;
            await Task.Run(async () =>
               {
                   lastCycleResult = cycleResult = await _cycleService.StartCycle(cycleTime, breakTime, generatingState);
               });
            generatingState = cycleResult.State;

            listView1.BeginUpdate();
            foreach (var prime in cycleResult.Primes.OrderBy(p => p).Take(100))
            {
                ListViewItem item = new ListViewItem();
                item.Text = prime.ToString();
                listView1.Items.Add(item);
            }
            elpsd += DateTime.Now.Ticks;
            listView1.Items.Add(elpsd.ToString());
            listView1.EndUpdate();

        }
    }
}
