﻿using SqlDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlDatabase
{
    public static class BracketsDataService
    {
        public static IEnumerable<Log> GetChecksHistoryList()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Logs.ToList();
            }
        }

        public static string GetTextByID(int id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                var result = db.Texts
                            .FirstOrDefault(t => t.TextID == id);

                if (result != null)
                    return result.TextSource;
                else
                    throw new Exception($"Text with id = {id} not found in database");
            }
        }

        public static void SaveResultToDatabase(bool result)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Log log = new Log { Result = result, Time = DateTime.Now };
                db.Logs.Add(log);
                db.SaveChanges();
            }
        }
    }
}