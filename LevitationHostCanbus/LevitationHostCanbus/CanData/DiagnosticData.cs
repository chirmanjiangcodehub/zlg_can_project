using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevitationHostCanbus
{
    public class DiagnosticData
    {
        public int lev_point;
        public int km1_fbk;
        public int km2_fbk;
        public int cap_charge_status;

        public int igbt_driver_board_status;
        public int power_supply_status;
        public int senseor_status;
        public int kt_status;

        public int cpu_status;

        public DiagnosticData()
        {
            lev_point = 0;
            km1_fbk = 0;
            km2_fbk = 0;
            cap_charge_status = 0;

            igbt_driver_board_status = 0;
            power_supply_status = 0;
            senseor_status = 0;
            kt_status = 0;

            cpu_status = 0;
        }
    }
}
