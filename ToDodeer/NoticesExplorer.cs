using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDodeer.NoticeDomain;

namespace ToDodeer
{
    public static class NoticesExplorer
    {
        public static NotesData notices;
        public static string jsonFilePath = "notes_data.json";
        public static Notice selectedNotice { get; set; }
        public static Task SaveNotesToJson(NotesData newData)
        {
            string jsonNotice = JsonConvert.SerializeObject(newData);
            File.WriteAllText(jsonFilePath, jsonNotice);
            return Task.CompletedTask;
        }


        public static Task SaveNotesToJson()
        {
            string jsonNotice = JsonConvert.SerializeObject(notices);
            File.WriteAllText(jsonFilePath, jsonNotice);
            return Task.CompletedTask;
        }

        public static Task<NotesData> GetNotesFromJson()
        {

            if (!File.Exists(jsonFilePath) || File.ReadAllText(jsonFilePath).Length < 1)
            {

                var firstNotice = new NotesData()
                {
                    Notices = new List<Notice>()
                    {
                        new Notice() {
                        Name = "Hello, world!",
                        Points =
                             new List<Point>()
                             {
                                new Point() { Name ="First" ,Content = new Content(){ Text="Let's change this world . . ."} },
                                new Point() { Name ="Second" ,Content = new Content(){ Text="Start from yourself"} }
                             }
                        }

                    }
                };
                string jsonNotice = JsonConvert.SerializeObject(firstNotice);
                File.WriteAllText(jsonFilePath, jsonNotice);
            }
            string json = File.ReadAllText(jsonFilePath);
            notices = JsonConvert.DeserializeObject<NotesData>(json);

            return Task.FromResult(notices);
        }
    }
}
