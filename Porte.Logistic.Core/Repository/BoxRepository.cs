using Porte.Logistic.Core.Entity;
using Porte.Logistic.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Porte.Logistic.Core.Repository
{
    public class BoxRepository
    {
        List<Box> boxList = new List<Box>(1) { new Box { BoxId = 123450, Weight= 3 },
                                               new Box { BoxId = 123461, Weight= 8 },
                                               new Box { BoxId = 123472, Weight= 11},
                                               new Box { BoxId = 123483, Weight= 3},
                                               new Box { BoxId = 123494, Weight= 13}};

        BoxContext context = new BoxContext();

        public List<Box> GetBoxes()
        {
            //return boxList.OrderBy(r => r.Weight).ToList<Box>();


            return  context.Boxes.ToList<Box>();
        }


        public int AddPart(Part nPart)
        {

            context.Parts.Add(nPart);
            return context.SaveChanges();

        }


    }
}
