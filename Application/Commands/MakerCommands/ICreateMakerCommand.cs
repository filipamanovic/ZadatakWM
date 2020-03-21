using Application.Dto.Maker;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.MakerCommands
{
    public interface ICreateMakerCommand : ICommand<MakerDto>
    {
    }
}
