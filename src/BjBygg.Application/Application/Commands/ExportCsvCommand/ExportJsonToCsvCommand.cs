using MediatR;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace BjBygg.Application.Application.Commands.ExportCsvCommand
{
    public class ExportJsonToCsvCommand : IRequest<Uri>
    {
        public Dictionary<string, string> PropertyMap { get; set; }
        public List<JsonElement> JsonObjects { get; set; }

        //public string Delimiter { get; set; } = ",";
    }
}