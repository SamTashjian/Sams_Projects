using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text;
using SGFModels;

namespace SGFData
{
    public interface IStateTaxInfoRepo
    {
        List<StateTaxInfo> GetAllStateTaxInfos();
    }

    class StateTaxInfoRepo : IStateTaxInfoRepo
    {
        private List<StateTaxInfo> _stateTaxInfos;
        public StateTaxInfoRepo()
        {
            Decode();
        }

        private void Decode()
        {
            _stateTaxInfos = new List<StateTaxInfo>();
            using (StreamReader sr = new StreamReader("StateTaxInfo.txt"))
            {
                string record = "";
                while ((record = sr.ReadLine()) != null)
                {
                    string[] fields = record.Split(',');
                    StateTaxInfo temp = new StateTaxInfo();
                    temp.StateAbb = fields[0];
                    temp.StateName = fields[1];
                    temp.TaxRate = Convert.ToDecimal(fields[2]);
                    _stateTaxInfos.Add(temp);
                }
            }
        }

        public List<StateTaxInfo> GetAllStateTaxInfos()
        {
            return _stateTaxInfos;

        }
    }
}