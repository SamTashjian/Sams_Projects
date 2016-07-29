using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using SGFModels;

namespace SGFData
{
    public interface IStateTaxInfoRepo
    {
        List<StateTaxInfo> GetAllStateTaxInfos();
        StateTaxInfo GetStateTaxInfoByStateName(string stateSearched);
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
            using (StreamReader sr = new StreamReader("TextFilesRefs\\StateTaxInfo.txt"))
            {
                string[] records = sr.ReadToEnd().Split('\n');//remove everything after sr. , replace  with  console.readline
                for (int i = 1; i < records.Length; i++)
                {
                    string record = records[i];
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

        public StateTaxInfo GetStateTaxInfoByStateName(string stateSearched)
        {
            var state = _stateTaxInfos.Where(s => s.StateName == stateSearched).FirstOrDefault();

            return state;
        }
    }
}