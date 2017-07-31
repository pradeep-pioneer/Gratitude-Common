using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Gratitude.Data.Core;
using System.Diagnostics;
using SQLite;

namespace Gratitude.Data
{
    public class Meeting : BusinessEntityBase
    {
        public string GroupName { get; set; }
        public String Address { get; set; }
        public String State { get; set; }
        public String PostCode { get; set; }
        public String DayTime { get; set; }
        public String Contact { get; set; }
        public Double ExactLat { get; set; }
        public Double ExactLng { get; set; }
        [Ignore]
        public Location Location { get; set; }
        public String FormattedAddress { get; set; }
        public String Distance { get; set; }
        public String Area { get; set; }

        #region [ Construction ]

        public Meeting()
        {

        }

        public Meeting(string csvLine)
        {
            String[] values = csvLine.Split('|');
            Id = int.Parse(values[0].Replace("\"", ""));
            GroupName = values[1].Replace("\"", "");
            Address = values[2].Replace("\"", "");
            FormattedAddress = values[9].Replace("\"", "");
            Area = values[3].Replace("\"", "");
            State = values[4].Replace("\"", "");
            PostCode = values[5].Replace("\"", "");
            DayTime = values[6].Replace("\"", "");
            Contact = values[7].Replace("\"", "");
            ExactLat = Double.Parse(values[10].Replace("\"", ""));
            ExactLng = Double.Parse(values[11].Replace("\"", ""));
            Location = new Location(ExactLat, ExactLng);
        }

        #endregion

        #region [SqlLiteHelpers]

        public async static Task<bool> CreateDataBase(string dbPath){
            try{
                var db = new SQLite.SQLiteConnection(dbPath);
				var client = new HttpClient();
				var data = await client.GetStreamAsync(Constants.HTTP_MEETING_DATA_PATH);
                var reader = new StreamReader(data);
                reader.ReadLine();
                while(!reader.EndOfStream){
                    var line = reader.ReadLine();
                    if(!string.IsNullOrEmpty(line)){
                        var meeting = new Meeting(line);
                        db.CreateTable<Meeting>();
                        db.Insert(meeting);
                    }
                }
				return true;
            }
            catch(Exception ex){
                Debug.WriteLine(string.Format("{0}: {1}\n{2}",ex.GetType(),ex.Message,ex.StackTrace));
                return false;
            }
        }

        #endregion
    }
}
