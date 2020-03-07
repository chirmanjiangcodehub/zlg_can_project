using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace LevitationHostCanbus
{
    public class ChartSetting
    {
        private double ymax;
        private double ymin;

        private double time_len;

        private string chart_name;
        private string area_name;

        public int ChartInd;

        public HitTestResult hitTestResult = new HitTestResult();

        public ChartSetting()
        {
            ymax = 0.0;
            ymin = 0.0;
            time_len = 120;
            ChartInd = 0;
        }

        public double YMax
        {
            get {return ymax;}
            set {ymax = value;}
        }

        public double YMin
        {
            get { return ymin; }
            set { ymin = value; }
        }

        public double TimeLength
        {
            get { return time_len; }
            set { time_len = value; }
        }

        public string ChartName
        {
            set { chart_name = value; }
            get { return chart_name; }
        }

        public string ChartAreaName
        {
            get { return area_name; }
            set { area_name = value; }
        }
    }
}
