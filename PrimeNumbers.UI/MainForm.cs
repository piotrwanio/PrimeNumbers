using AutoMapper;
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
    //TODO: Add saving state for previous cycles (maybe in cycleservice)? DONE+-
    //TODO: maybe showing detailed info in separate tab? DONE+-
    //TODO: Stopping cycle DONE
    //TODO: Add missing informations to CycleInfo about how much time it takes to finish cycle etc. DONE+-
    //TODO: FIX BIG PRIMES
    //TODO: change ints to longs or ulongs?
    //TODO: Add handling out of memory and overflow exceptions and info about maximum number handled by long numbers
    //TODO: info about not finding bigger number in next cycle
    //TODO: Add logging
    //TODO: maybe xmldocument instead of xmlserializer
    //TODO: Maybe reporting service?
    //TODO: Automapper profile utilize

    public partial class MainForm : Form
    {
        private readonly ICycleService _cycleService;
        private readonly IXmlWriter _xmlWriter;
        private readonly IMapper _mapper;
        long elpsd = -DateTime.Now.Ticks;
        long startCycleTime = -DateTime.Now.Ticks;
        int cycleId = 1;
        int cycleTimeInSec = 10;
        int breakTimeInSec = 10;

        private readonly IList<BasicCycleInfo> _allCycles = new List<BasicCycleInfo>();
        PrimeGenerationState generatingState = new PrimeGenerationState()
        {
            X = 1,
            Y = 1,
            Limit = 1000000
        };

        int x = 1, y = 1, r = 5;
        IList<int> listOfPrimes = new List<int>() { 1 };
        private int limit = 100000000;
        private CycleInfo lastCycleResult = new CycleInfo();



        public MainForm(ICycleService cycleService, IXmlWriter xmlWriter, IMapper mapper)
        {
            InitializeComponent();

            //runGeneralTimerAsync();
            timer1.Interval = 1000;
            timer1.Start();

            timer2.Interval = 1000;


            _cycleService = cycleService;
            _xmlWriter = xmlWriter;
            _mapper = mapper;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void exportAsXmlButton_Click(object sender, EventArgs e)
        {
            _xmlWriter.Serialize(_allCycles);
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
            this.wholeTimeTextBox.Text = cycleTime.ToString(@"hh\:mm\:ss");
        }

        private void wholeTimeLabel_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (TimeSpan.FromTicks(startCycleTime + DateTime.Now.Ticks) > TimeSpan.FromSeconds(cycleTimeInSec))
            {
                _cycleService.StopCycle();
            }
            var cycleTime = TimeSpan.FromTicks(startCycleTime + DateTime.Now.Ticks);
            this.cycleTimeTextBox.Text = cycleTime.ToString(@"hh\:mm\:ss");
        }

        private void stopCycleButton_Click(object sender, EventArgs e)
        {
            _cycleService.StopCycle();
        }

        private void allCyclesReportTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        async Task RunCycles()
        {

            var cycleTime = 5;
            var breakTime = 1;

            timer2.Start();

            await Task.Run(async () =>
               {
                   startCycleTime = -DateTime.Now.Ticks;
                   lastCycleResult = await _cycleService.StartCycle(cycleTime, breakTime, generatingState);
                   lastCycleResult.CycleExecutionTime = TimeSpan.FromTicks(startCycleTime + DateTime.Now.Ticks);
                   lastCycleResult.PrimeComputeTime = TimeSpan.FromTicks(elpsd + DateTime.Now.Ticks);
                   lastCycleResult.CycleId = cycleId;
                   cycleId++;
               });

            generatingState = lastCycleResult.State;


            timer2.Stop();

            var shortCycleResult = _mapper.Map<BasicCycleInfo>(lastCycleResult);
            _allCycles.Add(shortCycleResult);
            AddRowToPanel(this.allCyclesReportTable, new string[] { shortCycleResult.CycleId.ToString(), shortCycleResult.ComputedBiggestPrime.ToString(), shortCycleResult.PrimeComputeTime.ToString(), shortCycleResult.CycleExecutionTime.ToString() });

            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (var prime in lastCycleResult.Primes.OrderBy(p => p).Take(100))
            {
                ListViewItem item = new ListViewItem();
                item.Text = prime.ToString();
                listView1.Items.Add(item);
            }
            elpsd += DateTime.Now.Ticks;
            listView1.Items.Add(elpsd.ToString());
            listView1.EndUpdate();

        }

        private void AddRowToPanel(TableLayoutPanel panel, string[] rowElements)
        {
            if (panel.ColumnCount != rowElements.Length)
                throw new Exception("Elements number doesn't match!");
            //get a reference to the previous existent row
            RowStyle temp = panel.RowStyles[panel.RowCount - 1];
            //increase panel rows count by one
            panel.RowCount++;
            //add a new RowStyle as a copy of the previous one
            panel.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            //add the control
            for (int i = 0; i < rowElements.Length; i++)
            {
                panel.Controls.Add(new Label() { Text = rowElements[i] }, i, panel.RowCount - 1);
            }
        }
    }
}
