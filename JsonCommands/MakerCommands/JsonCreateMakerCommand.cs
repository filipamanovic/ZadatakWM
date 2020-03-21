using Application.Commands.MakerCommands;
using Application.Dto.Maker;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace JsonCommands.MakerCommands
{
    public class JsonCreateMakerCommand : ICreateMakerCommand
    {
        public void Execute(MakerDto request)
        {
            var makers = JsonConvert.DeserializeObject<List<MakerDto>>
                (File.ReadAllText(@"..\JsonDataAccess\Maker.json"));
            makers.Add(new MakerDto
            {
                Id = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds,
                MakerName = request.MakerName
            });

            File.WriteAllText(@"..\JsonDataAccess\Maker.json", JsonConvert.SerializeObject(makers));
        }
    }
}
