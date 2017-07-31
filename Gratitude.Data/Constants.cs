using System;
namespace Gratitude.Data
{
    public static class Constants
    {
        public const string HTTP_MEETING_DATA_PATH = "https://raw.githubusercontent.com/pradeep-pioneer/Gratitude-Data/master/meetingdata.csv";
        public const string HTTP_QUOTES_DATA_PATH = "https://raw.githubusercontent.com/pradeep-pioneer/Gratitude-Data/master/quotesprocessed.txt";
        public static string DB_FILE_PATH { get; set; }
        public const string DB_FILE_NAME = "SqlLiteDb.db3";
        public const string DATA_KEY_NAME = "data_loaded";
    }
}
