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
using Serilog;

namespace PrimeNumbers.UI
{
    public partial class MainForm : Form
    {
        private readonly ICycleService _cycleService;
        private readonly IXmlWriter _xmlWriter;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        private long _startCycleTime = -DateTime.Now.Ticks;
        private long _startBreakTime = -DateTime.Now.Ticks;
        private bool _cyclesStarted = false;
        private int _cycleId = 1;
        private readonly int _cycleTimeInSec = 300;
        private readonly int _breakTimeInSec = 60;
        private TimeSpan _wholeTime = new TimeSpan();
        private readonly IList<BasicCycleInfo> _allCycles = new List<BasicCycleInfo>();
        private PrimeGenerationState _generatingState = new PrimeGenerationState()
        {
            X = 1,
            Y = 1,
            Limit = 1000000
        };
        private CycleInfo _lastCycleResult = new CycleInfo();


        public MainForm(ICycleService cycleService, IXmlWriter xmlWriter, IMapper mapper, ILogger logger)
        {
            InitializeComponent();

            generalTimer.Interval = 1000;
            cycleTimer.Interval = 1000;
            breakTimer.Interval = 1000;

            _cycleService = cycleService;
            _xmlWriter = xmlWriter;
            _mapper = mapper;
            _logger = logger;
        }

        private void exportAsXmlButton_Click(object sender, EventArgs e)
        {
            _xmlWriter.Serialize(_allCycles);
        }

        private async void startCyclesButton_Click(object sender, EventArgs e)
        {
            _cyclesStarted = true;
            while (_cyclesStarted)
            {
                await RunCycles();
            }
        }

        private void generalTimer_Tick(object sender, EventArgs e)
        {
            _wholeTime += TimeSpan.FromMilliseconds(1000);
            this.wholeTimeTextBox.Text = _wholeTime.ToString(@"hh\:mm\:ss");
        }

        private void cycleTimer_Tick(object sender, EventArgs e)
        {
            if (TimeSpan.FromTicks(_startCycleTime + DateTime.Now.Ticks) > TimeSpan.FromSeconds(_cycleTimeInSec))
            {
                _cycleService.StopCycle();
            }
            var cycleTime = TimeSpan.FromTicks(_startCycleTime + DateTime.Now.Ticks);
            this.cycleTimeTextBox.Text = cycleTime.ToString(@"hh\:mm\:ss");
        }

        private void stopCycleButton_Click(object sender, EventArgs e)
        {
            _cycleService.StopCycle();
            _cyclesStarted = false;
            generalTimer.Stop();
            cycleTimer.Stop();
            breakTimer.Stop();
        }

        private void breakTimer_Tick(object sender, EventArgs e)
        {
            if (TimeSpan.FromTicks(_startBreakTime + DateTime.Now.Ticks) > TimeSpan.FromSeconds(_breakTimeInSec))
            {
                _cyclesStarted = true;
                RunCycles();
            }
            var breakTime = TimeSpan.FromTicks(_startBreakTime + DateTime.Now.Ticks);
            this.breakTimeTextBox.Text = breakTime.ToString(@"hh\:mm\:ss");
        }

        async Task RunCycles()
        {

            var cycleTime = 5;
            var breakTime = 1;

            cycleNumberTextBox.Text = _cycleId.ToString();

            breakTimer.Stop();
            cycleTimer.Start();
            generalTimer.Start();

            try
            {
                await Task.Run(async () =>
                   {
                       _startCycleTime = -DateTime.Now.Ticks;
                       _lastCycleResult = await _cycleService.StartCycle(cycleTime, breakTime, _generatingState);

                       _lastCycleResult.CycleExecutionTime = TimeSpan.FromTicks(_startCycleTime + DateTime.Now.Ticks);
                       cycleTimer.Stop();
                       generalTimer.Stop();
                       _cyclesStarted = false;

                       _startBreakTime = -DateTime.Now.Ticks;
                       _lastCycleResult.PrimeComputeTime = _wholeTime;
                       _lastCycleResult.CycleId = _cycleId;
                       _cycleId++;
                   });
            }
            catch (OutOfMemoryException exception)
            {
                _logger.Error("Error occured, it was probably caused by long type memory limit.");
                _logger.Error(exception.ToString());

                var notifyForm = new NotificationForm();
                notifyForm.message.Text =
                    "Error occured, it was probably caused by long type memory limit.";
                notifyForm.Show();
            }
            catch (Exception e)
            {
                _logger.Error(e.ToString());
            }

            _generatingState = _lastCycleResult.State;
            breakTimer.Start();

            var shortCycleResult = _mapper.Map<BasicCycleInfo>(_lastCycleResult);
            _allCycles.Add(shortCycleResult);
            AddRowToPanel(this.allCyclesReportTable, new string[] { shortCycleResult.CycleId.ToString(), shortCycleResult.ComputedBiggestPrime.ToString(), shortCycleResult.PrimeComputeTime.ToString(@"hh\:mm\:ss"), shortCycleResult.CycleExecutionTime.ToString(@"hh\:mm\:ss") });

            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach (var prime in _lastCycleResult.Primes.OrderBy(p => p).Take(100))
            {
                ListViewItem item = new ListViewItem();
                item.Text = prime.ToString();
                listView1.Items.Add(item);
            }
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
