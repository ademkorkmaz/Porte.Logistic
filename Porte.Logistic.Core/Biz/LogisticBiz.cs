using Porte.Logistic.Core.Entity;
using Porte.Logistic.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Porte.Logistic.Core.Biz
{
    public class LogisticBiz
    {
        BoxRepository repo = null;
        public LogisticBiz()
        {

            repo = new BoxRepository();
        }

        public int  HandleLogisticOperations() {

            List<Box> boxList = CalculateBoxParts();
            int totalCost =  CalculatePartWeightsAndCost(boxList);

            return totalCost;
        }


        public List<Box> CalculateBoxParts()
        {

            List<Box> boxList = repo.GetBoxes().OrderBy( r => r.Weight).ToList<Box>();

            int partCount = 2;
            foreach (Box nBox in boxList)
            {

                nBox.PartCount = partCount;
                partCount++;
            }

            return boxList;
        }


        public int CalculatePartWeightsAndCost(List<Box> boxList)
        { 

            int partWeight = 0;
            int weightIndex = 0;

            int partIndex = 1;
            List<Part> bPartList = null;
            int totalCost = 0;

            try
            {

                foreach (Box nBox in boxList)
                {
                    bPartList = new List<Part>(nBox.PartCount);

                    partWeight = nBox.Weight / nBox.PartCount;
                    weightIndex = 0;
                    Part item = null;
                    // Fix Part Weight

                    for (int i = 0; i < nBox.PartCount; i++)
                    {
                        item = new Part();
                        item.BoxId = nBox.BoxId;
                        item.PartId = partIndex;
                        item.PartWeight = partWeight;
                        weightIndex += partWeight;

                        bPartList.Add(item);

                        partIndex++;
                    }

                    for (int i = 0; i < (nBox.Weight - weightIndex); i++)
                    {
                        bPartList[i].PartWeight += 1;
                    }

                    int dbRes = 0;
                    // Calculate Cost
                    foreach (Part nPart in bPartList)
                    {
                        nPart.PartCost = 50 + 7 * nPart.PartWeight;
                        totalCost += nPart.PartCost;

                        dbRes = repo.AddPart(nPart);
                    }

                    nBox.PartList = bPartList;

                    // SAve Parts To Db
                }


                return totalCost;
            }
            catch (Exception ex ) {

                // Log Exception
                throw ex;

                
            }
            return -1;

        }

    }

}