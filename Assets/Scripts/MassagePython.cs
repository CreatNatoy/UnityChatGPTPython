using System;

public partial class PythonScriptRunner
{
    [Serializable]
    public class MassagePython
    {
        public string ApiKey;

        public string Massage;

        public MassagePython(string apiKey, string massage)
        {
            ApiKey = apiKey;
            Massage = massage;
        }
    }
}