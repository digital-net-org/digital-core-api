using System.ComponentModel.DataAnnotations;

namespace SafariDigital.Api.Dto.Entities;

public class FramePayload
{
    public FramePayload()
    {
    }

    public FramePayload(string? data, string name)
    {
        Data = data;
        Name = name;
    }

    [Required]
    public string Name { get; set; }

    public string? Data { get; set; }
}