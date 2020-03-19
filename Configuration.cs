﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace TestTask
{
    class Configuration
    {
        public static string GetInputPath() => ConfigurationManager.AppSettings["InputFile"];
        public static string GetOutputPath() => ConfigurationManager.AppSettings["OutputFile"];

        public static Dictionary<string, string> GetWordsDictionary()
        {
            var openWords = ConfigurationManager.AppSettings["OpenWords"].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var closeWords = ConfigurationManager.AppSettings["CloseWords"].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var words = openWords.Zip(closeWords, (first, second) => new { first, second })
                                    .ToDictionary(val => val.first, val => val.second);

            return words;
        }
    }
}
