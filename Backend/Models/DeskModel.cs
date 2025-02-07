﻿namespace Backend.Models;

public class DeskModel
{
    public uint Id { get; set; }

    public string? Name { get; set; }

    public short Number { get; set; }

    public byte SeatCount { get; set; }

    public bool IsFree { get; set; }
}