using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalizer
{
    public class MoodAnalyser
    {
        string message;
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        public string AnalyzeMood(string message)
        {
            if (message.ToLower().Contains("Sad"))
                return "Sad";
            return "Happy";
        }
        
        
    }
}
