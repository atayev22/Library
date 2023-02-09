namespace Core.Utilities.Results
{
    public class Result
    {
        private object _data; 
        public ResultInfo ResultInfo { get; set; }

        public Result(object data, ResultInfo resultInfo)
        {
            Data = data;
            ResultInfo = resultInfo;
        }

        public Result(ResultInfo resultInfo)
        : this(null, resultInfo)
        {

        }
        public Result()
            : this(ResultInfo.NotImplemented)
        {

        }
        public object Data
        {
            get => _data;

            set
            {
                if (value is not null && ResultInfo == ResultInfo.NotImplemented)
                {
                    ResultInfo = ResultInfo.Success;
                }

                _data = value;
            }
        }
    }
}