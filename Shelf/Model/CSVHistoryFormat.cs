namespace Shelf.Model
{
    public class CSVHistoryFormat
    {
        [CsvHelper.Configuration.Attributes.Ignore]
        public int toolId { get; set; }

        [CsvHelper.Configuration.Attributes.Name("刀具名稱")]
        public string Name { get; set; }

        [CsvHelper.Configuration.Attributes.Name("使用磨耗")]
        public int DecreaseLife { get; set; }

        [CsvHelper.Configuration.Attributes.Name("使用前磨耗")]
        public int BeforeUseLife { get; set; }

        [CsvHelper.Configuration.Attributes.Name("使用後磨耗")]
        public int AfterUseLife { get; set; }

        [CsvHelper.Configuration.Attributes.Name("警戒值")]
        public int Warning { get; set; }

        [CsvHelper.Configuration.Attributes.Name("開始使用時間")]
        public string StartTime { get; set; }

        [CsvHelper.Configuration.Attributes.Name("結束使用時間")]
        public string EndTime { get; set; }

        [CsvHelper.Configuration.Attributes.Name("紀錄時間")]
        public string CreateTime { get; set; }
    }
}
