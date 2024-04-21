using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_architecture_35.Model
{
    public class PlayerStatistics
    {
        private string criterion;
        private DataTable playerTable;
        private Dictionary<string, uint> result;

        public PlayerStatistics(DataTable playerTable)
        {
            this.playerTable = playerTable;
            this.criterion = "Score";
            this.resultDetermination();
        }

        public string Criterion
        {
            get { return this.criterion; }
            set { this.criterion = value; this.resultDetermination(); }
        }

        public DataTable DoctorsList
        {
            get { return this.playerTable; }
            set { this.playerTable = value; this.resultDetermination(); }
        }

        public Dictionary<string, uint> Result
        {
            get { return this.result; }
        }

        private void resultDetermination()
        {
            this.result = new Dictionary<string, uint>();
            if (this.criterion == "Score")
                this.resultDeterminationScore();
            else
                this.resultDeterminationAge();
        }

        private void resultDeterminationScore()
        {
            foreach (DataRow dr in this.playerTable.Rows)
            {
                string key = (string)dr["FullName"];
                uint keyValue = (uint)((int)dr["Score"]);

                this.result[key] = keyValue;
            }
        }

        private void resultDeterminationAge()
        {
            foreach (DataRow dr in this.playerTable.Rows)
            {
                int keyValue = (int)dr["Age"];
                string key = this.keyRange(keyValue);
                if (this.result.ContainsKey(key))
                    this.result[key]++;
                else
                    this.result[key] = 1;
            }
        }
        
        private string keyRange(int key)
        {
            string range = "[0;9]";
            int value = key / 10;
            if (value > 0)
                range = "[" + value + "0;" + value + "9]";
            return range;
        }
    }
}
