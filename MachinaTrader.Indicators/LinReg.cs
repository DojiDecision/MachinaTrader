using System;
using System.Collections.Generic;
using System.Linq;
using MachinaTrader.Globals.Structure.Enums;
using MachinaTrader.Globals.Structure.Models;

namespace MachinaTrader.Indicators
{
    public static partial class Extensions
    {
        public static List<decimal?> LinReg(this List<Candle> source, int period = 18, CandleVariable type = CandleVariable.Close)
        {
            int outBegIdx, outNbElement;
            double[] linregValues = new double[source.Count];
            double[] valuesToCheck;

            switch (type)
            {
                case CandleVariable.Open:
                    valuesToCheck = source.Select(x => Convert.ToDouble(x.Open)).ToArray();
                    break;
                case CandleVariable.Low:
                    valuesToCheck = source.Select(x => Convert.ToDouble(x.Low)).ToArray();
                    break;
                case CandleVariable.High:
                    valuesToCheck = source.Select(x => Convert.ToDouble(x.High)).ToArray();
                    break;
                default:
                    valuesToCheck = source.Select(x => Convert.ToDouble(x.Close)).ToArray();
                    break;
            }

            var lr = TicTacTec.TA.Library.Core.LinearReg(0, source.Count - 1, valuesToCheck, period, out outBegIdx, out outNbElement, linregValues);

            if (lr == TicTacTec.TA.Library.Core.RetCode.Success)
            {
                return FixIndicatorOrdering(linregValues.ToList(), outBegIdx, outNbElement);
            }

            throw new Exception("Could not calculate Linear Regression!");
        }
                    
    }
}
