using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Linkedlistsstory.Filemanagment;
using System.IO;


namespace Linkedlistsstory
{
   
    
    public class Story
    {
        private readonly Dictionary<string, StoryNode> _nodeLookup;
        public StoryNode CurrentNode { get; private set; }

        public Story(string jsonPath, string startId = "start")
        {
            var json = File.ReadAllText(jsonPath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<StoryData>(json);

            if (data?.nodes == null)
                throw new InvalidDataException("Story data or nodes are missing in the JSON file.");

            _nodeLookup = data.nodes.ToDictionary(n => n.id);

            if (!_nodeLookup.ContainsKey(startId))
                throw new KeyNotFoundException($"Start node '{startId}' not found in story data.");

            CurrentNode = _nodeLookup[startId];
        }
        public StoryNode Advance(Option option) 
        {
            if (option == null) 
                return CurrentNode;
            if (_nodeLookup.TryGetValue(option.next,out var next))
            {
                CurrentNode = next; 
                return CurrentNode;

            }
            else
            {
                return null;
            }

        }
    }
    public class StoryData
    {
        public List<StoryNode> nodes { get; set; }
    }

    public class StoryNode
    {
        public string id { get; set; }
        public string text { get; set; }
        public List<Option> options { get; set; } = new();
    }

    public class Option
    {
        public string choice { get; set; }
        public string next { get; set; }
    }






}
