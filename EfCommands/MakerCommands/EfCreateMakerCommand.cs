using Application.Commands.MakerCommands;
using Application.Dto.Maker;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.MakerCommands
{
    public class EfCreateMakerCommand : BaseContext, ICreateMakerCommand
    {
        public EfCreateMakerCommand(Context context) : base(context)
        {
        }

        public void Execute(MakerDto request)
        {
            _context.Makers.Add(new Maker
            {
                MakerName = request.MakerName
            });

            _context.SaveChanges();
        }
    }
}
