using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LevitationHostCanbus
{
    public class CmdData : LevCanData
    {
        //protected int point_id;
        public uint[] lev_point_selected;  // levtation point position.
        //public byte[] data;

        // cmdID
        private uint cmdID_take_off = 0x1122;
        private uint cmdID_landing = 0x1133;

        private uint mailboxID_send_params_g1 = 0x0020;
        private uint mailboxID_send_params_g2 = 0x0040;
        private uint mailboxID_send_params_g3 = 0x0060;
        private uint mailboxID_send_params_g4 = 0x01c0;
        private uint mailboxID_ctrl_cmdID = 0x0180;

        public CmdData()
        {
            //data = new byte[8];
            lev_point_selected = new uint[20];
        }

        public uint cmdIDTakeOff
        {
            get { return cmdID_take_off; }
        }

        public uint cmdIDLanding
        {
            get { return cmdID_landing; }
        }

        public uint mailboxIDSendParamsG1
        {
            get { return mailboxID_send_params_g1; }
        }
        public uint mailoxIDSendParamsG2
        {
            get { return mailboxID_send_params_g2; }
        }
        public uint mailboxIDSendParamsG3
        {
            get { return mailboxID_send_params_g3; }
        }
        public uint mailboxIDSendParamsG4
        {
            get { return mailboxID_send_params_g4; }
        }
        public uint mailboxIDCtrlCmd
        {
            get { return mailboxID_ctrl_cmdID;}
        }

        public void getLevPointSelected()
        {
            int tmp;
            for (int i = 0; i < 20; i++)
            {
                tmp = (point_id >> i) & 0x0001;
                if (tmp != 0)
                    lev_point_selected[i] = (uint)i + 1;
                else
                    lev_point_selected[i] = 0;
            }
        }

        public uint setCmdDataID(uint lev_point, uint cmd_id)
        {
            can_data_id = lev_point + (cmd_id << 5);
            return can_data_id;
        }



    }

    public class MonitorData : LevCanData
    {
        //public DecodeRecCanData info = new DecodeRecCanData();

        // received messages id
        public DecodeRecCanData[] s0 = new DecodeRecCanData[20];
        public DecodeRecCanData[] s1 = new DecodeRecCanData[20];
        public DecodeRecCanData[] s2 = new DecodeRecCanData[20];
        public DecodeRecCanData[] s3 = new DecodeRecCanData[20];

        public DecodeRecCanData[] a0 = new DecodeRecCanData[20];
        public DecodeRecCanData[] a1 = new DecodeRecCanData[20];
        public DecodeRecCanData[] a2 = new DecodeRecCanData[20];

        public DecodeRecCanData[] u1 = new DecodeRecCanData[20];
        public DecodeRecCanData[] i1 = new DecodeRecCanData[20];
        public DecodeRecCanData[] i2 = new DecodeRecCanData[20];

        public DecodeRecCanData[] km1d = new DecodeRecCanData[20];
        public DecodeRecCanData[] km2d = new DecodeRecCanData[20];
        public DecodeRecCanData[] speed = new DecodeRecCanData[20];
        public DecodeRecCanData[] temp = new DecodeRecCanData[20];

        private enum NUM_SIGN_UNSIGN {SIGN_NUM, UNSGIN_NUM};

        public MonitorData()
        {
            for (int i = 0; i < 20; i++)
            {
                // mailbox 0#, 0x620
                s0[i] = new DecodeRecCanData(2047, -2048, 20, 0, i + 1, "s0");
                s1[i] = new DecodeRecCanData(4095, 0, 20, 0, i + 1, "s1");
                s2[i] = new DecodeRecCanData(4095, 0, 20, 0, i + 1, "s2");
                s3[i] = new DecodeRecCanData(4095, 0, 20, 0, i + 1, "s3");

                u1[i] = new DecodeRecCanData(2047, 0, 400, 0, i + 1, "u0");
                i1[i] = new DecodeRecCanData(1536, 0, 120, 0, i + 1, "i1");
                i2[i] = new DecodeRecCanData(1536, 0, 120, 0, i + 1, "i2");

                a0[i] = new DecodeRecCanData(2047, -2048, 50, -50, i + 1, "a0");
                a1[i] = new DecodeRecCanData(4095, 0, 50, -50, i + 1, "a1");
                a2[i] = new DecodeRecCanData(4095, 0, 50, -50, i + 1, "a2");


                km1d[i] = new DecodeRecCanData(2047, -2048, 50, -50, i + 1, "km1d");
                km1d[i] = new DecodeRecCanData(2047, -2048, 50, -50, i + 1, "km2d");
                speed[i] = new DecodeRecCanData(2047, -2048, 50, -50, i + 1, "speed");
                temp[i] = new DecodeRecCanData(2047, -2048, 50, -50, i + 1, "temp");
            }

            this.tail = 0;
            this.head = 0;
        }

        /// <summary>
        /// get can data mailbox id, frame id is 11-bit, low 5-bit is 
        /// the levitation point id, bit 6 ~ bit 11 is the mailbox id
        /// </summary>
        /// <param name="can_data_id"></param>
        /// <returns></returns>
        public int getCanDataLevPoint(uint can_data_id)
        {
            //int point_id;
            this.point_id = (int)can_data_id & 0x1f;
            return point_id;
        }

        /// <summary>
        /// get can data mailbox id, frame id is 11-bit, 0-4bit is 
        /// the levitation point id, bit 5 ~ bit 11 is the mailbox id
        /// </summary>
        /// <param name="can_data_id"></param>
        /// <returns></returns>
        public uint getCanDataMailboxID(uint can_data_id)
        {
            //uint mbid;
            this.mbid = can_data_id & 0xfe0;
            return this.mbid;
        }

        /// <summary>
        /// decoding data based on can data id that including
        /// the point id and mailbox id.
        /// </summary>
        /// <param name="msg_id"></param>
        public void decodingData(uint msg_id, uint time_stamp)
        {
            this.mbid = getCanDataMailboxID(msg_id);
            this.point_id = getCanDataLevPoint(msg_id);
            int ind = this.point_id - 1;
            int tmp;

            if (this.can_data != null)
            {
                if (this.mbid == 0x620)
                {
                    tmp = this.convert2IntData(this.can_data[1], this.can_data[0], NUM_SIGN_UNSIGN.UNSGIN_NUM);
                    this.s1[ind].calcDecodeValue(tmp, time_stamp, this.s1[ind].AddData2Buff);

                    tmp = this.convert2IntData(this.can_data[3], this.can_data[2], NUM_SIGN_UNSIGN.UNSGIN_NUM);
                    this.s2[ind].calcDecodeValue(tmp, time_stamp, this.s2[ind].AddData2Buff);

                    tmp = this.convert2IntData(this.can_data[5], this.can_data[4], NUM_SIGN_UNSIGN.UNSGIN_NUM);
                    this.s3[ind].calcDecodeValue(tmp, time_stamp, this.s3[ind].AddData2Buff);
                }
                else if (this.mbid == 0x640)
                {
                    tmp = this.convert2IntData(this.can_data[7], this.can_data[6], NUM_SIGN_UNSIGN.SIGN_NUM);
                    this.s0[ind].calcDecodeValue(tmp, time_stamp, this.s0[ind].AddData2Buff);

                    tmp = this.convert2IntData(this.can_data[5], this.can_data[4], NUM_SIGN_UNSIGN.SIGN_NUM);
                    this.u1[ind].calcDecodeValue(tmp, time_stamp, this.u1[ind].AddData2Buff);

                    tmp = this.convert2IntData(this.can_data[3], this.can_data[2], NUM_SIGN_UNSIGN.SIGN_NUM);
                    this.i1[ind].calcDecodeValue(tmp, time_stamp, this.i1[ind].AddData2Buff);

                    tmp = this.convert2IntData(this.can_data[1], this.can_data[0], NUM_SIGN_UNSIGN.SIGN_NUM);
                    this.i2[ind].calcDecodeValue(tmp, time_stamp, this.i2[ind].AddData2Buff);
                }
                else if (this.mbid == 0x660)
                {
                    tmp = this.convert2IntData(this.can_data[5], this.can_data[4], NUM_SIGN_UNSIGN.UNSGIN_NUM);
                    this.a0[ind].calcDecodeValue(tmp, time_stamp, this.a0[ind].AddData2Buff);

                    tmp = this.convert2IntData(this.can_data[1], this.can_data[0], NUM_SIGN_UNSIGN.UNSGIN_NUM);
                    this.a1[ind].calcDecodeValue(tmp, time_stamp, this.a1[ind].AddData2Buff);

                    tmp = this.convert2IntData(this.can_data[3], this.can_data[2], NUM_SIGN_UNSIGN.UNSGIN_NUM);
                    this.a2[ind].calcDecodeValue(tmp, time_stamp, this.a2[ind].AddData2Buff);
                }
                else
                {
                    MessageBox.Show("mailbox id is wrong", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        public float getDecodedValue(string data_name, int point_id)
        {
            float ret;

            ret = this[data_name, point_id].ValueDecoded;

            return ret;

        }

        private int convert2IntData(byte hi, byte low, NUM_SIGN_UNSIGN num)
        {
            int int_num;
            if (num == NUM_SIGN_UNSIGN.UNSGIN_NUM)
                int_num = ((int)hi << 8) + (int)low;
            else
            {
                int_num = ((int)(hi) << 4) + ((((int)low) & 0xf0) >> 4);
                if (int_num > 2047)
                    int_num -= 4096;

            }
            return int_num;
        }

        public void setAddData2BuffFlag(string area_name, bool value)
        {
            //this[area_name].AddData2Buff = value;
            
            
            if (value)
            {
                this[area_name].DataTypeInChartsCount += 1;
                //this[area_name].AddData2Buff = value;
            }
            else
            {
                if (this[area_name].DataTypeInChartsCount > 0)
                    this[area_name].DataTypeInChartsCount -= 1;
            }

            if(this[area_name].DataTypeInChartsCount > 0)
                this[area_name].AddData2Buff = true;
            else
                this[area_name].AddData2Buff = false;
            
            
        }


        public DecodeRecCanData this[string arae_name]
        {

            get
            {
                DecodeRecCanData info = new DecodeRecCanData();
                string[] str = arae_name.Split('-');

                string data_name = str[1];
                int point_id = Convert.ToInt32(str[0]);

                if (data_name == "S0")
                    info = s0[point_id - 1];
                else if (data_name == "S1")
                    info = s1[point_id - 1];
                else if (data_name == "S2")
                    info = s2[point_id - 1];
                else if (data_name == "S3")
                    info = s3[point_id - 1];
                else if (data_name == "A0")
                    info = a0[point_id - 1];
                else if (data_name == "A1")
                    info = a1[point_id - 1];
                else if (data_name == "A2")
                    info = a2[point_id - 1];
                else if (data_name == "U1")
                    info = u1[point_id - 1];
                else if (data_name == "I1")
                    info = i1[point_id - 1];
                else if (data_name == "Temp")
                    info = i1[point_id - 1];
                else if (data_name == "SPEED")
                    info = i1[point_id - 1];
                else if (data_name == "KM2D")
                    info = i1[point_id - 1];
                else
                    info = null;

                return info;
            }
        }

        public DecodeRecCanData this[string data_name, int point_id]
        {

            get
            {
                DecodeRecCanData info = new DecodeRecCanData();

                if (data_name == "S0")
                    info = s0[point_id - 1];
                else if (data_name == "S1")
                    info = s1[point_id - 1];
                else if (data_name == "S2")
                    info = s2[point_id - 1];
                else if (data_name == "S3")
                    info = s3[point_id - 1];
                else if (data_name == "A0")
                    info = a0[point_id - 1];
                else if (data_name == "A1")
                    info = a1[point_id - 1];
                else if (data_name == "A2")
                    info = a2[point_id - 1];
                else if (data_name == "U1")
                    info = u1[point_id - 1];
                else if (data_name == "I1")
                    info = i1[point_id - 1];
                else if (data_name == "Temp")
                    info = i1[point_id - 1];
                else if (data_name == "SPEED")
                    info = i1[point_id - 1];
                else if (data_name == "KM2D")
                    info = i1[point_id - 1];
                else
                    info = null;

                return info;
            }
        }
         
    }


    public class LevCanData
    {
        // mailbox id, 0x620 0x640 0x660 0x680 0x6a0 etc.
        // the id of the mail box which contains the received data shall be decoded or trx data shall be packed.
        protected uint mbid;
        protected int point_id;  // the levtation point position.
        public uint can_data_id;
        public byte[] can_data;

        public int head, tail;
        public const int MAX_BUFF_LEN = 65536;
        

        public LevCanData(int lev_point)
        {
            can_data_id = 0x0000;
            can_data = new byte[8];
            point_id = lev_point;
            
        }

        public LevCanData()
        {
            can_data = new byte[8];
            can_data_id = 0x0000;
            //levitation_point = 0;
        }

        public void copyData(byte[] src, int len)
        {
            for(int i = 0; i < len; i++)
            {
                this.can_data[i] = src[i];
            }
        }

        public int LevPointID
        {
            get { return point_id; }
            set { point_id = value; }
        }

        public uint MailboxID
        {
            get { return mbid;}
            set { mbid = value;}
        }
    }

    public class DecodeRecCanData : LevCanData
    {
        protected int in_max, in_min, out_max, out_min;
        protected float k, b;  // y = k*x + b; 
        protected float value_decoded;
        public float[] value_buff;
        public uint[] time_stamp_buff;
        protected string name;
        protected uint time_stamp;  // count from the device opened, unit: ms
        protected bool add_data_to_buff;  // add data to flag when the levtation point chart has been add to ui
        protected int data_type_in_charts_cnt;

        protected void calcDecodeCoeff(int in_max, int in_min, int out_max, int out_min)
        {
            // (y - y1)/(x - x1) = k, y = kx -kx1 + y1;
            // (x1, y1) <==> (in_min, out_min) or (in_max, out_max)
            float out_range = (float) (out_max - out_min);
            float in_range = (float) (in_max - in_min);
            this.k = out_range / in_range;
            this.b = (float)out_min - this.k * (float)in_min;
        }

        public float calcDecodeValue(int indata, uint time_stamp, bool add2buff)
        {
            this.value_decoded = (float)Math.Round((double)this.k * indata + this.b, 2);
            if(add2buff)
                writeDecodedValueBuff(this.value_decoded, time_stamp);
            return this.value_decoded;
        }

        public float calcDecodeValue(int indata, uint time_stamp)
        {
            this.value_decoded = (float)Math.Round((double)this.k * indata + this.b, 2);
            if (this.add_data_to_buff)
                writeDecodedValueBuff(this.value_decoded, time_stamp);
            return this.value_decoded;
        }

        /// <summary>
        /// read the data buff and timestamp buff
        /// array[0]: value, array[1]: timestamp
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public ChartLineDataInfo readDecodedValueBuff(int len)
        {
            
            ChartLineDataInfo info;
            if (this.tail > 0)
            {
                info = new ChartLineDataInfo((double)time_stamp_buff[this.tail - 1], (double)value_buff[this.tail - 1]);
                //info = new ChartLineDataInfo((double)value_buff[this.tail - 1], (double)time_stamp_buff[this.tail - 1]);
            }
            else
                info = new ChartLineDataInfo();

            int cnt = 0;


            while (this.head != this.tail && cnt < len)
            {
                if (this.tail < 0)
                    break;
                info.YValueDataValue = (double)value_buff[this.tail];
                info.XValueTimeStamp = (double)time_stamp_buff[this.tail] / 1000;  // us -> ms

                this.tail += 1;
                cnt += 1;
                if (this.tail >= MAX_BUFF_LEN)
                    this.tail = 0;
            }


            return info;
        }

        public double[] readDecodedValueBuff(int begin_ind, int len)
        {
            int data_ind = this.head - len;
            double[] data = new double[len];

            for (int i = 0; i < len; i++)
                data[i] = 0;

            int cnt = 0;

            if (data_ind >= 0)
            {
                while (this.head != this.tail && cnt < len)
                {
                    data[cnt] = (double)this.value_buff[data_ind];

                    data_ind += 1;

                    this.tail += 1;
                    cnt += 1;
                    if (this.tail >= MAX_BUFF_LEN)
                        this.tail = 0;
                }
            }
            else
            {
                for(int i = 0; i < len + data_ind; i++)
                    data[i] = (double)this.value_buff[i];

                for (int i = (len + data_ind); i < len; i++)
                {
                    if (i > 1)
                        data[i] = data[i - 1];
                    else
                        data[i] = data[0];
                }
            }

            return data;
        }

        public void writeDecodedValueBuff(float data, uint time_stamp)
        {
            value_buff[head] = data;
            time_stamp_buff[head] = time_stamp;
            head += 1;
            if (head >= MAX_BUFF_LEN)
                head = 0;
        }

        public DecodeRecCanData(int in_max, int in_min, int out_max, int out_min, int lev_point_id, string name)
        {
            this.in_max = in_max;
            this.in_min = in_min;
            this.out_max = out_max;
            this.out_min = out_min;
            this.can_data = new byte[8];

            this.value_decoded = 0.0f;
            this.value_buff = new float[MAX_BUFF_LEN];
            this.time_stamp_buff = new uint[MAX_BUFF_LEN];
            for (int i = 0; i < MAX_BUFF_LEN; i++)
            {
                value_buff[i] = 0.0f;
                time_stamp_buff[i] = (UInt32)0;
            }

            this.LevPointID = lev_point_id;
            this.name = name;
            this.head = 0;
            this.tail = 0;

            this.add_data_to_buff = false;

            this.calcDecodeCoeff(in_max, in_min, out_max, out_min);
        }

        public DecodeRecCanData()
        {
            this.can_data = new byte[8];
            this.mbid = 0;
            this.value_decoded = 0.0f;
        }

        public uint MailboxID
        {
            get { return mbid; }
            set { mbid = value; }
        }

        public float ValueDecoded
        {
            get { return value_decoded;}
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public uint TimeStamp
        {
            get { return time_stamp; }
            set { time_stamp = value; }
        }

        public bool AddData2Buff
        {
            get { return add_data_to_buff; }
            set { add_data_to_buff = value; }
        }

        public int DataTypeInChartsCount
        {
            get { return this.data_type_in_charts_cnt; }
            set { this.data_type_in_charts_cnt = value; }
        }
    }

    public class ValueDecoded : DecodeRecCanData
    {
        public ValueDecoded()
        {
            this.tail = 0;
            this.head = 0;
        }


    }

    public interface DecodeCanData
    {
        //void calcDecodeCoeff(int in_max, int in_min, int out_max, int out_min);

        float calcDecodeValue(int indata);
    }

    public interface cmdID
    {

    }

    public class AddDataToBuff
    {
        public bool s0;
        public bool s1;
        public bool s2;
        public bool s3;

        public bool temp;
        public bool i1;
        public bool i2;
        public bool u1;

        public bool a0;
        public bool a1;
        public bool a2;
        public bool a3;

        public AddDataToBuff()
        {
            s0 = false;
            s1 = false;
            s2 = false;
            s3 = false;

            temp = false;
            i1 = false;
            i2 = false;
            u1 = false;

            a0 = false;
            a1 = false;
            a2 = false;
            a3 = false;

        }

    }

}
